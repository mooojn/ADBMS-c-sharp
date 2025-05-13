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

		private void button4_Click(object sender, EventArgs e)
		{
			openFileDialog1.ShowDialog();
			string file = openFileDialog1.FileName;
			string storeTo = Path.Combine(Vars.databasePath, Vars.selectedDb);

			if (!File.Exists(file))
			{
				MessageBox.Show("The specified file does not exist.");
				return;
			}

			if (!Directory.Exists(storeTo))
			{
				MessageBox.Show("The destination directory does not exist.");
				return;
			}

			if(Path.GetExtension(file) != ".csv")
			{
				MessageBox.Show("The file should be of .csv format");
				return;
			}
			string fileName = Path.GetFileName(file);
			string destinationPath = Path.Combine(storeTo, fileName);

			try
			{
				File.Copy(file, destinationPath, overwrite: true);
				MessageBox.Show("File imported successfully.");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error copying file: " + ex.Message);
			}
		}
        private void button5_Click_1(object sender, EventArgs e)
        {
            string query = queryBox.Text;
            ParseAndExecuteQuery(query);
        }

        private void ParseAndExecuteQuery(string query)
        {
            query = query.Trim();

            if (string.IsNullOrEmpty(query))
            {
                MessageBox.Show("Query is empty.");
                return;
            }

            string[] tokens = query.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (tokens.Length < 2)
            {
                MessageBox.Show("Invalid query format.");
                return;
            }

            string command = tokens[0].ToUpper();
            string type = tokens[1].ToUpper();

            switch (command)
            {
                case "CREATE":
                    if (type == "DATABASE" && tokens.Length == 3)
                    {
                        string dbName = tokens[2];
                        string path = Path.Combine(Vars.databasePath, dbName);

                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                            MessageBox.Show($"Database '{dbName}' created.");
                            LoadDatabasesToComboBox();
                        }
                        else
                        {
                            MessageBox.Show("Database already exists.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid CREATE syntax.");
                    }
                    break;

                case "DROP":
                    if (type == "DATABASE" && tokens.Length == 3)
                    {
                        string dbName = tokens[2];
                        string path = Path.Combine(Vars.databasePath, dbName);

                        if (Directory.Exists(path))
                        {
                            Directory.Delete(path, true);
                            MessageBox.Show($"Database '{dbName}' deleted.");
                            LoadDatabasesToComboBox();
                        }
                        else
                        {
                            MessageBox.Show("Database does not exist.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid DROP syntax.");
                    }
                    break;

                case "USE":
                    if (type != "DATABASE" && tokens.Length == 2)
                    {
                        string dbName = tokens[1];
                        string path = Path.Combine(Vars.databasePath, dbName);

                        if (Directory.Exists(path))
                        {
                            Vars.selectedDb = dbName;
                            MessageBox.Show($"Switched to database '{dbName}'.");

                            LoadDatabasesToComboBox();
                            dbComboBox.SelectedItem = dbName;
                            TableView tableView = new TableView();
                            tableView.Show();
                        }
                        else
                        {
                            MessageBox.Show("Database does not exist.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid USE syntax.");
                    }
                    break;

                case "MODIFY":
                    if (type == "DATABASE" && tokens.Length == 5 && tokens[3].ToUpper() == "TO")
                    {
                        string oldName = tokens[2];
                        string newName = tokens[4];
                        string oldPath = Path.Combine(Vars.databasePath, oldName);
                        string newPath = Path.Combine(Vars.databasePath, newName);

                        if (Directory.Exists(oldPath))
                        {
                            if (!Directory.Exists(newPath))
                            {
                                Directory.Move(oldPath, newPath);
                                MessageBox.Show($"Database renamed from '{oldName}' to '{newName}'.");
                                LoadDatabasesToComboBox();
                            }
                            else
                            {
                                MessageBox.Show("New database name already exists.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Original database does not exist.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid MODIFY syntax.");
                    }
                    break;

                default:
                    MessageBox.Show("Unsupported query command.");
                    break;
            }
        }

        private void dbComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			SetSelectedDb();
		}

		private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
		{

		}

        private void queryBox_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
