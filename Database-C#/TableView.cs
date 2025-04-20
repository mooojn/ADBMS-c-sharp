using Database_C_.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_C_
{
	public partial class TableView : Form
	{
		int x = 10;
		int y = 10;
		public TableView()
		{
			InitializeComponent();
		}

		private void Table_Load(object sender, EventArgs e)
		{
			
		}
		
		private void addColumnButton_Click(object sender, EventArgs e)
		{
			TextBox columnBox = new TextBox();
			columnBox.Width = 200;
			columnBox.Location = new Point(x, y);
			y += 40;

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
