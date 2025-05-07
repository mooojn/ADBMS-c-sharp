namespace Database_C_
{
	partial class Ui_elements
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
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.dbNameBox = new System.Windows.Forms.TextBox();
			this.isUseBin = new System.Windows.Forms.CheckBox();
			this.dbComboBox = new System.Windows.Forms.ComboBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.ForestGreen;
			this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.ForeColor = System.Drawing.Color.White;
			this.button1.Location = new System.Drawing.Point(465, 212);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(181, 57);
			this.button1.TabIndex = 5;
			this.button1.Text = "Green";
			this.button1.UseVisualStyleBackColor = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(127, 47);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 25);
			this.label1.TabIndex = 4;
			this.label1.Text = "Labels";
			// 
			// dbNameBox
			// 
			this.dbNameBox.Location = new System.Drawing.Point(132, 91);
			this.dbNameBox.Name = "dbNameBox";
			this.dbNameBox.Size = new System.Drawing.Size(272, 31);
			this.dbNameBox.TabIndex = 3;
			// 
			// isUseBin
			// 
			this.isUseBin.AutoSize = true;
			this.isUseBin.Location = new System.Drawing.Point(132, 165);
			this.isUseBin.Name = "isUseBin";
			this.isUseBin.Size = new System.Drawing.Size(142, 29);
			this.isUseBin.TabIndex = 8;
			this.isUseBin.Text = "CheckBox";
			this.isUseBin.UseVisualStyleBackColor = true;
			// 
			// dbComboBox
			// 
			this.dbComboBox.FormattingEnabled = true;
			this.dbComboBox.Location = new System.Drawing.Point(132, 225);
			this.dbComboBox.Name = "dbComboBox";
			this.dbComboBox.Size = new System.Drawing.Size(272, 33);
			this.dbComboBox.TabIndex = 9;
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.OrangeRed;
			this.button2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.ForeColor = System.Drawing.Color.White;
			this.button2.Location = new System.Drawing.Point(465, 302);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(181, 57);
			this.button2.TabIndex = 10;
			this.button2.Text = "Red";
			this.button2.UseVisualStyleBackColor = false;
			// 
			// button6
			// 
			this.button6.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.button6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button6.ForeColor = System.Drawing.Color.White;
			this.button6.Location = new System.Drawing.Point(465, 125);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(181, 57);
			this.button6.TabIndex = 13;
			this.button6.Text = "Basic";
			this.button6.UseVisualStyleBackColor = false;
			// 
			// Ui_elements
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.dbComboBox);
			this.Controls.Add(this.isUseBin);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dbNameBox);
			this.Name = "Ui_elements";
			this.Text = "Ui_elements";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox dbNameBox;
		private System.Windows.Forms.CheckBox isUseBin;
		private System.Windows.Forms.ComboBox dbComboBox;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button6;
	}
}