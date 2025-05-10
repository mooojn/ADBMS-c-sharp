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
			this.tableData = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.queryBox = new System.Windows.Forms.TextBox();
			this.queryPanel = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.timeLabel = new System.Windows.Forms.Label();
			this.button6 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.queryHistoryBox = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
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
			// tableData
			// 
			this.tableData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.tableData.Location = new System.Drawing.Point(-21, 370);
			this.tableData.Name = "tableData";
			this.tableData.RowHeadersWidth = 82;
			this.tableData.RowTemplate.Height = 33;
			this.tableData.Size = new System.Drawing.Size(1530, 578);
			this.tableData.TabIndex = 9;
			this.tableData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableData_CellContentClick);
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
			this.queryPanel.Controls.Add(this.label3);
			this.queryPanel.Controls.Add(this.queryHistoryBox);
			this.queryPanel.Controls.Add(this.button1);
			this.queryPanel.Controls.Add(this.timeLabel);
			this.queryPanel.Controls.Add(this.queryBox);
			this.queryPanel.Controls.Add(this.label1);
			this.queryPanel.Location = new System.Drawing.Point(161, 159);
			this.queryPanel.Name = "queryPanel";
			this.queryPanel.Size = new System.Drawing.Size(710, 181);
			this.queryPanel.TabIndex = 15;
			this.queryPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.ForeColor = System.Drawing.Color.White;
			this.button1.Location = new System.Drawing.Point(325, 35);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(181, 57);
			this.button1.TabIndex = 19;
			this.button1.Text = "Query";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.executeQueryBtn_Click);
			// 
			// timeLabel
			// 
			this.timeLabel.AutoSize = true;
			this.timeLabel.ForeColor = System.Drawing.Color.DodgerBlue;
			this.timeLabel.Location = new System.Drawing.Point(538, 53);
			this.timeLabel.Name = "timeLabel";
			this.timeLabel.Size = new System.Drawing.Size(52, 25);
			this.timeLabel.TabIndex = 15;
			this.timeLabel.Text = "time";
			this.timeLabel.Click += new System.EventHandler(this.timeLabel_Click);
			// 
			// button6
			// 
			this.button6.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.button6.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button6.ForeColor = System.Drawing.Color.White;
			this.button6.Location = new System.Drawing.Point(486, 83);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(181, 57);
			this.button6.TabIndex = 18;
			this.button6.Text = "Load";
			this.button6.UseVisualStyleBackColor = false;
			this.button6.Click += new System.EventHandler(this.button2_Click);
			// 
			// button5
			// 
			this.button5.BackColor = System.Drawing.Color.OrangeRed;
			this.button5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button5.ForeColor = System.Drawing.Color.White;
			this.button5.Location = new System.Drawing.Point(893, 81);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(181, 57);
			this.button5.TabIndex = 17;
			this.button5.Text = "Delete";
			this.button5.UseVisualStyleBackColor = false;
			this.button5.Click += new System.EventHandler(this.deleteBtn_Click);
			// 
			// button7
			// 
			this.button7.BackColor = System.Drawing.Color.ForestGreen;
			this.button7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button7.ForeColor = System.Drawing.Color.White;
			this.button7.Location = new System.Drawing.Point(690, 83);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(181, 57);
			this.button7.TabIndex = 16;
			this.button7.Text = "Save";
			this.button7.UseVisualStyleBackColor = false;
			this.button7.Click += new System.EventHandler(this.saveBtn_Click);
			// 
			// queryHistoryBox
			// 
			this.queryHistoryBox.FormattingEnabled = true;
			this.queryHistoryBox.Location = new System.Drawing.Point(10, 130);
			this.queryHistoryBox.Name = "queryHistoryBox";
			this.queryHistoryBox.Size = new System.Drawing.Size(282, 33);
			this.queryHistoryBox.TabIndex = 19;
			this.queryHistoryBox.SelectedIndexChanged += new System.EventHandler(this.queryHistoryBox_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 93);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(177, 25);
			this.label3.TabIndex = 20;
			this.label3.Text = "Previous Queries";
			// 
			// DatabaseView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1764, 903);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.queryPanel);
			this.Controls.Add(this.tableData);
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
		private System.Windows.Forms.DataGridView tableData;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox queryBox;
		private System.Windows.Forms.Panel queryPanel;
		private System.Windows.Forms.Label timeLabel;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox queryHistoryBox;
		private System.Windows.Forms.Label label3;
	}
}