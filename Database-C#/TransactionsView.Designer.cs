namespace Database_C_
{
	partial class TransactionsView
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
			this.dataTable = new System.Windows.Forms.DataGridView();
			this.tableComboBox = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.rollbackBtn = new System.Windows.Forms.Button();
			this.commitBtn = new System.Windows.Forms.Button();
			this.startBtn = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataTable)).BeginInit();
			this.SuspendLayout();
			// 
			// dataTable
			// 
			this.dataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataTable.Location = new System.Drawing.Point(-13, 302);
			this.dataTable.Name = "dataTable";
			this.dataTable.RowHeadersWidth = 82;
			this.dataTable.RowTemplate.Height = 33;
			this.dataTable.Size = new System.Drawing.Size(1347, 420);
			this.dataTable.TabIndex = 9;
			this.dataTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataTable_CellContentClick);
			// 
			// tableComboBox
			// 
			this.tableComboBox.FormattingEnabled = true;
			this.tableComboBox.Location = new System.Drawing.Point(122, 106);
			this.tableComboBox.Name = "tableComboBox";
			this.tableComboBox.Size = new System.Drawing.Size(257, 33);
			this.tableComboBox.TabIndex = 10;
			this.tableComboBox.SelectedIndexChanged += new System.EventHandler(this.tableComboBox_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(117, 69);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(128, 25);
			this.label2.TabIndex = 13;
			this.label2.Text = "Table Name";
			// 
			// rollbackBtn
			// 
			this.rollbackBtn.BackColor = System.Drawing.Color.OrangeRed;
			this.rollbackBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rollbackBtn.ForeColor = System.Drawing.Color.White;
			this.rollbackBtn.Location = new System.Drawing.Point(894, 205);
			this.rollbackBtn.Name = "rollbackBtn";
			this.rollbackBtn.Size = new System.Drawing.Size(181, 57);
			this.rollbackBtn.TabIndex = 15;
			this.rollbackBtn.Text = "Rollback";
			this.rollbackBtn.UseVisualStyleBackColor = false;
			this.rollbackBtn.Click += new System.EventHandler(this.rollbackButton_Click);
			// 
			// commitBtn
			// 
			this.commitBtn.BackColor = System.Drawing.Color.ForestGreen;
			this.commitBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.commitBtn.ForeColor = System.Drawing.Color.White;
			this.commitBtn.Location = new System.Drawing.Point(666, 205);
			this.commitBtn.Name = "commitBtn";
			this.commitBtn.Size = new System.Drawing.Size(181, 57);
			this.commitBtn.TabIndex = 16;
			this.commitBtn.Text = "Commit";
			this.commitBtn.UseVisualStyleBackColor = false;
			this.commitBtn.Click += new System.EventHandler(this.commitButton_Click);
			// 
			// startBtn
			// 
			this.startBtn.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.startBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.startBtn.ForeColor = System.Drawing.Color.White;
			this.startBtn.Location = new System.Drawing.Point(436, 205);
			this.startBtn.Name = "startBtn";
			this.startBtn.Size = new System.Drawing.Size(181, 57);
			this.startBtn.TabIndex = 17;
			this.startBtn.Text = "Start";
			this.startBtn.UseVisualStyleBackColor = false;
			this.startBtn.Click += new System.EventHandler(this.startTransaction_Click);
			// 
			// TransactionsView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1335, 707);
			this.Controls.Add(this.startBtn);
			this.Controls.Add(this.commitBtn);
			this.Controls.Add(this.rollbackBtn);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tableComboBox);
			this.Controls.Add(this.dataTable);
			this.Name = "TransactionsView";
			this.Text = "TransactionsView";
			this.Load += new System.EventHandler(this.TransactionsView_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataTable)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.DataGridView dataTable;
		private System.Windows.Forms.ComboBox tableComboBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button rollbackBtn;
		private System.Windows.Forms.Button commitBtn;
		private System.Windows.Forms.Button startBtn;
	}
}