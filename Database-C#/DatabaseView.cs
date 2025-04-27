﻿using Database_C_.models;
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
using Microsoft.VisualBasic; 

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
                string[] files = Handler.isCSV
                    ? Directory.GetFiles(dbPath, "*.csv")
                    : Directory.GetFiles(dbPath, "*.bin");

                foreach (string file in files)
                {
                    tableComboBox.Items.Add(Path.GetFileNameWithoutExtension(file));
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
            if (Handler.isCSV)
                LoadTableCSV();
            else
                LoadTableBIN();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Handler.isCSV)
                LoadTableCSV();
            else
                LoadTableBIN();
        }

        private void LoadTableBIN()
        {
            if (tableComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a table.");
                return;
            }

            string tableName = tableComboBox.SelectedItem.ToString();
            string filePath = Path.Combine(Vars.databasePath, Vars.selectedDb, tableName + ".bin");

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Table file not found.");
                return;
            }

            try
            {
                List<TableRow> rows;
                List<string> columns;

                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    columns = (List<string>)formatter.Deserialize(fs);
                    rows = (List<TableRow>)formatter.Deserialize(fs);
                }

                DataTable dt = new DataTable();
                foreach (var column in columns)
                {
                    dt.Columns.Add(column);
                }

                if (rows.Count > 0)
                {
                    foreach (var row in rows)
                    {
                        dt.Rows.Add(row.Columns.ToArray());
                    }
                }
                else
                {
                    MessageBox.Show("Table is empty. You can add new data.");
                }

                tableData.DataSource = dt;
                tableData.AllowUserToAddRows = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading table:\n" + ex.Message);
            }
        }

        private void LoadTableCSV()
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
                    string[] headers = lines[0].Split(',');
                    foreach (string header in headers)
                    {
                        dt.Columns.Add(header);
                    }

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

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (Handler.isCSV)
                SaveBtnCSV();
            else
                SaveBtnBIN();
        }

        private void SaveBtnBIN()
        {
            if (tableComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a table.");
                return;
            }

            string tableName = tableComboBox.SelectedItem.ToString();
            string filePath = Path.Combine(Vars.databasePath, Vars.selectedDb, tableName + ".bin");

            try
            {
                List<TableRow> rows = new List<TableRow>();
                List<string> columns = new List<string>();

                foreach (DataGridViewColumn column in tableData.Columns)
                {
                    columns.Add(column.HeaderText);
                }

                foreach (DataGridViewRow row in tableData.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        List<string> rowData = new List<string>();
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            rowData.Add(cell.Value?.ToString() ?? "");
                        }
                        rows.Add(new TableRow(rowData));
                    }
                }

                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, columns);
                    formatter.Serialize(fs, rows);
                }

                MessageBox.Show("Table saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving table:\n" + ex.Message);
            }
        }

        private void SaveBtnCSV()
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

                for (int i = 0; i < tableData.Columns.Count; i++)
                {
                    csvContent.Append(tableData.Columns[i].HeaderText);
                    if (i < tableData.Columns.Count - 1)
                        csvContent.Append(",");
                }
                csvContent.AppendLine();

                foreach (DataGridViewRow row in tableData.Rows)
                {
                    if (!row.IsNewRow)
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
            if (Handler.isCSV)
                DeleteBtnCSV();
            else
                DeleteBtnBIN();
        }

        private void DeleteBtnBIN()
        {
            if (tableComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a table to delete.");
                return;
            }

            string tableName = tableComboBox.SelectedItem.ToString();
            string filePath = Path.Combine(Vars.databasePath, Vars.selectedDb, tableName + ".bin");

            if (File.Exists(filePath))
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this table?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    File.Delete(filePath);
                    MessageBox.Show("Table deleted.");

                    tableComboBox.Items.Remove(tableName);
                    if (tableComboBox.Items.Count > 0)
                        tableComboBox.SelectedIndex = 0;

                    tableData.DataSource = null;
                }
            }
            else
            {
                MessageBox.Show("Table file not found.");
            }
        }

        private void DeleteBtnCSV()
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

                    tableComboBox.Items.Remove(tableName);
                    if (tableComboBox.Items.Count > 0)
                        tableComboBox.SelectedIndex = 0;

                    tableData.DataSource = null;
                }
            }
            else
            {
                MessageBox.Show("Table file not found.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Empty unless you want to add something
        }

        private void tableData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Empty unless needed
        }

        private void executeQueryBtn_Click(object sender, EventArgs e)
        {
            string query = queryBox.Text;
            bool isTableChanged = Parser.ParseQuery(query, tableData);

            if (isTableChanged)
                return;

            if (Handler.isCSV)
                LoadTableCSV();
            else
                LoadTableBIN();
        }
    }
}
