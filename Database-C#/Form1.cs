using Database_C_.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Database_C_
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			LoadDatabasesToComboBox();
		}

		// load db folders
		private void LoadDatabasesToComboBox()
		{
			string basePath = Vars.databasePath;
			dbComboBox.Items.Clear();

			if (!Directory.Exists(basePath))
			{
				MessageBox.Show("Base path does not exist.");
				return;
			}

			foreach (string folder in Directory.GetDirectories(basePath))
			{
				dbComboBox.Items.Add(Path.GetFileName(folder));
			}

			if (dbComboBox.Items.Count > 0)
				dbComboBox.SelectedIndex = 0;
		}

		// create db
		private void button1_Click(object sender, EventArgs e)
		{
			string db = dbNameBox.Text.Trim();
			string fullPath = Path.Combine(Vars.databasePath, db);

			if (!Directory.Exists(fullPath))
			{
				Directory.CreateDirectory(fullPath);
				MessageBox.Show("Database created.");
			}
			else
			{
				MessageBox.Show("Database already exists.");
			}
			LoadDatabasesToComboBox();
		}

		// move to table view
		private void button2_Click(object sender, EventArgs e)
		{
			if (!EnsureDatabaseSelected()) return;

			SetSelectedDb();
			new TableView().Show();
		}

		// move to db view
		private void button3_Click(object sender, EventArgs e)
		{
			if (!EnsureDatabaseSelected()) return;

			SetSelectedDb();
			if (!HasAnyTables()) return;

			new DatabaseView().Show();
		}

		private void transactions_Click(object sender, EventArgs e)
		{
			if (!EnsureDatabaseSelected()) return;

			SetSelectedDb();
			if (!HasCsvTables("No tables found to perform transactions.")) return;

			new TransactionsView().Show();
		}


		private void button5_Click(object sender, EventArgs e)
		{
			if (!EnsureDatabaseSelected()) return;

			SetSelectedDb();
			string dbPath = Path.Combine(Vars.databasePath, Vars.selectedDb);
			string indexPath = Path.Combine(dbPath, "indexes");

			Directory.CreateDirectory(indexPath);
			if (!HasCsvTables("No tables found to index.")) return;

			string[] tables = Directory.GetFiles(dbPath, "*.csv");
			foreach (string tablePath in tables)
			{
				CreateIndexForTable(tablePath, indexPath);
			}

			MessageBox.Show("Indexes created for all tables.");
		}


		// toggle CSV/Binary mode
		private void isUseBin_CheckedChanged(object sender, EventArgs e)
		{
			Handler.isCSV = !isUseBin.Checked;
			panelCSVControls.Visible = Handler.isCSV;
		}

		// set selected db 
		private void SetSelectedDb()
		{
			Vars.selectedDb = dbComboBox.SelectedItem.ToString();
		}

		// ensire db is selected
		private bool EnsureDatabaseSelected()
		{
			if (dbComboBox.SelectedItem == null)
			{
				MessageBox.Show("Please select a database first.");
				return false;
			}
			return true;
		}

		// check DB has tables
		private bool HasAnyTables()
		{
			string dbPath = Path.Combine(Vars.databasePath, Vars.selectedDb);
			string[] tables = Handler.isCSV
				? Directory.GetFiles(dbPath, "*.csv")
				: Directory.GetFiles(dbPath, "*.bin");

			if (tables.Length == 0)
			{
				MessageBox.Show("No tables found for this database.");
				return false;
			}
			return true;
		}
		// check CSV tables exist for DB; show message if not
		private bool HasCsvTables(string message)
		{
			string dbPath = Path.Combine(Vars.databasePath, Vars.selectedDb);
			string[] tables = Directory.GetFiles(dbPath, "*.csv");

			if (tables.Length == 0)
			{
				MessageBox.Show(message);
				return false;
			}
			return true;
		}

		// create index file for a table
		private void CreateIndexForTable(string tablePath, string indexPath)
		{
			string tableName = Path.GetFileNameWithoutExtension(tablePath);
			string[] lines = File.ReadAllLines(tablePath);
			if (lines.Length <= 1) return;

			string[] headers = lines[0].Split(',');
			Dictionary<string, int> indexMap = new Dictionary<string, int>();

			for (int i = 1; i < lines.Length; i++)
			{
				string[] row = lines[i].Split(',');
				if (row.Length == 0) continue;

				string key = row[0]; // first column is key
				indexMap[key] = i;
			}

			string indexFile = Path.Combine(indexPath, tableName + ".index");
			using (StreamWriter sw = new StreamWriter(indexFile))
			{
				foreach (var kvp in indexMap)
				{
					sw.WriteLine($"{kvp.Key}:{kvp.Value}");
				}
			}
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
