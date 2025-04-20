using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Database_C_.Utils
{
	internal class Parser
	{
		public static bool ParseQuery(string query, DataGridView tableData)
		{
			string basePath = Path.Combine(Vars.databasePath, Vars.selectedDb);

			if (query.StartsWith("INSERT", StringComparison.OrdinalIgnoreCase))
			{
				HandleInsert(query, basePath);
			}
			else if (query.StartsWith("SELECT", StringComparison.OrdinalIgnoreCase))
			{
				HandleSelect(query, tableData, basePath);
				return true;
			}
			else if (query.StartsWith("UPDATE", StringComparison.OrdinalIgnoreCase))
			{
				HandleUpdate(query, basePath);
			}
			else if (query.StartsWith("DELETE", StringComparison.OrdinalIgnoreCase))
			{
				HandleDelete(query, basePath);
			}
			else
			{
				MessageBox.Show("Unsupported query.");
			}
			return false;
		}

		private static void HandleInsert(string query, string basePath)
		{
			var match = Regex.Match(query, @"INSERT\s+INTO\s+(\w+)\s+VALUES\s*\((.*?)\)", RegexOptions.IgnoreCase);
			if (!match.Success) return;

			string table = match.Groups[1].Value;
			string[] values = match.Groups[2].Value.Split(',');
			string filePath = Path.Combine(basePath, table + ".csv");

			if (!File.Exists(filePath)) { MessageBox.Show("Table not found."); return; }

			File.AppendAllText(filePath, "\n" + string.Join(",", values.Select(v => v.Trim())));
			MessageBox.Show("Row inserted.");
		}

        private static void HandleSelect(string query, DataGridView tableData, string basePath)
        {
            try
            {
                // Basic SELECT [columns] FROM table [JOIN table2 ON cond] [WHERE cond]
                var selectRegex = new Regex(
                    @"SELECT\s+(?<cols>\*|[\w\s,\.]+)\s+FROM\s+(?<table1>\w+)" +
                    @"(\s+JOIN\s+(?<table2>\w+)\s+ON\s+(?<joinCond>\w+\.\w+\s*=\s*\w+\.\w+))?" +
                    @"(\s+WHERE\s+(?<whereCond>.+))?",
                    RegexOptions.IgnoreCase
                );

                var match = selectRegex.Match(query);
                if (!match.Success)
                {
                    MessageBox.Show("Invalid SELECT query.");
                    return;
                }

                // Extract query components
                string columns = match.Groups["cols"].Value.Trim();
                string table1 = match.Groups["table1"].Value.Trim();
                string table2 = match.Groups["table2"].Success ? match.Groups["table2"].Value.Trim() : null;
                string joinCond = match.Groups["joinCond"].Success ? match.Groups["joinCond"].Value.Trim() : null;
                string whereCond = match.Groups["whereCond"].Success ? match.Groups["whereCond"].Value.Trim() : null;

                // Load table1
                string path1 = Path.Combine(basePath, table1 + ".csv");
                if (!File.Exists(path1)) { MessageBox.Show($"Table '{table1}' not found."); return; }
                string[] lines1 = File.ReadAllLines(path1);
                string[] headers1 = lines1[0].Split(',');
                List<string[]> rows1 = lines1.Skip(1).Select(l => l.Split(',')).ToList();

                List<string[]> finalRows = new List<string[]>();
                List<string> finalHeaders = new List<string>();

                if (table2 != null && joinCond != null)
                {
                    // Load table2
                    string path2 = Path.Combine(basePath, table2 + ".csv");
                    if (!File.Exists(path2)) { MessageBox.Show($"Table '{table2}' not found."); return; }
                    string[] lines2 = File.ReadAllLines(path2);
                    string[] headers2 = lines2[0].Split(',');
                    List<string[]> rows2 = lines2.Skip(1).Select(l => l.Split(',')).ToList();

                    // Parse join condition: A.col = B.col
                    var joinParts = joinCond.Split('=');
                    string[] left = joinParts[0].Trim().Split('.');
                    string[] right = joinParts[1].Trim().Split('.');

                    string leftTable = left[0], leftCol = left[1];
                    string rightTable = right[0], rightCol = right[1];

                    int leftIndex = (leftTable == table1) ? Array.IndexOf(headers1, leftCol) : Array.IndexOf(headers2, leftCol);
                    int rightIndex = (rightTable == table2) ? Array.IndexOf(headers2, rightCol) : Array.IndexOf(headers1, rightCol);

                    if (leftIndex == -1 || rightIndex == -1)
                    {
                        MessageBox.Show("Join column not found.");
                        return;
                    }

                    // Join headers
                    finalHeaders.AddRange(headers1.Select(h => $"{table1}.{h}"));
                    finalHeaders.AddRange(headers2.Select(h => $"{table2}.{h}"));

                    // Perform join
                    foreach (var row1 in rows1)
                    {
                        foreach (var row2 in rows2)
                        {
                            string val1 = (leftTable == table1) ? row1[leftIndex] : row2[leftIndex];
                            string val2 = (rightTable == table2) ? row2[rightIndex] : row1[rightIndex];

                            if (val1 == val2)
                            {
                                var combined = row1.Concat(row2).ToArray();

                                if (EvaluateWhereCondition(whereCond, finalHeaders.ToArray(), combined))
                                    finalRows.Add(combined);
                            }
                        }
                    }
                }
                else
                {
                    // No join, use table1 directly
                    finalHeaders = headers1.Select(h => $"{table1}.{h}").ToList();

                    foreach (var row in rows1)
                    {
                        if (EvaluateWhereCondition(whereCond, finalHeaders.ToArray(), row))
                            finalRows.Add(row);
                    }
                }

                // Create final datatable with selected columns
                DataTable dt = new DataTable();
                List<int> selectedIndices = new List<int>();

                if (columns == "*")
                {
                    // Select all columns
                    foreach (var col in finalHeaders)
                    {
                        dt.Columns.Add(col);
                        selectedIndices.Add(dt.Columns.Count - 1);
                    }
                }
                else
                {
                    // Handle specific column selection
                    var requestedColumns = columns.Split(',').Select(c => c.Trim()).ToList();
                    foreach (var col in requestedColumns)
                    {
                        int index = finalHeaders.IndexOf(col);
                        if (index == -1) { MessageBox.Show($"Column '{col}' not found."); return; }
                        dt.Columns.Add(col);
                        selectedIndices.Add(index);
                    }
                }

                // Add rows based on selected columns
                foreach (var row in finalRows)
                {
                    dt.Rows.Add(selectedIndices.Select(i => row[i]).ToArray());
                }

                // Set DataGridView data source
                tableData.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }



        private static bool EvaluateWhereCondition(string whereCond, string[] headers, string[] row)
        {
            // If no WHERE condition is provided, we allow all rows (return true)
            if (string.IsNullOrWhiteSpace(whereCond))
                return true;

            // Regex to match patterns like "table.column operator value"
            var match = Regex.Match(whereCond, @"(\w+\.\w+)\s*(=|<|>|<=|>=|!=)\s*('?[\w\s]+'?)");

            // If the WHERE condition doesn't match the expected pattern, return false
            if (!match.Success) return false;

            // Extract table.column, operator, and value from the regex match
            string col = match.Groups[1].Value.Trim();  // e.g., "student.age"
            string op = match.Groups[2].Value.Trim();   // e.g., "="
            string value = match.Groups[3].Value.Trim().Trim('\'');  // e.g., "21"

            // Find the index of the column in the header
            int index = Array.IndexOf(headers, col);
            if (index == -1) return false;  // If the column is not found, return false

            // Get the value from the row at the specified column index
            string cell = row[index];

            // Try parsing both the cell value and the value from the WHERE condition as numbers
            double numCell, numVal;
            bool isNumCell = double.TryParse(cell, out numCell);
            bool isNumVal = double.TryParse(value, out numVal);

            // If both cell value and condition value are numbers, perform number-based comparison
            if (isNumCell && isNumVal)
            {
                switch (op)
                {
                    case "=": return numCell == numVal;
                    case "<": return numCell < numVal;
                    case ">": return numCell > numVal;
                    case "<=": return numCell <= numVal;
                    case ">=": return numCell >= numVal;
                    case "!=": return numCell != numVal;
                    default: return false;
                }
            }
            else
            {
                // If it's not a number, perform string comparison
                switch (op)
                {
                    case "=": return cell == value;
                    case "!=": return cell != value;
                    default: return false;
                }
            }

            // If the operator doesn't match any cases, return false
            return false;
        }






        private static void HandleUpdate(string query, string basePath)
		{
			var match = Regex.Match(query, @"UPDATE\s+(\w+)\s+SET\s+(\w+)=(\w+)\s+WHERE\s+(\w+)=(\w+)", RegexOptions.IgnoreCase);
			if (!match.Success) return;

			string table = match.Groups[1].Value;
			string setCol = match.Groups[2].Value;
			string setVal = match.Groups[3].Value;
			string whereCol = match.Groups[4].Value;
			string whereVal = match.Groups[5].Value;
			string filePath = Path.Combine(basePath, table + ".csv");

			if (!File.Exists(filePath)) { MessageBox.Show("Table not found."); return; }

			var lines = File.ReadAllLines(filePath).ToList();
			string[] headers = lines[0].Split(',');
			int setIndex = Array.IndexOf(headers, setCol);
			int whereIndex = Array.IndexOf(headers, whereCol);

			if (setIndex == -1 || whereIndex == -1) { MessageBox.Show("Column not found."); return; }

			for (int i = 1; i < lines.Count; i++)
			{
				string[] row = lines[i].Split(',');
				if (row[whereIndex] == whereVal)
					row[setIndex] = setVal;
				lines[i] = string.Join(",", row);
			}

			File.WriteAllLines(filePath, lines);
			MessageBox.Show("Table updated.");
		}

		private static void HandleDelete(string query, string basePath)
		{
			var match = Regex.Match(query, @"DELETE\s+FROM\s+(\w+)\s+WHERE\s+(\w+)=(\w+)", RegexOptions.IgnoreCase);
			if (!match.Success) return;

			string table = match.Groups[1].Value;
			string whereCol = match.Groups[2].Value;
			string whereVal = match.Groups[3].Value;
			string filePath = Path.Combine(basePath, table + ".csv");

			if (!File.Exists(filePath)) { MessageBox.Show("Table not found."); return; }

			var lines = File.ReadAllLines(filePath).ToList();
			string[] headers = lines[0].Split(',');
			int whereIndex = Array.IndexOf(headers, whereCol);

			if (whereIndex == -1) { MessageBox.Show("Column not found."); return; }

			lines = lines.Where((line, index) => index == 0 || line.Split(',')[whereIndex] != whereVal).ToList();
			File.WriteAllLines(filePath, lines);
			MessageBox.Show("Row deleted.");
		}
	}
}