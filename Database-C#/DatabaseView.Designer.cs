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
			((System.ComponentModel.ISupportInitialize)(this.tableData)).BeginInit();
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
			this.button1.Location = new System.Drawing.Point(486, 161);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(181, 57);
			this.button1.TabIndex = 10;
			this.button1.Text = "Save";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.saveBtn_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(690, 161);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(181, 57);
			this.button3.TabIndex = 11;
			this.button3.Text = "Delete";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.deleteBtn_Click);
			// 
			// DatabaseView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1764, 799);
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
	}
}