namespace TIcTAcToe_Адаптив
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
			this.components = new System.ComponentModel.Container();
			this.panel = new System.Windows.Forms.Panel();
			this.Level1 = new System.Windows.Forms.RadioButton();
			this.Level2 = new System.Windows.Forms.RadioButton();
			this.Level3 = new System.Windows.Forms.RadioButton();
			this.TIMER = new System.Windows.Forms.Timer(this.components);
			this.panel.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel
			// 
			this.panel.BackColor = System.Drawing.SystemColors.ControlLight;
			this.panel.Controls.Add(this.Level3);
			this.panel.Controls.Add(this.Level2);
			this.panel.Controls.Add(this.Level1);
			this.panel.Location = new System.Drawing.Point(637, 114);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(122, 196);
			this.panel.TabIndex = 0;
			// 
			// Level1
			// 
			this.Level1.AutoSize = true;
			this.Level1.Location = new System.Drawing.Point(30, 15);
			this.Level1.Name = "Level1";
			this.Level1.Size = new System.Drawing.Size(71, 20);
			this.Level1.TabIndex = 0;
			this.Level1.TabStop = true;
			this.Level1.Text = "Level 1";
			this.Level1.UseVisualStyleBackColor = true;
			this.Level1.CheckedChanged += new System.EventHandler(this.Level1_CheckedChanged);
			// 
			// Level2
			// 
			this.Level2.AutoSize = true;
			this.Level2.Location = new System.Drawing.Point(30, 86);
			this.Level2.Name = "Level2";
			this.Level2.Size = new System.Drawing.Size(71, 20);
			this.Level2.TabIndex = 1;
			this.Level2.TabStop = true;
			this.Level2.Text = "Level 2";
			this.Level2.UseVisualStyleBackColor = true;
			// 
			// Level3
			// 
			this.Level3.AutoSize = true;
			this.Level3.Location = new System.Drawing.Point(30, 158);
			this.Level3.Name = "Level3";
			this.Level3.Size = new System.Drawing.Size(71, 20);
			this.Level3.TabIndex = 2;
			this.Level3.TabStop = true;
			this.Level3.Text = "Level 3";
			this.Level3.UseVisualStyleBackColor = true;
			// 
			// TIMER
			// 
			this.TIMER.Tick += new System.EventHandler(this.TIMER_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.panel);
			this.Name = "Form1";
			this.Text = "Form1";
			this.panel.ResumeLayout(false);
			this.panel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.RadioButton Level3;
		private System.Windows.Forms.RadioButton Level2;
		private System.Windows.Forms.RadioButton Level1;
		private System.Windows.Forms.Timer TIMER;
	}
}

