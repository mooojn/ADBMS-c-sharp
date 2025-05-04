namespace Database_C_
{
	partial class DatabaseView
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
			this.label2 = new System.Windows.Forms.Label();
			this.tableComboBox = new System.Windows.Forms.ComboBox();
			this.button2 = new System.Windows.Forms.Button();
			this.tableData = new System.Windows.Forms.DataGridView();
			this.button1 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.queryBox = new System.Windows.Forms.TextBox();
			this.queryPanel = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.tableData)).BeginInit();
			this.queryPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(156, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(128, 25);
			this.label2.TabIndex = 7;
			this.label2.Text = "Table Name";
			// 
			// tableComboBox
			// 
			this.tableComboBox.FormattingEnabled = true;
			this.tableComboBox.Location = new System.Drawing.Point(161, 96);
			this.tableComboBox.Name = "tableComboBox";
			this.tableComboBox.Size = new System.Drawing.Size(282, 33);
			this.tableComboBox.TabIndex = 6;
			this.tableComboBox.SelectedIndexChanged += new System.EventHandler(this.tableComboBox_SelectedIndexChanged);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(486, 83);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(181, 57);
			this.button2.TabIndex = 8;
			this.button2.Text = "Load";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// tableData
			// 
			this.tableData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.tableData.Location = new System.Drawing.Point(12, 299);
			this.tableData.Name = "tableData";
			this.tableData.RowHeadersWidth = 82;
			this.tableData.RowTemplate.Height = 33;
			this.tableData.Size = new System.Drawing.Size(1497, 488);
			this.tableData.TabIndex = 9;
			this.tableData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableData_CellContentClick);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(679, 83);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(181, 57);
			this.button1.TabIndex = 10;
			this.button1.Text = "Save";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.saveBtn_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(877, 83);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(181, 57);
			this.button3.TabIndex = 11;
			this.button3.Text = "Delete";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.deleteBtn_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(325, 37);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(181, 57);
			this.button4.TabIndex = 12;
			this.button4.Text = "Query";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.executeQueryBtn_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 25);
			this.label1.TabIndex = 14;
			this.label1.Text = "Query";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// queryBox
			// 
			this.queryBox.Location = new System.Drawing.Point(10, 50);
			this.queryBox.Name = "queryBox";
			this.queryBox.Size = new System.Drawing.Size(272, 31);
			this.queryBox.TabIndex = 13;
			// 
			// queryPanel
			// 
			this.queryPanel.Controls.Add(this.queryBox);
			this.queryPanel.Controls.Add(this.button4);
			this.queryPanel.Controls.Add(this.label1);
			this.queryPanel.Location = new System.Drawing.Point(161, 159);
			this.queryPanel.Name = "queryPanel";
			this.queryPanel.Size = new System.Drawing.Size(530, 134);
			this.queryPanel.TabIndex = 15;
			this.queryPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// DatabaseView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1764, 799);
			this.Controls.Add(this.queryPanel);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.tableData);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tableComboBox);
			this.Name = "DatabaseView";
			this.Text = "DatabaseView";
			this.Load += new System.EventHandler(this.DatabaseView_Load);
			((System.ComponentModel.ISupportInitialize)(this.tableData)).EndInit();
			this.queryPanel.ResumeLayout(false);
			this.queryPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox tableComboBox;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.DataGridView tableData;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox queryBox;
		private System.Windows.Forms.Panel queryPanel;
	}
}