using System;
using System.Collections.Generic;

namespace Database_C_.models
{
	[Serializable]  
	internal class TableRow
	{
		public List<string> Columns { get; set; }

		public TableRow(List<string> columns)
		{
			Columns = columns;
		}
	}
}
