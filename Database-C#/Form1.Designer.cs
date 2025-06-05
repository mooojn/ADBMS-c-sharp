namespace Database_C_
{
	partial class Form1
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
			this.dbNameBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dbComboBox = new System.Windows.Forms.ComboBox();
			this.isUseBin = new System.Windows.Forms.CheckBox();
			this.panelCSVControls = new System.Windows.Forms.Panel();
			this.button2 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.queryBox = new System.Windows.Forms.TextBox();
			this.button5 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.button10 = new System.Windows.Forms.Button();
			this.button11 = new System.Windows.Forms.Button();
			this.panelCSVControls.SuspendLayout();
			this.SuspendLayout();
			// 
			// dbNameBox
			// 
			this.dbNameBox.Location = new System.Drawing.Point(184, 112);
			this.dbNameBox.Margin = new System.Windows.Forms.Padding(4);
			this.dbNameBox.Name = "dbNameBox";
			this.dbNameBox.Size = new System.Drawing.Size(272, 31);
			this.dbNameBox.TabIndex = 0;
			this.dbNameBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(180, 67);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 25);
			this.label1.TabIndex = 1;
			this.label1.Text = "Name";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(180, 187);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(103, 25);
			this.label2.TabIndex = 5;
			this.label2.Text = "DB Name";
			// 
			// dbComboBox
			// 
			this.dbComboBox.FormattingEnabled = true;
			this.dbComboBox.Location = new System.Drawing.Point(184, 225);
			this.dbComboBox.Margin = new System.Windows.Forms.Padding(4);
			this.dbComboBox.Name = "dbComboBox";
			this.dbComboBox.Size = new System.Drawing.Size(272, 33);
			this.dbComboBox.TabIndex = 4;
			this.dbComboBox.SelectedIndexChanged += new System.EventHandler(this.dbComboBox_SelectedIndexChanged);
			// 
			// isUseBin
			// 
			this.isUseBin.AutoSize = true;
			this.isUseBin.Location = new System.Drawing.Point(504, 313);
			this.isUseBin.Margin = new System.Windows.Forms.Padding(4);
			this.isUseBin.Name = "isUseBin";
			this.isUseBin.Size = new System.Drawing.Size(149, 29);
			this.isUseBin.TabIndex = 7;
			this.isUseBin.Text = "Use Binary";
			this.isUseBin.UseVisualStyleBackColor = true;
			this.isUseBin.CheckedChanged += new System.EventHandler(this.isUseBin_CheckedChanged);
			// 
			// panelCSVControls
			// 
			this.panelCSVControls.Controls.Add(this.button2);
			this.panelCSVControls.Controls.Add(this.button7);
			this.panelCSVControls.Location = new System.Drawing.Point(136, 423);
			this.panelCSVControls.Margin = new System.Windows.Forms.Padding(4);
			this.panelCSVControls.Name = "panelCSVControls";
			this.panelCSVControls.Size = new System.Drawing.Size(580, 100);
			this.panelCSVControls.TabIndex = 10;
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.button2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.ForeColor = System.Drawing.Color.White;
			this.button2.Location = new System.Drawing.Point(354, 17);
			this.button2.Margin = new System.Windows.Forms.Padding(4);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(180, 58);
			this.button2.TabIndex = 15;
			this.button2.Text = "Transactions";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.transactions_Click);
			// 
			// button7
			// 
			this.button7.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.button7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button7.ForeColor = System.Drawing.Color.White;
			this.button7.Location = new System.Drawing.Point(48, 17);
			this.button7.Margin = new System.Windows.Forms.Padding(4);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(180, 58);
			this.button7.TabIndex = 16;
			this.button7.Text = "Create Index";
			this.button7.UseVisualStyleBackColor = false;
			this.button7.Click += new System.EventHandler(this.button5_Click);
			// 
			// button6
			// 
			this.button6.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.button6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button6.ForeColor = System.Drawing.Color.White;
			this.button6.Location = new System.Drawing.Point(490, 96);
			this.button6.Margin = new System.Windows.Forms.Padding(4);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(180, 58);
			this.button6.TabIndex = 12;
			this.button6.Text = "Create DB";
			this.button6.UseVisualStyleBackColor = false;
			this.button6.Click += new System.EventHandler(this.button1_Click);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.ForeColor = System.Drawing.Color.White;
			this.button1.Location = new System.Drawing.Point(490, 210);
			this.button1.Margin = new System.Windows.Forms.Padding(4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(180, 58);
			this.button1.TabIndex = 13;
			this.button1.Text = "Manage DB";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button3_Click);
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.button3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button3.ForeColor = System.Drawing.Color.White;
			this.button3.Location = new System.Drawing.Point(184, 296);
			this.button3.Margin = new System.Windows.Forms.Padding(4);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(180, 58);
			this.button3.TabIndex = 14;
			this.button3.Text = "Create Table";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new System.EventHandler(this.button2_Click);
			// 
			// button4
			// 
			this.button4.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.button4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button4.ForeColor = System.Drawing.Color.White;
			this.button4.Location = new System.Drawing.Point(184, 367);
			this.button4.Margin = new System.Windows.Forms.Padding(4);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(180, 58);
			this.button4.TabIndex = 17;
			this.button4.Text = "Upload CSV";
			this.button4.UseVisualStyleBackColor = false;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// queryBox
			// 
			this.queryBox.Location = new System.Drawing.Point(154, 602);
			this.queryBox.Margin = new System.Windows.Forms.Padding(4);
			this.queryBox.Name = "queryBox";
			this.queryBox.Size = new System.Drawing.Size(392, 31);
			this.queryBox.TabIndex = 18;
			this.queryBox.TextChanged += new System.EventHandler(this.queryBox_TextChanged);
			// 
			// button5
			// 
			this.button5.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.button5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button5.ForeColor = System.Drawing.Color.White;
			this.button5.Location = new System.Drawing.Point(638, 590);
			this.button5.Margin = new System.Windows.Forms.Padding(4);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(286, 58);
			this.button5.TabIndex = 19;
			this.button5.Text = "Execute Query";
			this.button5.UseVisualStyleBackColor = false;
			this.button5.Click += new System.EventHandler(this.button5_Click_1);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(148, 565);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(136, 25);
			this.label3.TabIndex = 20;
			this.label3.Text = "Query for DB";
			// 
			// button10
			// 
			this.button10.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.button10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button10.ForeColor = System.Drawing.Color.White;
			this.button10.Location = new System.Drawing.Point(695, 210);
			this.button10.Margin = new System.Windows.Forms.Padding(4);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(180, 58);
			this.button10.TabIndex = 24;
			this.button10.Text = "Restore";
			this.button10.UseVisualStyleBackColor = false;
			this.button10.Click += new System.EventHandler(this.button9_Click);
			// 
			// button11
			// 
			this.button11.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.button11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button11.ForeColor = System.Drawing.Color.White;
			this.button11.Location = new System.Drawing.Point(695, 96);
			this.button11.Margin = new System.Windows.Forms.Padding(4);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(180, 58);
			this.button11.TabIndex = 23;
			this.button11.Text = "Backup";
			this.button11.UseVisualStyleBackColor = false;
			this.button11.Click += new System.EventHandler(this.button8_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1182, 792);
			this.Controls.Add(this.button10);
			this.Controls.Add(this.button11);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.queryBox);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.panelCSVControls);
			this.Controls.Add(this.isUseBin);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dbComboBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dbNameBox);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.panelCSVControls.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox dbNameBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox dbComboBox;
		private System.Windows.Forms.CheckBox isUseBin;
		private System.Windows.Forms.Panel panelCSVControls;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox queryBox;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Button button11;
	}
}

