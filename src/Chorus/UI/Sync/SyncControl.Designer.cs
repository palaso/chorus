﻿namespace Chorus.UI.Sync
{
	partial class SyncControl
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SyncControl));
			this._tabControl = new System.Windows.Forms.TabControl();
			this._chooseTargetsTab = new System.Windows.Forms.TabPage();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this._syncTargets = new System.Windows.Forms.CheckedListBox();
			this._tasksTab = new System.Windows.Forms.TabPage();
			this._tasksListView = new System.Windows.Forms.ListView();
			this._logTab = new System.Windows.Forms.TabPage();
			this._logBox = new Chorus.UI.Misc.LogBox();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this._cancelButton = new System.Windows.Forms.Button();
			this._updateDisplayTimer = new System.Windows.Forms.Timer(this.components);
			this._closeButton = new System.Windows.Forms.Button();
			this._statusText = new System.Windows.Forms.Label();
			this._showCancelButtonTimer = new System.Windows.Forms.Timer(this.components);
			this._successIcon = new System.Windows.Forms.PictureBox();
			this._warningIcon = new System.Windows.Forms.PictureBox();
			this._sendReceiveButton = new System.Windows.Forms.Button();
			this._tabControl.SuspendLayout();
			this._chooseTargetsTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this._tasksTab.SuspendLayout();
			this._logTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._successIcon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._warningIcon)).BeginInit();
			this.SuspendLayout();
			//
			// _tabControl
			//
			this._tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this._tabControl.Controls.Add(this._chooseTargetsTab);
			this._tabControl.Controls.Add(this._tasksTab);
			this._tabControl.Controls.Add(this._logTab);
			this._tabControl.Location = new System.Drawing.Point(0, 53);
			this._tabControl.Name = "_tabControl";
			this._tabControl.SelectedIndex = 0;
			this._tabControl.Size = new System.Drawing.Size(486, 248);
			this._tabControl.TabIndex = 11;
			//
			// _chooseTargetsTab
			//
			this._chooseTargetsTab.Controls.Add(this.pictureBox2);
			this._chooseTargetsTab.Controls.Add(this.label1);
			this._chooseTargetsTab.Controls.Add(this._syncTargets);
			this._chooseTargetsTab.Location = new System.Drawing.Point(4, 22);
			this._chooseTargetsTab.Name = "_chooseTargetsTab";
			this._chooseTargetsTab.Size = new System.Drawing.Size(478, 222);
			this._chooseTargetsTab.TabIndex = 2;
			this._chooseTargetsTab.Text = "Choose Respositories";
			this._chooseTargetsTab.UseVisualStyleBackColor = true;
			//
			// pictureBox2
			//
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(5, 0);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(40, 36);
			this.pictureBox2.TabIndex = 10;
			this.pictureBox2.TabStop = false;
			//
			// label1
			//
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(48, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(321, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Attempt to Send/Receive with these people, devices, and servers:";
			//
			// _syncTargets
			//
			this._syncTargets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this._syncTargets.FormattingEnabled = true;
			this._syncTargets.Items.AddRange(new object[] {
			"USB Drive"});
			this._syncTargets.Location = new System.Drawing.Point(52, 45);
			this._syncTargets.MinimumSize = new System.Drawing.Size(105, 79);
			this._syncTargets.Name = "_syncTargets";
			this._syncTargets.Size = new System.Drawing.Size(311, 169);
			this._syncTargets.TabIndex = 6;
			this._syncTargets.VisibleChanged += new System.EventHandler(this.OnRepositoryChoicesVisibleChanged);
			this._syncTargets.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this._syncTargets_ItemCheck);
			//
			// _tasksTab
			//
			this._tasksTab.Controls.Add(this._tasksListView);
			this._tasksTab.Location = new System.Drawing.Point(4, 22);
			this._tasksTab.Name = "_tasksTab";
			this._tasksTab.Padding = new System.Windows.Forms.Padding(3);
			this._tasksTab.Size = new System.Drawing.Size(478, 222);
			this._tasksTab.TabIndex = 0;
			this._tasksTab.Text = "Tasks";
			this._tasksTab.UseVisualStyleBackColor = true;
			//
			// _tasksListView
			//
			this._tasksListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this._tasksListView.Location = new System.Drawing.Point(3, 3);
			this._tasksListView.Name = "_tasksListView";
			this._tasksListView.Size = new System.Drawing.Size(472, 216);
			this._tasksListView.TabIndex = 0;
			this._tasksListView.UseCompatibleStateImageBehavior = false;
			//
			// _logTab
			//
			this._logTab.Controls.Add(this._logBox);
			this._logTab.Location = new System.Drawing.Point(4, 22);
			this._logTab.Name = "_logTab";
			this._logTab.Padding = new System.Windows.Forms.Padding(3);
			this._logTab.Size = new System.Drawing.Size(478, 222);
			this._logTab.TabIndex = 1;
			this._logTab.Text = "Log";
			this._logTab.UseVisualStyleBackColor = true;
			this._logTab.Resize += new System.EventHandler(this._logTab_Resize);
			//
			// _logBox
			//
			this._logBox.BackColor = System.Drawing.Color.Transparent;
			this._logBox.CancelRequested = false;
			this._logBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this._logBox.GetDiagnosticsMethod = null;
			this._logBox.Location = new System.Drawing.Point(3, 3);
			this._logBox.Name = "_logBox";
			this._logBox.Size = new System.Drawing.Size(472, 216);
			this._logBox.TabIndex = 0;
			//
			// progressBar1
			//
			this.progressBar1.Location = new System.Drawing.Point(55, 30);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(302, 10);
			this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar1.TabIndex = 13;
			//
			// _cancelButton
			//
			this._cancelButton.BackColor = System.Drawing.SystemColors.ButtonFace;
			this._cancelButton.Location = new System.Drawing.Point(378, 30);
			this._cancelButton.Name = "_cancelButton";
			this._cancelButton.Size = new System.Drawing.Size(108, 23);
			this._cancelButton.TabIndex = 12;
			this._cancelButton.Text = "&Cancel";
			this._cancelButton.UseVisualStyleBackColor = false;
			this._cancelButton.Click += new System.EventHandler(this.OnCancelButton_Click);
			//
			// _updateDisplayTimer
			//
			this._updateDisplayTimer.Interval = 300;
			this._updateDisplayTimer.Tick += new System.EventHandler(this.OnUpdateDisplayTimerTick);
			//
			// _closeButton
			//
			this._closeButton.BackColor = System.Drawing.SystemColors.ButtonFace;
			this._closeButton.Location = new System.Drawing.Point(259, 30);
			this._closeButton.Name = "_closeButton";
			this._closeButton.Size = new System.Drawing.Size(108, 31);
			this._closeButton.TabIndex = 17;
			this._closeButton.Text = "&Close";
			this._closeButton.UseVisualStyleBackColor = false;
			this._closeButton.Click += new System.EventHandler(this.OnCloseButton_Click);
			//
			// _statusText
			//
			this._statusText.AutoSize = true;
			this._statusText.Location = new System.Drawing.Point(53, 2);
			this._statusText.MaximumSize = new System.Drawing.Size(250, 26);
			this._statusText.Name = "_statusText";
			this._statusText.Size = new System.Drawing.Size(248, 26);
			this._statusText.TabIndex = 16;
			this._statusText.Text = "This is very long right now to help me in positioning it.";
			//
			// _showCancelButtonTimer
			//
			this._showCancelButtonTimer.Enabled = true;
			this._showCancelButtonTimer.Interval = 1000;
			this._showCancelButtonTimer.Tick += new System.EventHandler(this._showCancelButtonTimer_Tick);
			//
			// _successIcon
			//
			this._successIcon.Image = ((System.Drawing.Image)(resources.GetObject("_successIcon.Image")));
			this._successIcon.Location = new System.Drawing.Point(10, 5);
			this._successIcon.Name = "_successIcon";
			this._successIcon.Size = new System.Drawing.Size(32, 30);
			this._successIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this._successIcon.TabIndex = 15;
			this._successIcon.TabStop = false;
			//
			// _warningIcon
			//
			this._warningIcon.Image = ((System.Drawing.Image)(resources.GetObject("_warningIcon.Image")));
			this._warningIcon.Location = new System.Drawing.Point(10, 4);
			this._warningIcon.Name = "_warningIcon";
			this._warningIcon.Size = new System.Drawing.Size(32, 30);
			this._warningIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this._warningIcon.TabIndex = 15;
			this._warningIcon.TabStop = false;
			//
			// _sendReceiveButton
			//
			this._sendReceiveButton.BackColor = System.Drawing.SystemColors.ButtonFace;
			this._sendReceiveButton.Image = ((System.Drawing.Image)(resources.GetObject("_sendReceiveButton.Image")));
			this._sendReceiveButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._sendReceiveButton.Location = new System.Drawing.Point(349, 2);
			this._sendReceiveButton.Name = "_sendReceiveButton";
			this._sendReceiveButton.Size = new System.Drawing.Size(132, 38);
			this._sendReceiveButton.TabIndex = 14;
			this._sendReceiveButton.Text = "Send/Receive";
			this._sendReceiveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this._sendReceiveButton.UseVisualStyleBackColor = false;
			this._sendReceiveButton.Click += new System.EventHandler(this._syncButton_Click);
			//
			// SyncControl
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.Controls.Add(this._closeButton);
			this.Controls.Add(this._statusText);
			this.Controls.Add(this._successIcon);
			this.Controls.Add(this._warningIcon);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this._cancelButton);
			this.Controls.Add(this._tabControl);
			this.Controls.Add(this._sendReceiveButton);
			this.Name = "SyncControl";
			this.Size = new System.Drawing.Size(494, 320);
			this.Load += new System.EventHandler(this.OnLoad);
			this.Resize += new System.EventHandler(this.SyncControl_Resize);
			this._tabControl.ResumeLayout(false);
			this._chooseTargetsTab.ResumeLayout(false);
			this._chooseTargetsTab.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this._tasksTab.ResumeLayout(false);
			this._logTab.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this._successIcon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._warningIcon)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabControl _tabControl;
		private System.Windows.Forms.TabPage _tasksTab;
		private System.Windows.Forms.ListView _tasksListView;
		private System.Windows.Forms.TabPage _logTab;
		private System.Windows.Forms.TabPage _chooseTargetsTab;
		private System.Windows.Forms.CheckedListBox _syncTargets;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Button _sendReceiveButton;
		private System.Windows.Forms.Timer _updateDisplayTimer;
		public System.Windows.Forms.Button _cancelButton;
		private System.Windows.Forms.PictureBox _warningIcon;
		private System.Windows.Forms.PictureBox _successIcon;
		public System.Windows.Forms.Button _closeButton;
		private System.Windows.Forms.Label _statusText;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Timer _showCancelButtonTimer;
		private Chorus.UI.Misc.LogBox _logBox;
	}
}