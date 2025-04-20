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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Database_C_
{
	public partial class DatabaseView : Form
	{
		public DatabaseView()
		{
			InitializeComponent();
		}

		private void DatabaseView_Load(object sender, EventArgs e)
		{
			string dbPath = Path.Combine(Vars.databasePath, Vars.selectedDb);

			tableComboBox.Items.Clear();

			if (Directory.Exists(dbPath))
			{
				string[] files = Directory.GetFiles(dbPath, "*.csv");

				foreach (string file in files)
				{
					string fileName = Path.GetFileNameWithoutExtension(file);
					tableComboBox.Items.Add(fileName);
				}

				if (tableComboBox.Items.Count > 0)
				{
					tableComboBox.SelectedIndex = 0;
				}
			}
			else
			{
				MessageBox.Show("Database folder not found.");
			}
		}


		private void tableComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			LoadTable();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			LoadTable();
		}
		private void LoadTable()
		{
			if (tableComboBox.SelectedItem == null)
			{
				MessageBox.Show("Please select a table.");
				return;
			}

			string tableName = tableComboBox.SelectedItem.ToString();
			string filePath = Path.Combine(Vars.databasePath, Vars.selectedDb, tableName + ".csv");

			if (!File.Exists(filePath))
			{
				MessageBox.Show("Table file not found.");
				return;
			}

			try
			{
				DataTable dt = new DataTable();
				string[] lines = File.ReadAllLines(filePath);

				if (lines.Length > 0)
				{
					// Set columns
					string[] headers = lines[0].Split(',');
					foreach (string header in headers)
					{
						dt.Columns.Add(header);
					}

					// Add data rows
					for (int i = 1; i < lines.Length; i++)
					{
						string[] row = lines[i].Split(',');
						dt.Rows.Add(row);
					}

					tableData.DataSource = dt;
				}
				else
				{
					MessageBox.Show("Table is empty.");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error loading table:\n" + ex.Message);
			}
		}


		private void tableData_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}
		private void saveBtn_Click(object sender, EventArgs e)
		{
			if (tableComboBox.SelectedItem == null)
			{
				MessageBox.Show("Please select a table.");
				return;
			}

			string tableName = tableComboBox.SelectedItem.ToString();
			string filePath = Path.Combine(Vars.databasePath, Vars.selectedDb, tableName + ".csv");

			try
			{
				StringBuilder csvContent = new StringBuilder();

				// Write column headers
				for (int i = 0; i < tableData.Columns.Count; i++)
				{
					csvContent.Append(tableData.Columns[i].HeaderText);
					if (i < tableData.Columns.Count - 1)
						csvContent.Append(",");
				}
				csvContent.AppendLine();

				// Write rows
				foreach (DataGridViewRow row in tableData.Rows)
				{
					if (!row.IsNewRow) // skip empty new row
					{
						for (int i = 0; i < tableData.Columns.Count; i++)
						{
							csvContent.Append(row.Cells[i].Value?.ToString() ?? "");
							if (i < tableData.Columns.Count - 1)
								csvContent.Append(",");
						}
						csvContent.AppendLine();
					}
				}

				// Save to file
				File.WriteAllText(filePath, csvContent.ToString());
				MessageBox.Show("Table saved successfully.");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error saving table:\n" + ex.Message);
			}
		}
		private void deleteBtn_Click(object sender, EventArgs e)
		{
			if (tableComboBox.SelectedItem == null)
			{
				MessageBox.Show("Please select a table to delete.");
				return;
			}

			string tableName = tableComboBox.SelectedItem.ToString();
			string filePath = Path.Combine(Vars.databasePath, Vars.selectedDb, tableName + ".csv");

			if (File.Exists(filePath))
			{
				var confirm = MessageBox.Show("Are you sure you want to delete this table?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (confirm == DialogResult.Yes)
				{
					File.Delete(filePath);
					MessageBox.Show("Table deleted.");

					// Refresh table list
					tableComboBox.Items.Remove(tableName);

					if (tableComboBox.Items.Count > 0)
					{
						tableComboBox.SelectedIndex = 0;
					}
					tableData.DataSource = null;
				}
			}
			else
			{
				MessageBox.Show("Table file not found.");
			}
		}

	}
}
