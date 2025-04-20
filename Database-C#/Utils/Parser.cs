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
			var match = Regex.Match(query, @"SELECT\s+\*\s+FROM\s+(\w+)", RegexOptions.IgnoreCase);
			if (!match.Success)
			{
				MessageBox.Show("Invalid SELECT syntax.");
				return;
			}

			string table = match.Groups[1].Value;
			string filePath = Path.Combine(basePath, table + ".csv");

			if (!File.Exists(filePath))
			{
				MessageBox.Show("Table not found.");
				return;
			}

			string[] lines = File.ReadAllLines(filePath);

			if (lines.Length == 0)
			{
				MessageBox.Show("Table is empty.");
				return;
			}

			DataTable dt = new DataTable();
			string[] headers = lines[0].Split(',');

			foreach (string header in headers)
				dt.Columns.Add(header.Trim());

			for (int i = 1; i < lines.Length; i++)
			{
				string[] rowValues = lines[i].Split(',');
				dt.Rows.Add(rowValues.Select(v => v.Trim()).ToArray());
			}

			tableData.DataSource = null; // Clear first
			tableData.DataSource = dt;
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