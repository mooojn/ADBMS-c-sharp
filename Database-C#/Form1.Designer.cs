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
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.dbComboBox = new System.Windows.Forms.ComboBox();
			this.button3 = new System.Windows.Forms.Button();
			this.isUseBin = new System.Windows.Forms.CheckBox();
			this.button4 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// dbNameBox
			// 
			this.dbNameBox.Location = new System.Drawing.Point(198, 171);
			this.dbNameBox.Name = "dbNameBox";
			this.dbNameBox.Size = new System.Drawing.Size(272, 31);
			this.dbNameBox.TabIndex = 0;
			this.dbNameBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(193, 127);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 25);
			this.label1.TabIndex = 1;
			this.label1.Text = "Name";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(504, 158);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(181, 57);
			this.button1.TabIndex = 2;
			this.button1.Text = "Create DB";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(198, 358);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(181, 57);
			this.button2.TabIndex = 3;
			this.button2.Text = "Create Table";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(193, 247);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(103, 25);
			this.label2.TabIndex = 5;
			this.label2.Text = "DB Name";
			// 
			// dbComboBox
			// 
			this.dbComboBox.FormattingEnabled = true;
			this.dbComboBox.Location = new System.Drawing.Point(198, 285);
			this.dbComboBox.Name = "dbComboBox";
			this.dbComboBox.Size = new System.Drawing.Size(282, 33);
			this.dbComboBox.TabIndex = 4;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(504, 272);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(181, 57);
			this.button3.TabIndex = 6;
			this.button3.Text = "Manage DB";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// isUseBin
			// 
			this.isUseBin.AutoSize = true;
			this.isUseBin.Location = new System.Drawing.Point(519, 373);
			this.isUseBin.Name = "isUseBin";
			this.isUseBin.Size = new System.Drawing.Size(149, 29);
			this.isUseBin.TabIndex = 7;
			this.isUseBin.Text = "Use Binary";
			this.isUseBin.UseVisualStyleBackColor = true;
			this.isUseBin.CheckedChanged += new System.EventHandler(this.isUseBin_CheckedChanged);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(198, 451);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(181, 57);
			this.button4.TabIndex = 8;
			this.button4.Text = "Transactions";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.transactions_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(821, 560);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.isUseBin);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dbComboBox);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dbNameBox);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox dbNameBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox dbComboBox;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.CheckBox isUseBin;
		private System.Windows.Forms.Button button4;
	}
}

