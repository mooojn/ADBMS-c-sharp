namespace Database_C_
{
	partial class TableView
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.tableName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.columnsPanel = new System.Windows.Forms.Panel();
            this.addCol = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.createTable = new System.Windows.Forms.Button();
            this.tablequerybtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.querytext = new System.Windows.Forms.TextBox();
            this.columnQuerybtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.columnQuery = new System.Windows.Forms.TextBox();
            this.columnsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableName
            // 
            this.tableName.Location = new System.Drawing.Point(400, 59);
            this.tableName.Margin = new System.Windows.Forms.Padding(2);
            this.tableName.Name = "tableName";
            this.tableName.Size = new System.Drawing.Size(143, 20);
            this.tableName.TabIndex = 3;
            this.tableName.TextChanged += new System.EventHandler(this.tableName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(397, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Table Name";
            // 
            // columnsPanel
            // 
            this.columnsPanel.Controls.Add(this.addCol);
            this.columnsPanel.Controls.Add(this.textBox1);
            this.columnsPanel.Controls.Add(this.label2);
            this.columnsPanel.Location = new System.Drawing.Point(27, 17);
            this.columnsPanel.Margin = new System.Windows.Forms.Padding(2);
            this.columnsPanel.Name = "columnsPanel";
            this.columnsPanel.Size = new System.Drawing.Size(353, 486);
            this.columnsPanel.TabIndex = 6;
            this.columnsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.columnsPanel_Paint);
            // 
            // addCol
            // 
            this.addCol.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.addCol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCol.ForeColor = System.Drawing.Color.White;
            this.addCol.Location = new System.Drawing.Point(80, 64);
            this.addCol.Margin = new System.Windows.Forms.Padding(2);
            this.addCol.Name = "addCol";
            this.addCol.Size = new System.Drawing.Size(90, 30);
            this.addCol.TabIndex = 14;
            this.addCol.Text = "Add Column";
            this.addCol.UseVisualStyleBackColor = false;
            this.addCol.Click += new System.EventHandler(this.addColumnButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(80, 10);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(149, 20);
            this.textBox1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Primary Key*";
            // 
            // createTable
            // 
            this.createTable.BackColor = System.Drawing.Color.ForestGreen;
            this.createTable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createTable.ForeColor = System.Drawing.Color.White;
            this.createTable.Location = new System.Drawing.Point(411, 89);
            this.createTable.Margin = new System.Windows.Forms.Padding(2);
            this.createTable.Name = "createTable";
            this.createTable.Size = new System.Drawing.Size(90, 30);
            this.createTable.TabIndex = 8;
            this.createTable.Text = "Create";
            this.createTable.UseVisualStyleBackColor = false;
            this.createTable.Click += new System.EventHandler(this.createTable_Click);
            // 
            // tablequerybtn
            // 
            this.tablequerybtn.BackColor = System.Drawing.Color.ForestGreen;
            this.tablequerybtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tablequerybtn.ForeColor = System.Drawing.Color.White;
            this.tablequerybtn.Location = new System.Drawing.Point(411, 194);
            this.tablequerybtn.Margin = new System.Windows.Forms.Padding(2);
            this.tablequerybtn.Name = "tablequerybtn";
            this.tablequerybtn.Size = new System.Drawing.Size(90, 30);
            this.tablequerybtn.TabIndex = 11;
            this.tablequerybtn.Text = "Execute";
            this.tablequerybtn.UseVisualStyleBackColor = false;
            this.tablequerybtn.Click += new System.EventHandler(this.tablequerybtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(397, 144);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Table Query";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // querytext
            // 
            this.querytext.Location = new System.Drawing.Point(400, 164);
            this.querytext.Margin = new System.Windows.Forms.Padding(2);
            this.querytext.Name = "querytext";
            this.querytext.Size = new System.Drawing.Size(143, 20);
            this.querytext.TabIndex = 9;
            this.querytext.TextChanged += new System.EventHandler(this.querytext_TextChanged);
            // 
            // columnQuerybtn
            // 
            this.columnQuerybtn.BackColor = System.Drawing.Color.ForestGreen;
            this.columnQuerybtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnQuerybtn.ForeColor = System.Drawing.Color.White;
            this.columnQuerybtn.Location = new System.Drawing.Point(411, 304);
            this.columnQuerybtn.Margin = new System.Windows.Forms.Padding(2);
            this.columnQuerybtn.Name = "columnQuerybtn";
            this.columnQuerybtn.Size = new System.Drawing.Size(90, 30);
            this.columnQuerybtn.TabIndex = 14;
            this.columnQuerybtn.Text = "Execute";
            this.columnQuerybtn.UseVisualStyleBackColor = false;
            this.columnQuerybtn.Click += new System.EventHandler(this.columnQuerybtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(397, 254);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Columns Query";
            // 
            // columnQuery
            // 
            this.columnQuery.Location = new System.Drawing.Point(400, 274);
            this.columnQuery.Margin = new System.Windows.Forms.Padding(2);
            this.columnQuery.Name = "columnQuery";
            this.columnQuery.Size = new System.Drawing.Size(143, 20);
            this.columnQuery.TabIndex = 12;
            this.columnQuery.TextChanged += new System.EventHandler(this.columnQuery_TextChanged);
            // 
            // TableView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 515);
            this.Controls.Add(this.columnQuerybtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.columnQuery);
            this.Controls.Add(this.tablequerybtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.querytext);
            this.Controls.Add(this.createTable);
            this.Controls.Add(this.columnsPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableName);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TableView";
            this.Text = "Table";
            this.Load += new System.EventHandler(this.Table_Load);
            this.columnsPanel.ResumeLayout(false);
            this.columnsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox tableName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel columnsPanel;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button createTable;
		private System.Windows.Forms.Button addCol;
        private System.Windows.Forms.Button tablequerybtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox querytext;
        private System.Windows.Forms.Button columnQuerybtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox columnQuery;
    }
}