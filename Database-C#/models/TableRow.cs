using System;
using System.Collections.Generic;

namespace Database_C_.models
{
	[Serializable]  // Mark the class as serializable
	internal class TableRow
	{
		public List<string> Columns { get; set; }

		public TableRow(List<string> columns)
		{
			Columns = columns;
		}
	}
}
