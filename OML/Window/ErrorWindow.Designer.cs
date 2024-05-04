using System.Drawing;

namespace OML.Window
{
	partial class ErrorWindow
	{
		private System.ComponentModel.IContainer components = null;
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
			this.log_textbox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// log_textbox
			// 
			this.log_textbox.Location = new System.Drawing.Point(0, 100);
			this.log_textbox.Margin = new System.Windows.Forms.Padding(0);
			this.log_textbox.Multiline = true;
			this.log_textbox.Name = "log_textbox";
			this.log_textbox.Size = new System.Drawing.Size(485, 380);
			this.log_textbox.TabIndex = 0;
			this.log_textbox.Text = "Not Error Log";
			this.log_textbox.WordWrap = false;
			this.log_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;

			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10F);
			this.label1.Location = new System.Drawing.Point(113, 43);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(189, 14);
			this.label1.TabIndex = 1;
			this.label1.Text = "A fatal error has occurred";
			// 
			// ErrorWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(484, 511);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.log_textbox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.Name = "ErrorWindow";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private System.Windows.Forms.TextBox log_textbox;
		private System.Windows.Forms.Label label1;
	}
}
