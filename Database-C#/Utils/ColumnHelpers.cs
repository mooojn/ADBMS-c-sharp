using Database_C_.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Database_C_.Utils
{
    public class ColumnHelpers
    {
        private static string GetFilePath(string tableName)
        {
            string extension = Handler.isCSV ? ".csv" : ".bin";
            return Path.Combine(Vars.databasePath, Vars.selectedDb, tableName + extension);
        }

        public static void AddColumnToTable(string columnName, string tableName)
        {
            string filePath = Path.Combine(Vars.databasePath, Vars.selectedDb, tableName + (Handler.isCSV ? ".csv" : ".bin"));

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Table not found.");
                return;
            }

            try
            {
                if (Handler.isCSV)
                {
                    var lines = File.ReadAllLines(filePath).ToList();

               
                    if (lines.Count == 0)
                    {
                   
                        File.WriteAllText(filePath, columnName + Environment.NewLine);
                        MessageBox.Show("Column added to empty CSV.");
                        return;
                    }

                
                    var header = lines[0].Split(',').ToList();

                    if (header.Contains(columnName))
                    {
                        MessageBox.Show("Column already exists.");
                        return;
                    }

                    header.Add(columnName);
                    lines[0] = string.Join(",", header);

                    int newColumnCount = header.Count;

               
                    for (int i = 1; i < lines.Count; i++)
                    {
                        var row = lines[i].Split(',').ToList();

                        while (row.Count < newColumnCount)
                        {
                            row.Add(""); 
                        }

                        if (row.Count > newColumnCount)
                        {
                            row = row.Take(newColumnCount).ToList();
                        }

                        lines[i] = string.Join(",", row);
                    }

                    File.WriteAllLines(filePath, lines);
                    MessageBox.Show("Column added to CSV.");
                }
                else
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
                            row.Columns.Add("");
                        }

                        fs.SetLength(0);
                        formatter.Serialize(fs, columns);
                        formatter.Serialize(fs, rows);

                        MessageBox.Show("Column added to BIN.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding column:\n" + ex.Message);
            }
        }

        public static void DropColumnFromTable(string columnName, string tableName)
        {
            string filePath = GetFilePath(tableName);

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Table not found.");
                return;
            }

            try
            {
                if (Handler.isCSV)
                {
                    var lines = File.ReadAllLines(filePath).ToList();
                    var header = lines[0].Split(',').ToList();
                    int index = header.IndexOf(columnName);

                    if (index == -1)
                    {
                        MessageBox.Show("Column not found.");
                        return;
                    }

                    header.RemoveAt(index);
                    lines[0] = string.Join(",", header);

                    for (int i = 1; i < lines.Count; i++)
                    {
                        var row = lines[i].Split(',').ToList();
                        if (index < row.Count)
                            row.RemoveAt(index);
                        lines[i] = string.Join(",", row);
                    }

                    File.WriteAllLines(filePath, lines);
                    MessageBox.Show("Column removed from CSV.");
                }
                else
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
                        MessageBox.Show("Column removed from binary table.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing column:\n" + ex.Message);
            }
        }

        public static void RenameColumnInTable(string oldName, string newName, string tableName)
        {
            string filePath = GetFilePath(tableName);

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Table not found.");
                return;
            }

            try
            {
                if (Handler.isCSV)
                {
                    var lines = File.ReadAllLines(filePath).ToList();
                    var header = lines[0].Split(',').ToList();

                    int index = header.IndexOf(oldName);
                    if (index == -1)
                    {
                        MessageBox.Show("Column not found.");
                        return;
                    }

                    header[index] = newName;
                    lines[0] = string.Join(",", header);
                    File.WriteAllLines(filePath, lines);

                    MessageBox.Show("Column renamed in CSV.");
                }
                else
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
                        MessageBox.Show("Column renamed in binary table.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error renaming column:\n" + ex.Message);
            }
        }

        public static void ShowColumnsFromTable(string tableName)
        {
            string filePath = GetFilePath(tableName);

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Table not found.");
                return;
            }

            try
            {
                if (Handler.isCSV)
                {
                    var lines = File.ReadAllLines(filePath);
                    if (lines.Length == 0)
                    {
                        MessageBox.Show("CSV is empty.");
                        return;
                    }

                    var header = lines[0].Split(',');
                    MessageBox.Show("Columns:\n" + string.Join("\n", header));
                }
                else
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Open))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        List<string> columns = (List<string>)formatter.Deserialize(fs);
                        MessageBox.Show("Columns:\n" + string.Join("\n", columns));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error showing columns:\n" + ex.Message);
            }
        }
    }
}
