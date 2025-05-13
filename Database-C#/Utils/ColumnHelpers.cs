using Database_C_.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Database_C_.Utils
{
    public class ColumnHelpers
    {
        public static void AddColumnToTable(string columnName, string tableName)
        {
            MessageBox.Show(columnName);
            string filePath = Path.Combine(Vars.databasePath, Vars.selectedDb, tableName + (Handler.isCSV ? ".csv" : ".bin"));

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Table not found.");
                return;
            }

            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    List<string> columns = (List<string>)formatter.Deserialize(fs);
                    List<TableRow> rows = (List<TableRow>)formatter.Deserialize(fs);

                    if (columns.Contains(columnName))
                    {
                        MessageBox.Show("Column already exists.");
                        return;
                    }

                    columns.Add(columnName);
                    foreach (var row in rows)
                    {
                        row.Columns.Add(""); // empty value for new column
                    }

                    fs.SetLength(0); // Clear file
                    formatter.Serialize(fs, columns);
                    formatter.Serialize(fs, rows);

                    MessageBox.Show("Column added.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding column:\n" + ex.Message);
            }
        }

        public static void DropColumnFromTable(string columnName, string tableName)
        {
            string filePath = Path.Combine(Vars.databasePath, Vars.selectedDb, tableName + (Handler.isCSV ? ".csv" : ".bin"));

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Table not found.");
                return;
            }

            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    List<string> columns = (List<string>)formatter.Deserialize(fs);
                    List<TableRow> rows = (List<TableRow>)formatter.Deserialize(fs);

                    int index = columns.IndexOf(columnName);
                    if (index == -1)
                    {
                        MessageBox.Show("Column not found.");
                        return;
                    }

                    columns.RemoveAt(index);
                    foreach (var row in rows)
                    {
                        if (index < row.Columns.Count)
                            row.Columns.RemoveAt(index);
                    }

                    fs.SetLength(0);
                    formatter.Serialize(fs, columns);
                    formatter.Serialize(fs, rows);

                    MessageBox.Show("Column removed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing column:\n" + ex.Message);
            }
        }

        public static void RenameColumnInTable( string oldName, string newName,string tableName)    
        {
            MessageBox.Show(oldName);
            MessageBox.Show(newName);
            MessageBox.Show(tableName);
            string filePath = Path.Combine(Vars.databasePath, Vars.selectedDb, tableName + (Handler.isCSV ? ".csv" : ".bin"));

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Table not found.");
                return;
            }

            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    List<string> columns = (List<string>)formatter.Deserialize(fs);
                    List<TableRow> rows = (List<TableRow>)formatter.Deserialize(fs);

                    int index = columns.IndexOf(oldName);
                    if (index == -1)
                    {
                        MessageBox.Show("Column not found.");
                        return;
                    }

                    columns[index] = newName;

                    fs.SetLength(0);
                    formatter.Serialize(fs, columns);
                    formatter.Serialize(fs, rows);

                    MessageBox.Show("Column renamed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error renaming column:\n" + ex.Message);
            }
        }

        public static void ShowColumnsFromTable(string tableName)
        {
            string filePath = Path.Combine(Vars.databasePath, Vars.selectedDb, tableName + (Handler.isCSV ? ".csv" : ".bin"));

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Table not found.");
                return;
            }

            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    List<string> columns = (List<string>)formatter.Deserialize(fs);

                    MessageBox.Show("Columns:\n" + string.Join("\n", columns));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error showing columns:\n" + ex.Message);
            }
        }

    
    }
}
