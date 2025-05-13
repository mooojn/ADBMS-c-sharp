using Database_C_.models;
using Database_C_.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_C_
{
	public partial class TableView : Form
	{
		int x = 80;
		int y = 50;
		int colCount = 0;
		int labelWidth = 80;
		int boxWidth = 150;
		int yDisplacement = 40;

		int maxColumns = 10;

		public TableView()
		{
			InitializeComponent();
		}

		private void Table_Load(object sender, EventArgs e)
		{
		}
		
		private void addColumnButton_Click(object sender, EventArgs e)
		{
			if (colCount < maxColumns)
				addColBtnClick();
			else
				MessageBox.Show("Column limit reached...");
		}
		private void addColBtnClick()
		{
			createName();
			createCol();

			colCount++;
		}
		private void createName()
		{
			Label nameLabel = new Label();
			nameLabel.Text = "Column Name";
			nameLabel.Width = labelWidth;

			nameLabel.Location = new Point(x - x, y+2);
			columnsPanel.Controls.Add(nameLabel);
		}
		private void createCol()
		{
			addCol.Location = new Point(x, y + yDisplacement);
			TextBox columnBox = new TextBox();
			columnBox.Width = boxWidth;
			columnBox.Location = new Point(x, y);
			y += yDisplacement;

			columnsPanel.Controls.Add(columnBox);
		}


		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void tableName_TextChanged(object sender, EventArgs e)
		{

		}
		private void createTable_Click(object sender, EventArgs e)
		{
			if (Handler.isCSV)
				createTableCSV();
			else
				createTableBIN();
		}
		private void createTableBIN()
		{
			List<string> columnNames = new List<string>();

			foreach (Control control in columnsPanel.Controls)
			{
				if (control is TextBox tb && !string.IsNullOrWhiteSpace(tb.Text))
				{
					columnNames.Add(tb.Text.Trim());
				}
			}

			if (columnNames.Count == 0)
			{
				MessageBox.Show("Please add at least one column.");
				return;
			}

			string table = tableName.Text.Trim();
			if (string.IsNullOrWhiteSpace(table))
			{
				MessageBox.Show("Please enter a table name.");
				return;
			}

			string folderPath = Path.Combine(Vars.databasePath, Vars.selectedDb);
			string filePath = Path.Combine(folderPath, table + ".bin");

			// Check if file already exists
			if (File.Exists(filePath))
			{
				MessageBox.Show("A table with this name already exists.");
				return;
			}

			try
			{
				// Create an empty list of rows to initialize the table
				List<TableRow> tableRows = new List<TableRow>();

				// Serialize the table structure into the binary file
				using (FileStream fs = new FileStream(filePath, FileMode.Create))
				{
					BinaryFormatter formatter = new BinaryFormatter();
					formatter.Serialize(fs, columnNames);  // First serialize the column names
					formatter.Serialize(fs, tableRows);    // Then serialize the table rows (empty initially)
				}

				MessageBox.Show("Table created successfully at:\n" + filePath);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error creating table:\n" + ex.Message);
			}
		}


		private void createTableCSV()
		{
			List<string> columnNames = new List<string>();

			foreach (Control control in columnsPanel.Controls)
			{
				if (control is TextBox tb && !string.IsNullOrWhiteSpace(tb.Text))
				{
					columnNames.Add(tb.Text.Trim());
				}
			}

			if (columnNames.Count == 0)
			{
				MessageBox.Show("Please add at least one column.");
				return;
			}

			string table = tableName.Text.Trim();
			if (string.IsNullOrWhiteSpace(table))
			{
				MessageBox.Show("Please enter a table name.");
				return;
			}

			string folderPath = Path.Combine(Vars.databasePath, Vars.selectedDb);
			string filePath = Path.Combine(folderPath, table + ".csv");

		
			if (File.Exists(filePath))
			{
				MessageBox.Show("A table with this name already exists.");
				return;
			}

			try
			{
				File.WriteAllText(filePath, string.Join(",", columnNames));
				MessageBox.Show("Table created successfully at:\n" + filePath);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error creating table:\n" + ex.Message);
			}
		}

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void querytext_TextChanged(object sender, EventArgs e)
        {

        }

        private void tablequerybtn_Click(object sender, EventArgs e)
        {
            string query = querytext.Text.Trim().ToUpper();
            string[] tokens = query.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (tokens.Length == 0)
            {
                MessageBox.Show("Please enter a query.");
                return;
            }

            string action = tokens[0];

            switch (action)
            {
                case "CREATE":
                    if (tokens.Length == 3 && tokens[1] == "TABLE")
                    {
                        string tableName = tokens[2];
                        CreateTableByQuery(tableName);
                    }
                    else
                    {
                        MessageBox.Show("Invalid CREATE TABLE syntax. Use: CREATE TABLE table_name");
                    }
                    break;

                case "DROP":
                    if (tokens.Length == 3 && tokens[1] == "TABLE")
                    {
                        string tableName = tokens[2];
                        DropTableByQuery(tableName);
                    }
                    else
                    {
                        MessageBox.Show("Invalid DROP TABLE syntax. Use: DROP TABLE table_name");
                    }
                    break;

                case "RENAME":
                    if (tokens.Length == 5 && tokens[1].ToUpper() == "TABLE" && tokens[3].ToUpper() == "TO")
                    {
                        string oldName = tokens[2];
                        string newName = tokens[4];
                        RenameTableByQuery(oldName, newName);
                    }
                    else
                    {
                        MessageBox.Show("Invalid RENAME TABLE syntax. Use: RENAME TABLE old_name TO new_name");
                    }
                    break;

                case "SHOW":
                    if (tokens.Length == 2 && tokens[1] == "TABLES")
                    {
                        ShowTablesByQuery();
                    }
                    else
                    {
                        MessageBox.Show("Invalid SHOW TABLES syntax.");
                    }
                    break;

                default:
                    MessageBox.Show("Unknown table query command.");
                    break;
            }
        }


        private void CreateTableByQuery(string tableName)
        {
            string folderPath = Path.Combine(Vars.databasePath, Vars.selectedDb);
            string filePath = Path.Combine(folderPath, tableName + (Handler.isCSV ? ".csv" : ".bin"));

            if (File.Exists(filePath))
            {
                MessageBox.Show("A table with this name already exists.");
                return;
            }

            // Dummy creation with no columns
            if (Handler.isCSV)
                File.WriteAllText(filePath, "");
            else
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, new List<string>()); // Empty columns
                    formatter.Serialize(fs, new List<TableRow>());
                }
            }

            MessageBox.Show("Table created: " + tableName);
        }

        private void DropTableByQuery(string tableName)
        {
            string folderPath = Path.Combine(Vars.databasePath, Vars.selectedDb);
            string binPath = Path.Combine(folderPath, tableName + ".bin");
            string csvPath = Path.Combine(folderPath, tableName + ".csv");

            if (File.Exists(binPath))
            {
                File.Delete(binPath);
                MessageBox.Show("Binary table dropped: " + tableName);
            }
            else if (File.Exists(csvPath))
            {
                File.Delete(csvPath);
                MessageBox.Show("CSV table dropped: " + tableName);
            }
            else
            {
                MessageBox.Show("Table not found.");
            }
        }

        private void RenameTableByQuery(string oldName, string newName)
        {
            string folderPath = Path.Combine(Vars.databasePath, Vars.selectedDb);
            string oldBinPath = Path.Combine(folderPath, oldName + ".bin");
            string newBinPath = Path.Combine(folderPath, newName + ".bin");
            string oldCsvPath = Path.Combine(folderPath, oldName + ".csv");
            string newCsvPath = Path.Combine(folderPath, newName + ".csv");

            if (File.Exists(oldBinPath))
                File.Move(oldBinPath, newBinPath);
            else if (File.Exists(oldCsvPath))
                File.Move(oldCsvPath, newCsvPath);
            else
            {
                MessageBox.Show("Original table not found.");
                return;
            }

            MessageBox.Show("Table renamed successfully.");
        }

        private void ShowTablesByQuery()
        {
            string folderPath = Path.Combine(Vars.databasePath, Vars.selectedDb);
            var files = Directory.GetFiles(folderPath)
                .Where(f => f.EndsWith(".csv") || f.EndsWith(".bin"))
                .Select(f => Path.GetFileNameWithoutExtension(f))
                .ToList();

            if (files.Count == 0)
            {
                MessageBox.Show("No tables found.");
            }
            else
            {
                string result = "Tables:\n" + string.Join("\n", files);
                MessageBox.Show(result);
            }
        }

    }
}
