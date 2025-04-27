using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Database_C_.Utils
{
    internal static class IndexManager
    {
        // TableName -> ColumnCombo -> (Key -> List of Row Indices)
        public static Dictionary<string, Dictionary<string, Dictionary<string, List<int>>>> TableIndexes
            = new Dictionary<string, Dictionary<string, Dictionary<string, List<int>>>>();

        public static void BuildIndex(string tableName, string[] headers, List<string[]> rows)
        {
            if (TableIndexes.ContainsKey(tableName))
                TableIndexes.Remove(tableName);

            var tableIndex = new Dictionary<string, Dictionary<string, List<int>>>();

            // Build single-column indexes
            for (int col = 0; col < headers.Length; col++)
            {
                string columnName = headers[col];
                tableIndex[columnName] = new Dictionary<string, List<int>>();

                for (int rowIndex = 0; rowIndex < rows.Count; rowIndex++)
                {
                    string value = rows[rowIndex][col];
                    if (!tableIndex[columnName].ContainsKey(value))
                        tableIndex[columnName][value] = new List<int>();

                    tableIndex[columnName][value].Add(rowIndex);
                }
            }

            // Build secondary (multi-column) indexes
            if (headers.Length >= 2)
            {
                for (int i = 0; i < headers.Length; i++)
                {
                    for (int j = i + 1; j < headers.Length; j++)
                    {
                        string comboKey = headers[i] + "+" + headers[j];
                        tableIndex[comboKey] = new Dictionary<string, List<int>>();

                        for (int rowIndex = 0; rowIndex < rows.Count; rowIndex++)
                        {
                            string value1 = rows[rowIndex][i];
                            string value2 = rows[rowIndex][j];
                            string combinedValue = value1 + "|" + value2; // separator

                            if (!tableIndex[comboKey].ContainsKey(combinedValue))
                                tableIndex[comboKey][combinedValue] = new List<int>();

                            tableIndex[comboKey][combinedValue].Add(rowIndex);
                        }
                    }
                }
            }

            TableIndexes[tableName] = tableIndex;
        }

        public static List<int> FindMatchingRows(string tableName, List<(string column, string value)> conditions)
        {
            if (!TableIndexes.ContainsKey(tableName))
                return new List<int>();

            var tableIndex = TableIndexes[tableName];

            if (conditions.Count == 1)
            {
                var (col, val) = conditions[0];
                if (tableIndex.ContainsKey(col) && tableIndex[col].ContainsKey(val))
                    return tableIndex[col][val];
            }
            else if (conditions.Count == 2)
            {
                string comboKey = conditions[0].column + "+" + conditions[1].column;
                string comboValue = conditions[0].value + "|" + conditions[1].value;

                if (tableIndex.ContainsKey(comboKey) && tableIndex[comboKey].ContainsKey(comboValue))
                    return tableIndex[comboKey][comboValue];
            }

            return new List<int>();
        }

        public static void RemoveTableIndex(string tableName)
        {
            if (TableIndexes.ContainsKey(tableName))
                TableIndexes.Remove(tableName);
        }

        public static void UpdateIndexAfterInsert(string tableName, string[] newRow, int newRowIndex)
        {
            if (!TableIndexes.ContainsKey(tableName))
                return;

            var table = TableIndexes[tableName];

            foreach (var column in table.Keys)
            {
                if (column.Contains("+")) // secondary
                {
                    var parts = column.Split('+');
                    int idx1 = Array.IndexOf(parts, parts[0]);
                    int idx2 = Array.IndexOf(parts, parts[1]);

                    string value1 = newRow[idx1];
                    string value2 = newRow[idx2];
                    string comboValue = value1 + "|" + value2;

                    if (!table[column].ContainsKey(comboValue))
                        table[column][comboValue] = new List<int>();

                    table[column][comboValue].Add(newRowIndex);
                }
                else // single
                {
                    int idx = Array.IndexOf(newRow, column);
                    if (idx == -1) continue;
                    string value = newRow[idx];

                    if (!table[column].ContainsKey(value))
                        table[column][value] = new List<int>();

                    table[column][value].Add(newRowIndex);
                }
            }
        }
    }
}
