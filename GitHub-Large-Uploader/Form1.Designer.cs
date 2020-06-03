namespace GitHub_Large_Uploader
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
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button3 = new System.Windows.Forms.Button();
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
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.QueuePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // UploadButton
            // 
            this.UploadButton.Location = new System.Drawing.Point(7, 71);
            this.UploadButton.Margin = new System.Windows.Forms.Padding(4);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(727, 36);
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
            this.textBox1.Size = new System.Drawing.Size(344, 23);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(140, 40);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(344, 23);
            this.textBox2.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(496, 8);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 24);
            this.button2.TabIndex = 3;
            this.button2.Text = "Browse";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            this.progressBar1.Size = new System.Drawing.Size(723, 22);
            this.progressBar1.TabIndex = 6;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(496, 40);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(129, 24);
            this.button3.TabIndex = 7;
            this.button3.Text = "Browse";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(16, 138);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(159, 17);
            this.StatusLabel.TabIndex = 8;
            this.StatusLabel.Text = "Status: Waiting for input";
            // 
            // ShowCommandCheckBox
            // 
            this.ShowCommandCheckBox.AutoSize = true;
            this.ShowCommandCheckBox.Location = new System.Drawing.Point(246, 235);
            this.ShowCommandCheckBox.Name = "ShowCommandCheckBox";
            this.ShowCommandCheckBox.Size = new System.Drawing.Size(175, 21);
            this.ShowCommandCheckBox.TabIndex = 9;
            this.ShowCommandCheckBox.Text = "Show command window";
            this.ShowCommandCheckBox.UseVisualStyleBackColor = true;
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(550, 276);
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
            this.CopyFilesCheckBox.Location = new System.Drawing.Point(12, 234);
            this.CopyFilesCheckBox.Name = "CopyFilesCheckBox";
            this.CopyFilesCheckBox.Size = new System.Drawing.Size(192, 21);
            this.CopyFilesCheckBox.TabIndex = 11;
            this.CopyFilesCheckBox.Text = "Copy files instead of move";
            this.CopyFilesCheckBox.UseVisualStyleBackColor = true;
            // 
            // ShutdownCheckbox
            // 
            this.ShutdownCheckbox.AutoSize = true;
            this.ShutdownCheckbox.Location = new System.Drawing.Point(12, 261);
            this.ShutdownCheckbox.Name = "ShutdownCheckbox";
            this.ShutdownCheckbox.Size = new System.Drawing.Size(242, 21);
            this.ShutdownCheckbox.TabIndex = 12;
            this.ShutdownCheckbox.Text = "Shutdown computer when finished";
            this.ShutdownCheckbox.UseVisualStyleBackColor = true;
            // 
            // ForceNextButton
            // 
            this.ForceNextButton.AutoSize = true;
            this.ForceNextButton.Location = new System.Drawing.Point(58, 156);
            this.ForceNextButton.Name = "ForceNextButton";
            this.ForceNextButton.Size = new System.Drawing.Size(76, 17);
            this.ForceNextButton.TabIndex = 13;
            this.ForceNextButton.TabStop = true;
            this.ForceNextButton.Text = "Force Next";
            this.ForceNextButton.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ForceNextButton_LinkClicked);
            // 
            // EstimatedLabel
            // 
            this.EstimatedLabel.AutoSize = true;
            this.EstimatedLabel.Location = new System.Drawing.Point(398, 138);
            this.EstimatedLabel.Name = "EstimatedLabel";
            this.EstimatedLabel.Size = new System.Drawing.Size(0, 17);
            this.EstimatedLabel.TabIndex = 14;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GitHub_Large_Uploader.Properties.Resources.Annotation_2020_06_02_223343;
            this.pictureBox1.Location = new System.Drawing.Point(16, 288);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(164, 32);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 293);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Detector Included";
            // 
            // QueueButton
            // 
            this.QueueButton.Location = new System.Drawing.Point(3, 0);
            this.QueueButton.Name = "QueueButton";
            this.QueueButton.Size = new System.Drawing.Size(102, 30);
            this.QueueButton.TabIndex = 17;
            this.QueueButton.Text = "Add to queue";
            this.QueueButton.UseVisualStyleBackColor = true;
            this.QueueButton.Click += new System.EventHandler(this.QueueButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 24);
            this.button1.TabIndex = 18;
            this.button1.Text = "View Queue";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // QueuePanel
            // 
            this.QueuePanel.Controls.Add(this.QueueButton);
            this.QueuePanel.Controls.Add(this.button1);
            this.QueuePanel.Location = new System.Drawing.Point(626, 6);
            this.QueuePanel.Name = "QueuePanel";
            this.QueuePanel.Size = new System.Drawing.Size(106, 64);
            this.QueuePanel.TabIndex = 19;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(556, 256);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(165, 17);
            this.linkLabel1.TabIndex = 20;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Process Previous Queue";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(737, 326);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.QueuePanel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.EstimatedLabel);
            this.Controls.Add(this.ForceNextButton);
            this.Controls.Add(this.ShutdownCheckbox);
            this.Controls.Add(this.CopyFilesCheckBox);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ShowCommandCheckBox);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UploadButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button3;
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
    }
}

