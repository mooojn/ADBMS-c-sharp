using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Database_C_
{
	public class TransactionManager
	{
		private Dictionary<string, List<string>> originalTables;
		private Dictionary<string, List<string>> tempTables;
		private string databasePath;
		private bool inTransaction = false;

		public TransactionManager(string dbPath)
		{
			databasePath = dbPath;
			originalTables = new Dictionary<string, List<string>>();
			tempTables = new Dictionary<string, List<string>>();
		}

		public void BeginTransaction()
		{
			if (inTransaction) throw new Exception("Transaction already in progress.");

			string[] csvFiles = Directory.GetFiles(databasePath, "*.csv");

			foreach (string file in csvFiles)
			{
				string fileName = Path.GetFileName(file);
				List<string> lines = File.ReadAllLines(file).ToList();

				originalTables[fileName] = new List<string>(lines); // snapshot
				tempTables[fileName] = new List<string>(lines);     // working copy
			}

			inTransaction = true;
		}

		public List<string> GetTable(string tableName)
		{
			if (!inTransaction) throw new Exception("No active transaction.");
			if (!tempTables.ContainsKey(tableName)) throw new Exception("Table not found.");
			return tempTables[tableName];
		}

		public void Commit()
		{
			if (!inTransaction) throw new Exception("No active transaction.");

			foreach (var pair in tempTables)
			{
				string filePath = Path.Combine(databasePath, pair.Key);
				File.WriteAllLines(filePath, pair.Value);
			}

			inTransaction = false;
			originalTables.Clear();
			tempTables.Clear();
		}

		public void Rollback()
		{
			if (!inTransaction) throw new Exception("No active transaction.");

			tempTables = new Dictionary<string, List<string>>(originalTables);
			inTransaction = false;
			originalTables.Clear();
			tempTables.Clear();
		}
		// Insert a new row to a table
		public void InsertRow(string tableName, string newRow)
		{
			if (!inTransaction) throw new Exception("No active transaction.");
			if (!tempTables.ContainsKey(tableName)) throw new Exception("Table not found.");

			tempTables[tableName].Add(newRow); // Just add the row
		}

		// Update a row by index
		public void UpdateRow(string tableName, int rowIndex, string updatedRow)
		{
			if (!inTransaction) throw new Exception("No active transaction.");
			if (!tempTables.ContainsKey(tableName)) throw new Exception("Table not found.");

			if (rowIndex <= 0 || rowIndex >= tempTables[tableName].Count)
				throw new Exception("Invalid row index."); // 0 is usually header!

			tempTables[tableName][rowIndex] = updatedRow; // Replace
		}
		public void UpdateEntireTable(string tableName, List<string> updatedLines)
		{
			if (!inTransaction) throw new Exception("No active transaction.");
			if (!tempTables.ContainsKey(tableName)) throw new Exception("Table not found.");

			tempTables[tableName] = new List<string>(updatedLines);
		}

		// Delete a row by index
		public void DeleteRow(string tableName, int rowIndex)
		{
			if (!inTransaction) throw new Exception("No active transaction.");
			if (!tempTables.ContainsKey(tableName)) throw new Exception("Table not found.");

			if (rowIndex <= 0 || rowIndex >= tempTables[tableName].Count)
				throw new Exception("Invalid row index.");

			tempTables[tableName].RemoveAt(rowIndex); // Remove
		}

	}
}
