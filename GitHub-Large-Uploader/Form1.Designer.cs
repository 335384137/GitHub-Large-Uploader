﻿namespace GitHub_Large_Uploader
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
            this.UploadButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.BrowseSourceButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.BrowseGitHubButton = new System.Windows.Forms.Button();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.ShowCommandCheckBox = new System.Windows.Forms.CheckBox();
            this.ExitButton = new System.Windows.Forms.Button();
            this.CopyFilesCheckBox = new System.Windows.Forms.CheckBox();
            this.ShutdownCheckbox = new System.Windows.Forms.CheckBox();
            this.ForceNextButton = new System.Windows.Forms.LinkLabel();
            this.EstimatedLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.QueueButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.QueuePanel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.GitHubDirectoryQueue = new System.Windows.Forms.TextBox();
            this.SourceDirectoryQueue = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.SettingsTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.SkipErrorsTextBox = new System.Windows.Forms.CheckBox();
            this.SmartModeCheckBox = new System.Windows.Forms.CheckBox();
            this.NumberOfFilesToUploadTextBox = new System.Windows.Forms.TextBox();
            this.SizeToUploadLabel = new System.Windows.Forms.Label();
            this.ContinueButton = new System.Windows.Forms.Button();
            this.AlwaysOnTopCheckBox = new System.Windows.Forms.CheckBox();
            this.UIColorButton = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.HistoryListBox = new System.Windows.Forms.ListBox();
            this.RefreshHistoryButton = new System.Windows.Forms.LinkLabel();
            this.DisplayHistoryTextBox = new System.Windows.Forms.RichTextBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.QueuePanel.SuspendLayout();
            this.SettingsTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // UploadButton
            // 
            this.UploadButton.Location = new System.Drawing.Point(7, 71);
            this.UploadButton.Margin = new System.Windows.Forms.Padding(4);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(763, 36);
            this.UploadButton.TabIndex = 0;
            this.UploadButton.Text = "Upload!";
            this.UploadButton.UseVisualStyleBackColor = true;
            this.UploadButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(140, 8);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(493, 23);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(140, 40);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(493, 23);
            this.textBox2.TabIndex = 2;
            // 
            // BrowseSourceButton
            // 
            this.BrowseSourceButton.Location = new System.Drawing.Point(641, 8);
            this.BrowseSourceButton.Margin = new System.Windows.Forms.Padding(4);
            this.BrowseSourceButton.Name = "BrowseSourceButton";
            this.BrowseSourceButton.Size = new System.Drawing.Size(129, 24);
            this.BrowseSourceButton.TabIndex = 3;
            this.BrowseSourceButton.Text = "Browse";
            this.BrowseSourceButton.UseVisualStyleBackColor = true;
            this.BrowseSourceButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Source Directory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "GitHub Directory";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(11, 112);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(759, 22);
            this.progressBar1.TabIndex = 6;
            // 
            // BrowseGitHubButton
            // 
            this.BrowseGitHubButton.Location = new System.Drawing.Point(641, 40);
            this.BrowseGitHubButton.Margin = new System.Windows.Forms.Padding(4);
            this.BrowseGitHubButton.Name = "BrowseGitHubButton";
            this.BrowseGitHubButton.Size = new System.Drawing.Size(129, 24);
            this.BrowseGitHubButton.TabIndex = 7;
            this.BrowseGitHubButton.Text = "Browse";
            this.BrowseGitHubButton.UseVisualStyleBackColor = true;
            this.BrowseGitHubButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(16, 135);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(159, 17);
            this.StatusLabel.TabIndex = 8;
            this.StatusLabel.Text = "Status: Waiting for input";
            // 
            // ShowCommandCheckBox
            // 
            this.ShowCommandCheckBox.AutoSize = true;
            this.ShowCommandCheckBox.Location = new System.Drawing.Point(234, 6);
            this.ShowCommandCheckBox.Name = "ShowCommandCheckBox";
            this.ShowCommandCheckBox.Size = new System.Drawing.Size(175, 21);
            this.ShowCommandCheckBox.TabIndex = 9;
            this.ShowCommandCheckBox.Text = "Show command window";
            this.ShowCommandCheckBox.UseVisualStyleBackColor = true;
            this.ShowCommandCheckBox.CheckedChanged += new System.EventHandler(this.ShowCommandCheckBox_CheckedChanged);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(604, 319);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(175, 38);
            this.ExitButton.TabIndex = 10;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // CopyFilesCheckBox
            // 
            this.CopyFilesCheckBox.AutoSize = true;
            this.CopyFilesCheckBox.Location = new System.Drawing.Point(5, 5);
            this.CopyFilesCheckBox.Name = "CopyFilesCheckBox";
            this.CopyFilesCheckBox.Size = new System.Drawing.Size(192, 21);
            this.CopyFilesCheckBox.TabIndex = 11;
            this.CopyFilesCheckBox.Text = "Copy files instead of move";
            this.CopyFilesCheckBox.UseVisualStyleBackColor = true;
            this.CopyFilesCheckBox.CheckedChanged += new System.EventHandler(this.CopyFilesCheckBox_CheckedChanged);
            // 
            // ShutdownCheckbox
            // 
            this.ShutdownCheckbox.AutoSize = true;
            this.ShutdownCheckbox.Location = new System.Drawing.Point(5, 32);
            this.ShutdownCheckbox.Name = "ShutdownCheckbox";
            this.ShutdownCheckbox.Size = new System.Drawing.Size(242, 21);
            this.ShutdownCheckbox.TabIndex = 12;
            this.ShutdownCheckbox.Text = "Shutdown computer when finished";
            this.ShutdownCheckbox.UseVisualStyleBackColor = true;
            this.ShutdownCheckbox.CheckedChanged += new System.EventHandler(this.ShutdownCheckbox_CheckedChanged);
            // 
            // ForceNextButton
            // 
            this.ForceNextButton.AutoSize = true;
            this.ForceNextButton.Location = new System.Drawing.Point(370, 324);
            this.ForceNextButton.Name = "ForceNextButton";
            this.ForceNextButton.Size = new System.Drawing.Size(102, 17);
            this.ForceNextButton.TabIndex = 13;
            this.ForceNextButton.TabStop = true;
            this.ForceNextButton.Text = "Force Next File";
            this.ForceNextButton.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ForceNextButton_LinkClicked);
            // 
            // EstimatedLabel
            // 
            this.EstimatedLabel.AutoSize = true;
            this.EstimatedLabel.Location = new System.Drawing.Point(474, 138);
            this.EstimatedLabel.Name = "EstimatedLabel";
            this.EstimatedLabel.Size = new System.Drawing.Size(0, 17);
            this.EstimatedLabel.TabIndex = 14;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GitHub_Large_Uploader.Properties.Resources.Annotation_2020_06_02_223343;
            this.pictureBox1.Location = new System.Drawing.Point(10, 319);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(164, 32);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(180, 324);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Detector Included";
            // 
            // QueueButton
            // 
            this.QueueButton.Location = new System.Drawing.Point(446, 3);
            this.QueueButton.Name = "QueueButton";
            this.QueueButton.Size = new System.Drawing.Size(102, 30);
            this.QueueButton.TabIndex = 17;
            this.QueueButton.Text = "Add to queue";
            this.QueueButton.UseVisualStyleBackColor = true;
            this.QueueButton.Click += new System.EventHandler(this.QueueButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(446, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 40);
            this.button1.TabIndex = 18;
            this.button1.Text = "View Queue";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // QueuePanel
            // 
            this.QueuePanel.Controls.Add(this.label6);
            this.QueuePanel.Controls.Add(this.label5);
            this.QueuePanel.Controls.Add(this.button5);
            this.QueuePanel.Controls.Add(this.button4);
            this.QueuePanel.Controls.Add(this.GitHubDirectoryQueue);
            this.QueuePanel.Controls.Add(this.SourceDirectoryQueue);
            this.QueuePanel.Controls.Add(this.QueueButton);
            this.QueuePanel.Controls.Add(this.button1);
            this.QueuePanel.Location = new System.Drawing.Point(9, 32);
            this.QueuePanel.Name = "QueuePanel";
            this.QueuePanel.Size = new System.Drawing.Size(551, 77);
            this.QueuePanel.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 17);
            this.label6.TabIndex = 24;
            this.label6.Text = "GitHub Directory";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 17);
            this.label5.TabIndex = 23;
            this.label5.Text = "Source Directory";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(349, 35);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(74, 26);
            this.button5.TabIndex = 22;
            this.button5.Text = "Browse";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(349, 7);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(74, 26);
            this.button4.TabIndex = 21;
            this.button4.Text = "Browse";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // GitHubDirectoryQueue
            // 
            this.GitHubDirectoryQueue.Location = new System.Drawing.Point(123, 34);
            this.GitHubDirectoryQueue.Name = "GitHubDirectoryQueue";
            this.GitHubDirectoryQueue.Size = new System.Drawing.Size(220, 23);
            this.GitHubDirectoryQueue.TabIndex = 20;
            // 
            // SourceDirectoryQueue
            // 
            this.SourceDirectoryQueue.Location = new System.Drawing.Point(123, 10);
            this.SourceDirectoryQueue.Name = "SourceDirectoryQueue";
            this.SourceDirectoryQueue.Size = new System.Drawing.Size(220, 23);
            this.SourceDirectoryQueue.TabIndex = 19;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(611, 299);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(165, 17);
            this.linkLabel1.TabIndex = 20;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Process Previous Queue";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(249, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "Number Of Files To Upload At A Time:";
            // 
            // SettingsTabControl
            // 
            this.SettingsTabControl.Controls.Add(this.tabPage1);
            this.SettingsTabControl.Controls.Add(this.tabPage2);
            this.SettingsTabControl.Controls.Add(this.tabPage3);
            this.SettingsTabControl.Location = new System.Drawing.Point(12, 172);
            this.SettingsTabControl.Name = "SettingsTabControl";
            this.SettingsTabControl.SelectedIndex = 0;
            this.SettingsTabControl.Size = new System.Drawing.Size(574, 141);
            this.SettingsTabControl.TabIndex = 22;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.UIColorButton);
            this.tabPage1.Controls.Add(this.AlwaysOnTopCheckBox);
            this.tabPage1.Controls.Add(this.ShowCommandCheckBox);
            this.tabPage1.Controls.Add(this.CopyFilesCheckBox);
            this.tabPage1.Controls.Add(this.ShutdownCheckbox);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(566, 112);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.SkipErrorsTextBox);
            this.tabPage2.Controls.Add(this.SmartModeCheckBox);
            this.tabPage2.Controls.Add(this.NumberOfFilesToUploadTextBox);
            this.tabPage2.Controls.Add(this.QueuePanel);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(566, 112);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Performance & Queue";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // SkipErrorsTextBox
            // 
            this.SkipErrorsTextBox.AutoSize = true;
            this.SkipErrorsTextBox.Location = new System.Drawing.Point(429, 5);
            this.SkipErrorsTextBox.Name = "SkipErrorsTextBox";
            this.SkipErrorsTextBox.Size = new System.Drawing.Size(97, 21);
            this.SkipErrorsTextBox.TabIndex = 24;
            this.SkipErrorsTextBox.Text = "Skip Errors";
            this.SkipErrorsTextBox.UseVisualStyleBackColor = true;
            // 
            // SmartModeCheckBox
            // 
            this.SmartModeCheckBox.AutoSize = true;
            this.SmartModeCheckBox.Location = new System.Drawing.Point(320, 5);
            this.SmartModeCheckBox.Name = "SmartModeCheckBox";
            this.SmartModeCheckBox.Size = new System.Drawing.Size(103, 21);
            this.SmartModeCheckBox.TabIndex = 23;
            this.SmartModeCheckBox.Text = "Smart Mode";
            this.SmartModeCheckBox.UseVisualStyleBackColor = true;
            this.SmartModeCheckBox.CheckedChanged += new System.EventHandler(this.SmartModeCheckBox_CheckedChanged);
            // 
            // NumberOfFilesToUploadTextBox
            // 
            this.NumberOfFilesToUploadTextBox.Location = new System.Drawing.Point(254, 3);
            this.NumberOfFilesToUploadTextBox.Name = "NumberOfFilesToUploadTextBox";
            this.NumberOfFilesToUploadTextBox.Size = new System.Drawing.Size(50, 23);
            this.NumberOfFilesToUploadTextBox.TabIndex = 22;
            this.NumberOfFilesToUploadTextBox.Text = "1";
            this.NumberOfFilesToUploadTextBox.TextChanged += new System.EventHandler(this.NumberOfFilesToUploadTextBox_TextChanged);
            // 
            // SizeToUploadLabel
            // 
            this.SizeToUploadLabel.AutoSize = true;
            this.SizeToUploadLabel.Location = new System.Drawing.Point(599, 263);
            this.SizeToUploadLabel.Name = "SizeToUploadLabel";
            this.SizeToUploadLabel.Size = new System.Drawing.Size(0, 17);
            this.SizeToUploadLabel.TabIndex = 23;
            // 
            // ContinueButton
            // 
            this.ContinueButton.Enabled = false;
            this.ContinueButton.Location = new System.Drawing.Point(487, 325);
            this.ContinueButton.Name = "ContinueButton";
            this.ContinueButton.Size = new System.Drawing.Size(85, 25);
            this.ContinueButton.TabIndex = 24;
            this.ContinueButton.Text = "Continue";
            this.ContinueButton.UseVisualStyleBackColor = true;
            this.ContinueButton.Click += new System.EventHandler(this.ContinueButton_Click);
            // 
            // AlwaysOnTopCheckBox
            // 
            this.AlwaysOnTopCheckBox.AutoSize = true;
            this.AlwaysOnTopCheckBox.Location = new System.Drawing.Point(253, 32);
            this.AlwaysOnTopCheckBox.Name = "AlwaysOnTopCheckBox";
            this.AlwaysOnTopCheckBox.Size = new System.Drawing.Size(114, 21);
            this.AlwaysOnTopCheckBox.TabIndex = 13;
            this.AlwaysOnTopCheckBox.Text = "Always on top";
            this.AlwaysOnTopCheckBox.UseVisualStyleBackColor = true;
            this.AlwaysOnTopCheckBox.CheckedChanged += new System.EventHandler(this.AlwaysOnTopCheckBox_CheckedChanged);
            // 
            // UIColorButton
            // 
            this.UIColorButton.Location = new System.Drawing.Point(435, 3);
            this.UIColorButton.Name = "UIColorButton";
            this.UIColorButton.Size = new System.Drawing.Size(125, 31);
            this.UIColorButton.TabIndex = 14;
            this.UIColorButton.Text = "Change UI Color";
            this.UIColorButton.UseVisualStyleBackColor = true;
            this.UIColorButton.Click += new System.EventHandler(this.UIColorButton_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.linkLabel2);
            this.tabPage3.Controls.Add(this.DisplayHistoryTextBox);
            this.tabPage3.Controls.Add(this.RefreshHistoryButton);
            this.tabPage3.Controls.Add(this.HistoryListBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(566, 112);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "History";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // HistoryListBox
            // 
            this.HistoryListBox.FormattingEnabled = true;
            this.HistoryListBox.ItemHeight = 16;
            this.HistoryListBox.Location = new System.Drawing.Point(10, 10);
            this.HistoryListBox.Name = "HistoryListBox";
            this.HistoryListBox.Size = new System.Drawing.Size(299, 68);
            this.HistoryListBox.TabIndex = 0;
            // 
            // RefreshHistoryButton
            // 
            this.RefreshHistoryButton.AutoSize = true;
            this.RefreshHistoryButton.Location = new System.Drawing.Point(251, 89);
            this.RefreshHistoryButton.Name = "RefreshHistoryButton";
            this.RefreshHistoryButton.Size = new System.Drawing.Size(58, 17);
            this.RefreshHistoryButton.TabIndex = 1;
            this.RefreshHistoryButton.TabStop = true;
            this.RefreshHistoryButton.Text = "Refresh";
            this.RefreshHistoryButton.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RefreshHistoryButton_LinkClicked);
            // 
            // DisplayHistoryTextBox
            // 
            this.DisplayHistoryTextBox.Location = new System.Drawing.Point(315, 10);
            this.DisplayHistoryTextBox.Name = "DisplayHistoryTextBox";
            this.DisplayHistoryTextBox.ReadOnly = true;
            this.DisplayHistoryTextBox.Size = new System.Drawing.Size(241, 67);
            this.DisplayHistoryTextBox.TabIndex = 2;
            this.DisplayHistoryTextBox.Text = "";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(464, 89);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(96, 17);
            this.linkLabel2.TabIndex = 3;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Export History";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(782, 363);
            this.Controls.Add(this.ContinueButton);
            this.Controls.Add(this.SizeToUploadLabel);
            this.Controls.Add(this.SettingsTabControl);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.EstimatedLabel);
            this.Controls.Add(this.ForceNextButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.BrowseGitHubButton);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BrowseSourceButton);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.UploadButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "GitHub Multipart Automatic Uploader";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.QueuePanel.ResumeLayout(false);
            this.QueuePanel.PerformLayout();
            this.SettingsTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UploadButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button BrowseSourceButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button BrowseGitHubButton;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.CheckBox ShowCommandCheckBox;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.CheckBox CopyFilesCheckBox;
        private System.Windows.Forms.CheckBox ShutdownCheckbox;
        private System.Windows.Forms.LinkLabel ForceNextButton;
        private System.Windows.Forms.Label EstimatedLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button QueueButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel QueuePanel;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl SettingsTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox NumberOfFilesToUploadTextBox;
        private System.Windows.Forms.CheckBox SmartModeCheckBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox GitHubDirectoryQueue;
        private System.Windows.Forms.TextBox SourceDirectoryQueue;
        private System.Windows.Forms.CheckBox SkipErrorsTextBox;
        private System.Windows.Forms.Label SizeToUploadLabel;
        private System.Windows.Forms.Button ContinueButton;
        private System.Windows.Forms.CheckBox AlwaysOnTopCheckBox;
        private System.Windows.Forms.Button UIColorButton;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.LinkLabel RefreshHistoryButton;
        private System.Windows.Forms.ListBox HistoryListBox;
        private System.Windows.Forms.RichTextBox DisplayHistoryTextBox;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}

