using Database_C_.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Database_C_
{
	public partial class TransactionsView : Form
	{
		private TransactionManager transactionManager;
		private DataTable currentTable;
		private string currentTableName;

		public TransactionsView()
		{
			InitializeComponent();
		}

		private void TransactionsView_Load(object sender, EventArgs e)
		{
			UpdateButtonVisibility(false);
			loadTables();
		}

		private void loadTables()
		{
			string dbPath = Path.Combine(Vars.databasePath, Vars.selectedDb);

			tableComboBox.Items.Clear();

			if (Directory.Exists(dbPath))
			{
				string[] files = Directory.GetFiles(dbPath, "*.csv");

				foreach (string file in files)
				{
					string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file);
					tableComboBox.Items.Add(fileNameWithoutExtension);
				}

				if (tableComboBox.Items.Count > 0)
					tableComboBox.SelectedIndex = 0;
			}
			else
			{
				MessageBox.Show("Database folder not found.");
			}
		}

		private void tableComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			currentTableName = tableComboBox.SelectedItem.ToString();
			LoadTableData(currentTableName);
		}

		private void LoadTableData(string tableName)
		{
			string extension = Handler.isCSV ? ".csv" : ".bin"; // future-proof if you add .bin
			string tablePath = Path.Combine(Vars.databasePath, Vars.selectedDb, tableName + extension);

			if (!File.Exists(tablePath))
			{
				MessageBox.Show("Table file not found.");
				return;
			}

			currentTable = new DataTable();
			string[] lines = File.ReadAllLines(tablePath);

			if (lines.Length > 0)
			{
				string[] headers = lines[0].Split(',');

				foreach (string header in headers)
				{
					currentTable.Columns.Add(header);
				}

				for (int i = 1; i < lines.Length; i++)
				{
					string[] fields = lines[i].Split(',');
					currentTable.Rows.Add(fields);
				}
			}

			dataTable.DataSource = currentTable;
		}
		private void commitButton_Click(object sender, EventArgs e)
		{
			if (currentTable != null && currentTableName != null)
			{
				// Sync DataTable to TransactionManager before committing
				List<string> updatedLines = new List<string>();

				// Add header line
				string headerLine = string.Join(",", currentTable.Columns.Cast<DataColumn>().Select(c => c.ColumnName));
				updatedLines.Add(headerLine);

				// Add data rows
				foreach (DataRow row in currentTable.Rows)
				{
					string line = string.Join(",", row.ItemArray.Select(field => field.ToString()));
					updatedLines.Add(line);
				}

				// Update the tempTables in TransactionManager
				transactionManager.UpdateEntireTable(currentTableName + ".csv", updatedLines);

				transactionManager.Commit();
				UpdateButtonVisibility(false); 

				MessageBox.Show("Transaction Committed and Table Saved.");
			}
		}


		private void SaveTable(string tableName)
		{
			string extension = Handler.isCSV ? ".csv" : ".bin";
			string tablePath = Path.Combine(Vars.databasePath, Vars.selectedDb, tableName + extension);

			using (StreamWriter writer = new StreamWriter(tablePath))
			{
				// Write Header
				string[] columnNames = currentTable.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToArray();
				writer.WriteLine(string.Join(",", columnNames));

				// Write Rows
				foreach (DataRow row in currentTable.Rows)
				{
					string[] fields = row.ItemArray.Select(field => field.ToString()).ToArray();
					writer.WriteLine(string.Join(",", fields));
				}
			}
		}

		private void rollbackButton_Click(object sender, EventArgs e)
		{
			transactionManager.Rollback();

			if (currentTableName != null)
			{
				LoadTableData(currentTableName);
			}
			UpdateButtonVisibility(false); 

			MessageBox.Show("Transaction Rolled Back and Table Reloaded.");
		}

		private void dataTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			// Optional: Handle cell clicks if needed
		}
		private void startTransaction_Click(object sender, EventArgs e)
		{
			startTransaction();	
		}
		private void startTransaction()
		{
			string dbPath = Path.Combine(Vars.databasePath, Vars.selectedDb);
			transactionManager = new TransactionManager(dbPath);
			transactionManager.BeginTransaction();

			UpdateButtonVisibility(true); // transaction started
		}

		private void UpdateButtonVisibility(bool inTransaction)
		{
			startBtn.Visible = !inTransaction;
			commitBtn.Visible = inTransaction;
			rollbackBtn.Visible = inTransaction;
		}



	}
}
