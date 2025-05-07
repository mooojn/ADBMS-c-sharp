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
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.createTable = new System.Windows.Forms.Button();
			this.addCol = new System.Windows.Forms.Button();
			this.columnsPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableName
			// 
			this.tableName.Location = new System.Drawing.Point(799, 113);
			this.tableName.Name = "tableName";
			this.tableName.Size = new System.Drawing.Size(282, 31);
			this.tableName.TabIndex = 3;
			this.tableName.TextChanged += new System.EventHandler(this.tableName_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(794, 75);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 25);
			this.label1.TabIndex = 4;
			this.label1.Text = "Table Name";
			// 
			// columnsPanel
			// 
			this.columnsPanel.Controls.Add(this.addCol);
			this.columnsPanel.Controls.Add(this.textBox1);
			this.columnsPanel.Controls.Add(this.label2);
			this.columnsPanel.Location = new System.Drawing.Point(54, 33);
			this.columnsPanel.Name = "columnsPanel";
			this.columnsPanel.Size = new System.Drawing.Size(706, 934);
			this.columnsPanel.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(0, 21);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(136, 25);
			this.label2.TabIndex = 8;
			this.label2.Text = "Primary Key*";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(161, 19);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(294, 31);
			this.textBox1.TabIndex = 8;
			// 
			// createTable
			// 
			this.createTable.BackColor = System.Drawing.Color.ForestGreen;
			this.createTable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.createTable.ForeColor = System.Drawing.Color.White;
			this.createTable.Location = new System.Drawing.Point(822, 171);
			this.createTable.Name = "createTable";
			this.createTable.Size = new System.Drawing.Size(181, 57);
			this.createTable.TabIndex = 8;
			this.createTable.Text = "Create";
			this.createTable.UseVisualStyleBackColor = false;
			this.createTable.Click += new System.EventHandler(this.createTable_Click);
			// 
			// addCol
			// 
			this.addCol.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.addCol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.addCol.ForeColor = System.Drawing.Color.White;
			this.addCol.Location = new System.Drawing.Point(161, 123);
			this.addCol.Name = "addCol";
			this.addCol.Size = new System.Drawing.Size(181, 57);
			this.addCol.TabIndex = 14;
			this.addCol.Text = "Add Column";
			this.addCol.UseVisualStyleBackColor = false;
			this.addCol.Click += new System.EventHandler(this.addColumnButton_Click);
			// 
			// TableView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1563, 991);
			this.Controls.Add(this.createTable);
			this.Controls.Add(this.columnsPanel);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tableName);
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
	}
}