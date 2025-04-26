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
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			loadDbInBox();
		}
		private void loadDbInBox()
		{
			string basePath = Vars.databasePath;
			dbComboBox.Items.Clear(); 
			if (Directory.Exists(basePath))
			{
				string[] folders = Directory.GetDirectories(basePath);

				foreach (string folder in folders)
				{
					string folderName = System.IO.Path.GetFileName(folder);
					dbComboBox.Items.Add(folderName);
				}

				if (dbComboBox.Items.Count > 0)
				{
					dbComboBox.SelectedIndex = 0;
				}
			}
			else
			{
				MessageBox.Show("Base path does not exist.");
			}
		}
		private void button1_Click(object sender, EventArgs e)
		{
			string db = dbNameBox.Text; 
			string basePath = Vars.databasePath; 

			string fullPath = System.IO.Path.Combine(basePath, db);

			if (!Directory.Exists(fullPath))
			{
				Directory.CreateDirectory(fullPath);
				MessageBox.Show("Database created.");
			}
			else
			{
				MessageBox.Show("Database already exists.");
			}
			loadDbInBox();
		}


		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (dbComboBox.SelectedItem == null)
			{
				MessageBox.Show("Please select a database first.");
				return;
			}

			SelectDB();

			Form table = new TableView(); 
			table.Show();
		}

		private void SelectDB()
		{
			Vars.selectedDb = dbComboBox.SelectedItem.ToString();
		}
		private void button3_Click(object sender, EventArgs e)
		{
			SelectDB();

			Form db = new DatabaseView();
			db.Show();
		}

		private void isUseBin_CheckedChanged(object sender, EventArgs e)
		{
			if (isUseBin.Checked)
				Handler.isCSV = false;
			else
				Handler.isCSV = true;
		}
		private void transactions_Click(object sender, EventArgs e)
		{
			SelectDB();

			Form form = new TransactionsView();
			form.Show();
		}
	}
}
