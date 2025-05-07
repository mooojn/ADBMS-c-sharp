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

			// ✅ Check if file already exists
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


	}
}
