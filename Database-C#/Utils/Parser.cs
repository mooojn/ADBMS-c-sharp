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

				// Load table
				string tablePath = Path.Combine(basePath, table1 + ".csv");
				if (!File.Exists(tablePath)) { MessageBox.Show($"Table '{table1}' not found."); return; }

				string[] lines = File.ReadAllLines(tablePath);
				string[] headers = lines[0].Split(',');
				List<string[]> rows = lines.Skip(1).Select(l => l.Split(',')).ToList();

				// Prepare result table
				DataTable dt = new DataTable();
				List<int> selectedIndices = new List<int>();

				if (columns == "*")
				{
					foreach (var col in headers)
					{
						dt.Columns.Add($"{table1}.{col}");
						selectedIndices.Add(Array.IndexOf(headers, col));
					}
				}
				else
				{
					var requestedColumns = columns.Split(',').Select(c => c.Trim()).ToList();
					foreach (var col in requestedColumns)
					{
						string simpleCol = col.Contains('.') ? col.Split('.')[1] : col;
						int index = Array.IndexOf(headers, simpleCol);
						if (index == -1) { MessageBox.Show($"Column '{col}' not found."); return; }
						dt.Columns.Add($"{table1}.{simpleCol}");
						selectedIndices.Add(index);
					}
				}

				List<string[]> filteredRows = new List<string[]>();

				// Check if we can use index
				if (!string.IsNullOrWhiteSpace(whereCond))
				{
					var whereMatch = Regex.Match(whereCond, @"(\w+)\s*=\s*(\w+)", RegexOptions.IgnoreCase);
					if (whereMatch.Success)
					{
						string whereCol = whereMatch.Groups[1].Value.Trim();
						string whereVal = whereMatch.Groups[2].Value.Trim();

						int whereIndex = Array.IndexOf(headers, whereCol);
						if (whereIndex == -1)
						{
							MessageBox.Show($"WHERE column '{whereCol}' not found.");
							return;
						}

						// Try using index file
						string indexPath = Path.Combine(basePath, "indexes", table1 + ".index");
						if (File.Exists(indexPath))
						{
							var indexLines = File.ReadAllLines(indexPath);
							Dictionary<string, int> indexMap = new Dictionary<string, int>();
							foreach (string line in indexLines)
							{
								var parts = line.Split(':');
								if (parts.Length == 2)
									indexMap[parts[0]] = int.Parse(parts[1]);
							}

							if (indexMap.TryGetValue(whereVal, out int lineNum))
							{
								if (lineNum > 0 && lineNum < lines.Length)
								{
									filteredRows.Add(lines[lineNum].Split(','));
								}
							}
							else
							{
								MessageBox.Show("Value not found in index.");
							}

							// Inform the user that we used the index
							MessageBox.Show($"Data found using index for column '{whereCol}' with value '{whereVal}'.");
						}
						else
						{
							// No index, fall back to slow scan
							foreach (var row in rows)
								if (row[whereIndex] == whereVal)
									filteredRows.Add(row);

							// Inform the user that we used the slow CSV scan
							MessageBox.Show($"Data found by scanning CSV (no index) for column '{whereCol}' with value '{whereVal}'.");
						}
					}
					else
					{
						// Complex WHERE – fallback
						foreach (var row in rows)
						{
							if (EvaluateWhere(whereCond, headers, row))
								filteredRows.Add(row);
						}

						// Inform the user that we used the slow CSV scan for complex WHERE
						MessageBox.Show("Data found using slow CSV scan due to complex WHERE condition.");
					}
				}
				else
				{
					filteredRows = rows;

					// Inform the user that no WHERE condition was used (data from all rows)
					MessageBox.Show("Data found with no WHERE condition (all rows displayed).");
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
