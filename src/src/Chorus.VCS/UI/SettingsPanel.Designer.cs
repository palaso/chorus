namespace Chorus.UI
{
	partial class SettingsPanel
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

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsPanel));
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			//
			// checkBox1
			//
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(13, 75);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(195, 17);
			this.checkBox1.TabIndex = 1;
			this.checkBox1.Text = "This is a protected master repository";
			this.checkBox1.UseVisualStyleBackColor = true;
			//
			// checkBox2
			//
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(13, 180);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
			this.checkBox2.Size = new System.Drawing.Size(233, 27);
			this.checkBox2.TabIndex = 1;
			this.checkBox2.Text = "Assert this user in case of incoming conflicts";
			this.checkBox2.UseVisualStyleBackColor = true;
			//
			// textBox2
			//
			this.textBox2.Location = new System.Drawing.Point(13, 256);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(239, 78);
			this.textBox2.TabIndex = 3;
			//
			// label1
			//
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 210);
			this.label1.Name = "label1";
			this.label1.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
			this.label1.Size = new System.Drawing.Size(295, 43);
			this.label1.TabIndex = 4;
			this.label1.Text = "Places to look for other repositories to sync with (one per line)";
			//
			// button1
			//
			this.button1.Location = new System.Drawing.Point(13, 412);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(253, 23);
			this.button1.TabIndex = 5;
			this.button1.Text = "Prepare USB Flash Drive to serve this repository";
			this.button1.UseVisualStyleBackColor = true;
			//
			// label2
			//
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 337);
			this.label2.Name = "label2";
			this.label2.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
			this.label2.Size = new System.Drawing.Size(467, 72);
			this.label2.TabIndex = 4;
			this.label2.Text = resources.GetString("label2.Text");
			//
			// tableLayoutPanel1
			//
			this.tableLayoutPanel1.AutoScroll = true;
			this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.checkBox1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.button1, 0, 7);
			this.tableLayoutPanel1.Controls.Add(this.checkBox2, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.textBox2, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 6);
			this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
			this.tableLayoutPanel1.RowCount = 8;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(505, 473);
			this.tableLayoutPanel1.TabIndex = 7;
			//
			// label3
			//
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 95);
			this.label3.Name = "label3";
			this.label3.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
			this.label3.Size = new System.Drawing.Size(479, 82);
			this.label3.TabIndex = 4;
			this.label3.Text = resources.GetString("label3.Text");
			//
			// label4
			//
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 10);
			this.label4.Name = "label4";
			this.label4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
			this.label4.Size = new System.Drawing.Size(476, 62);
			this.label4.TabIndex = 4;
			this.label4.Text = resources.GetString("label4.Text");
			//
			// SettingsPanel
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoScroll = true;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "SettingsPanel";
			this.Size = new System.Drawing.Size(505, 473);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
	}
}
