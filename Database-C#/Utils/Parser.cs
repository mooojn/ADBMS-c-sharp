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
            if (!match.Success)
            {
                MessageBox.Show("Invalid INSERT query.");
                return;
            }

            string table = match.Groups[1].Value;
            string[] values = match.Groups[2].Value.Split(',').Select(v => v.Trim()).ToArray();
            string filePath = Path.Combine(basePath, table + ".csv");

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Table not found.");
                return;
            }

            // Read existing lines to determine the new row
            // 




            var lines = File.ReadAllLines(filePath).ToList();
            string[] headers = lines[0].Split(',');

            if (values.Length != headers.Length)
            {
                MessageBox.Show("Inserted values count does not match table columns.");
                return;
            }

            // Append new row
            lines.Add(string.Join(",", values));
            File.WriteAllLines(filePath, lines);


            MessageBox.Show("Row inserted");
        }


        private static void HandleSelect(string query, DataGridView tableData, string basePath)
        {
            try
            {
                var selectRegex = new Regex(
                    @"SELECT\s+(?<cols>\*|[\w\s,\.]+)\s+FROM\s+(?<table1>\w+)" +
                    @"(\s+WHERE\s+(?<whereCond>.+))?",
                    RegexOptions.IgnoreCase
                );

                var match = selectRegex.Match(query);
                if (!match.Success)
                {
                    MessageBox.Show("Invalid SELECT query.");
                    return;
                }

                string columns = match.Groups["cols"].Value.Trim();
                string table1 = match.Groups["table1"].Value.Trim();
                string whereCond = match.Groups["whereCond"].Success ? match.Groups["whereCond"].Value.Trim() : null;

                // Load table1
                string path1 = Path.Combine(basePath, table1 + ".csv");
                if (!File.Exists(path1)) { MessageBox.Show($"Table '{table1}' not found."); return; }
                string[] lines1 = File.ReadAllLines(path1);
                string[] headers1 = lines1[0].Split(',');
                List<string[]> rows1 = lines1.Skip(1).Select(l => l.Split(',')).ToList();

                // Prepare result table
                DataTable dt = new DataTable();
                List<int> selectedIndices = new List<int>();

                if (columns == "*")
                {
                    foreach (var col in headers1)
                    {
                        dt.Columns.Add($"{table1}.{col}");
                        selectedIndices.Add(Array.IndexOf(headers1, col));
                    }
                }
                else
                {
                    var requestedColumns = columns.Split(',').Select(c => c.Trim()).ToList();
                    foreach (var col in requestedColumns)
                    {
                        string simpleCol = col.Contains('.') ? col.Split('.')[1] : col; // handle "table.column"
                        int index = Array.IndexOf(headers1, simpleCol);
                        if (index == -1) { MessageBox.Show($"Column '{col}' not found."); return; }
                        dt.Columns.Add($"{table1}.{simpleCol}");
                        selectedIndices.Add(index);
                    }
                }

                List<string[]> filteredRows = new List<string[]>();

                if (!string.IsNullOrWhiteSpace(whereCond))
                {
                    // Try detect simple WHERE
                    var whereMatch = Regex.Match(whereCond, @"(\w+)\s*=\s*(\w+)", RegexOptions.IgnoreCase);
                    if (whereMatch.Success)
                    {
                        string whereCol = whereMatch.Groups[1].Value.Trim();
                        string whereVal = whereMatch.Groups[2].Value.Trim();
                    }
                    else
                    {
                        // fallback slow filter if complex WHERE
                        foreach (var row in rows1)
                        {
                            if (EvaluateWhere(whereCond, headers1, row))
                                filteredRows.Add(row);
                        }
                    }
                }
                else
                {
                    filteredRows = rows1;
                }

                // Fill DataTable
                foreach (var row in filteredRows)
                {
                    dt.Rows.Add(selectedIndices.Select(i => row[i]).ToArray());
                }

                tableData.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private static (string[] headers, List<string[]> rows) LoadTable(string filePath)
        {
            if (!File.Exists(filePath))
                throw new Exception("File not found: " + filePath);

            var lines = File.ReadAllLines(filePath);
            var headers = lines[0].Split(',');
            var rows = lines.Skip(1).Select(line => line.Split(',')).ToList();

            return (headers, rows);
        }

        private static bool EvaluateWhere(string whereCond, string[] headers, string[] row)
        {
            if (string.IsNullOrWhiteSpace(whereCond))
                return true;

            var match = Regex.Match(whereCond, @"(\w+\.\w+)\s*(=|!=|<|>|<=|>=)\s*('?[^']+'?)");
            if (!match.Success)
                return false;

            string col = match.Groups[1].Value.Trim();
            string op = match.Groups[2].Value.Trim();
            string value = match.Groups[3].Value.Trim('\'');
            int index = Array.IndexOf(headers, col);

            if (index == -1)
                return false;

            string cell = row[index];
            double n1, n2;
            bool isNum1 = double.TryParse(cell, out n1);
            bool isNum2 = double.TryParse(value, out n2);

            if (isNum1 && isNum2)
            {
                switch (op)
                {
                    case "=": return n1 == n2;
                    case "!=": return n1 != n2;
                    case "<": return n1 < n2;
                    case ">": return n1 > n2;
                    case "<=": return n1 <= n2;
                    case ">=": return n1 >= n2;
                }
            }
            else
            {
                switch (op)
                {
                    case "=": return cell == value;
                    case "!=": return cell != value;
                }
            }

            return false;
        }

		private static void HandleUpdate(string query, string basePath)
		{
			var match = Regex.Match(query, @"UPDATE\s+(\w+)\s+SET\s+(\w+)=(\w+)\s+WHERE\s+(\w+)=(\w+)", RegexOptions.IgnoreCase);
			if (!match.Success) { MessageBox.Show("Invalid UPDATE query."); return; }

			string table = match.Groups[1].Value;
			string setCol = match.Groups[2].Value;
			string setVal = match.Groups[3].Value;
			string whereCol = match.Groups[4].Value;
			string whereVal = match.Groups[5].Value;
			string filePath = Path.Combine(basePath, table + ".csv");

			if (!File.Exists(filePath)) { MessageBox.Show("Table not found."); return; }

			var lines = File.ReadAllLines(filePath).ToList();
			string[] headers = lines[0].Split(',');
			List<string[]> rows = lines.Skip(1).Select(l => l.Split(',')).ToList();

			int setColIndex = Array.IndexOf(headers, setCol);
			int whereColIndex = Array.IndexOf(headers, whereCol);

			if (setColIndex == -1 || whereColIndex == -1)
			{
				MessageBox.Show("Column not found.");
				return;
			}

			bool anyMatched = false;
			for (int i = 0; i < rows.Count; i++)
			{
				if (rows[i][whereColIndex] == whereVal)
				{
					rows[i][setColIndex] = setVal;
					anyMatched = true;
				}
			}

			if (!anyMatched)
			{
				MessageBox.Show("No matching rows found.");
				return;
			}

			// Write updated content back
			using (StreamWriter writer = new StreamWriter(filePath))
			{
				writer.WriteLine(string.Join(",", headers));
				foreach (var row in rows)
				{
					writer.WriteLine(string.Join(",", row));
				}
			}

			MessageBox.Show("Rows updated successfully.");
		}


		private static void HandleDelete(string query, string basePath)
		{
			var match = Regex.Match(query, @"DELETE\s+FROM\s+(\w+)\s+WHERE\s+(\w+)=(\w+)", RegexOptions.IgnoreCase);
			if (!match.Success)
			{
				MessageBox.Show("Invalid DELETE query.");
				return;
			}

			string table = match.Groups[1].Value;
			string whereCol = match.Groups[2].Value;
			string whereVal = match.Groups[3].Value;
			string filePath = Path.Combine(basePath, table + ".csv");

			if (!File.Exists(filePath))
			{
				MessageBox.Show("Table not found.");
				return;
			}

			var lines = File.ReadAllLines(filePath).ToList();
			string[] headers = lines[0].Split(',');
			List<string[]> rows = lines.Skip(1).Select(l => l.Split(',')).ToList();

			int whereColIndex = Array.IndexOf(headers, whereCol);
			if (whereColIndex == -1)
			{
				MessageBox.Show($"Column '{whereCol}' not found.");
				return;
			}

			int originalCount = rows.Count;
			rows = rows.Where(row => row[whereColIndex] != whereVal).ToList();

			if (rows.Count == originalCount)
			{
				MessageBox.Show("No matching rows found.");
				return;
			}

			using (StreamWriter writer = new StreamWriter(filePath))
			{
				writer.WriteLine(string.Join(",", headers));
				foreach (var row in rows)
				{
					writer.WriteLine(string.Join(",", row));
				}
			}

			MessageBox.Show("Row(s) deleted successfully.");
		}


	}
}
