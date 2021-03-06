﻿namespace BattleBabs_Client
{
    partial class RefForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RefForm));
            this.startButton = new System.Windows.Forms.Button();
            this.team1Ping = new System.Windows.Forms.Button();
            this.team1Band = new System.Windows.Forms.Button();
            this.team1Shove = new System.Windows.Forms.Button();
            this.team1Disable = new System.Windows.Forms.Button();
            this.team2Shove = new System.Windows.Forms.Button();
            this.team2Disable = new System.Windows.Forms.Button();
            this.team2Band = new System.Windows.Forms.Button();
            this.team2Ping = new System.Windows.Forms.Button();
            this.teamLabel1 = new System.Windows.Forms.Label();
            this.teamLabel2 = new System.Windows.Forms.Label();
            this.team1Toggle = new System.Windows.Forms.CheckBox();
            this.team2Toggle = new System.Windows.Forms.CheckBox();
            this.timeBar = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.arduinoDataLbl = new System.Windows.Forms.Label();
            this.team1Score = new System.Windows.Forms.TextBox();
            this.team2Score = new System.Windows.Forms.TextBox();
            this.team1Override = new System.Windows.Forms.Button();
            this.team2Override = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.resumeButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startButton.Location = new System.Drawing.Point(104, 65);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start Match";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // team1Ping
            // 
            this.team1Ping.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.team1Ping.Location = new System.Drawing.Point(12, 65);
            this.team1Ping.Name = "team1Ping";
            this.team1Ping.Size = new System.Drawing.Size(86, 23);
            this.team1Ping.TabIndex = 1;
            this.team1Ping.Text = "Ping Pong";
            this.team1Ping.UseVisualStyleBackColor = true;
            this.team1Ping.Click += new System.EventHandler(this.team1Ping_Click);
            // 
            // team1Band
            // 
            this.team1Band.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.team1Band.Location = new System.Drawing.Point(12, 94);
            this.team1Band.Name = "team1Band";
            this.team1Band.Size = new System.Drawing.Size(86, 23);
            this.team1Band.TabIndex = 2;
            this.team1Band.Text = "Rubber Band";
            this.team1Band.UseVisualStyleBackColor = true;
            this.team1Band.Click += new System.EventHandler(this.team1Band_Click);
            // 
            // team1Shove
            // 
            this.team1Shove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.team1Shove.Location = new System.Drawing.Point(12, 152);
            this.team1Shove.Name = "team1Shove";
            this.team1Shove.Size = new System.Drawing.Size(86, 23);
            this.team1Shove.TabIndex = 4;
            this.team1Shove.Text = "Shove";
            this.team1Shove.UseVisualStyleBackColor = true;
            this.team1Shove.Click += new System.EventHandler(this.team1Shove_Click);
            // 
            // team1Disable
            // 
            this.team1Disable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.team1Disable.Location = new System.Drawing.Point(12, 123);
            this.team1Disable.Name = "team1Disable";
            this.team1Disable.Size = new System.Drawing.Size(86, 23);
            this.team1Disable.TabIndex = 3;
            this.team1Disable.Text = "Disable";
            this.team1Disable.UseVisualStyleBackColor = true;
            this.team1Disable.Click += new System.EventHandler(this.team1Disable_Click);
            // 
            // team2Shove
            // 
            this.team2Shove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.team2Shove.Location = new System.Drawing.Point(186, 152);
            this.team2Shove.Name = "team2Shove";
            this.team2Shove.Size = new System.Drawing.Size(86, 23);
            this.team2Shove.TabIndex = 8;
            this.team2Shove.Text = "Shove";
            this.team2Shove.UseVisualStyleBackColor = true;
            this.team2Shove.Click += new System.EventHandler(this.team2Shove_Click);
            // 
            // team2Disable
            // 
            this.team2Disable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.team2Disable.Location = new System.Drawing.Point(186, 123);
            this.team2Disable.Name = "team2Disable";
            this.team2Disable.Size = new System.Drawing.Size(86, 23);
            this.team2Disable.TabIndex = 7;
            this.team2Disable.Text = "Disable";
            this.team2Disable.UseVisualStyleBackColor = true;
            this.team2Disable.Click += new System.EventHandler(this.team2Disable_Click);
            // 
            // team2Band
            // 
            this.team2Band.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.team2Band.Location = new System.Drawing.Point(186, 94);
            this.team2Band.Name = "team2Band";
            this.team2Band.Size = new System.Drawing.Size(86, 23);
            this.team2Band.TabIndex = 6;
            this.team2Band.Text = "Rubber Band";
            this.team2Band.UseVisualStyleBackColor = true;
            this.team2Band.Click += new System.EventHandler(this.team2Band_Click);
            // 
            // team2Ping
            // 
            this.team2Ping.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.team2Ping.Location = new System.Drawing.Point(186, 65);
            this.team2Ping.Name = "team2Ping";
            this.team2Ping.Size = new System.Drawing.Size(86, 23);
            this.team2Ping.TabIndex = 5;
            this.team2Ping.Text = "Ping Pong";
            this.team2Ping.UseVisualStyleBackColor = true;
            this.team2Ping.Click += new System.EventHandler(this.team2Ping_Click);
            // 
            // teamLabel1
            // 
            this.teamLabel1.Location = new System.Drawing.Point(12, 49);
            this.teamLabel1.Name = "teamLabel1";
            this.teamLabel1.Size = new System.Drawing.Size(86, 13);
            this.teamLabel1.TabIndex = 9;
            this.teamLabel1.Text = "Team 1";
            // 
            // teamLabel2
            // 
            this.teamLabel2.Location = new System.Drawing.Point(186, 49);
            this.teamLabel2.Name = "teamLabel2";
            this.teamLabel2.Size = new System.Drawing.Size(86, 13);
            this.teamLabel2.TabIndex = 10;
            this.teamLabel2.Text = "Team 2";
            this.teamLabel2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // team1Toggle
            // 
            this.team1Toggle.AutoSize = true;
            this.team1Toggle.Location = new System.Drawing.Point(2, 181);
            this.team1Toggle.Name = "team1Toggle";
            this.team1Toggle.Size = new System.Drawing.Size(96, 17);
            this.team1Toggle.TabIndex = 11;
            this.team1Toggle.Text = "Subtract Mode";
            this.team1Toggle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.team1Toggle.UseVisualStyleBackColor = true;
            // 
            // team2Toggle
            // 
            this.team2Toggle.AutoSize = true;
            this.team2Toggle.Location = new System.Drawing.Point(176, 181);
            this.team2Toggle.Name = "team2Toggle";
            this.team2Toggle.Size = new System.Drawing.Size(96, 17);
            this.team2Toggle.TabIndex = 12;
            this.team2Toggle.Text = "Subtract Mode";
            this.team2Toggle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.team2Toggle.UseVisualStyleBackColor = true;
            // 
            // timeBar
            // 
            this.timeBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.timeBar.Location = new System.Drawing.Point(0, 0);
            this.timeBar.Maximum = 75;
            this.timeBar.Name = "timeBar";
            this.timeBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.timeBar.Size = new System.Drawing.Size(284, 23);
            this.timeBar.TabIndex = 13;
            this.timeBar.Value = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-1, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Most Recent Arduino Data:";
            // 
            // arduinoDataLbl
            // 
            this.arduinoDataLbl.AutoSize = true;
            this.arduinoDataLbl.Location = new System.Drawing.Point(132, 26);
            this.arduinoDataLbl.Name = "arduinoDataLbl";
            this.arduinoDataLbl.Size = new System.Drawing.Size(33, 13);
            this.arduinoDataLbl.TabIndex = 15;
            this.arduinoDataLbl.Text = "None";
            // 
            // team1Score
            // 
            this.team1Score.Location = new System.Drawing.Point(12, 200);
            this.team1Score.Name = "team1Score";
            this.team1Score.Size = new System.Drawing.Size(100, 20);
            this.team1Score.TabIndex = 16;
            // 
            // team2Score
            // 
            this.team2Score.Location = new System.Drawing.Point(172, 200);
            this.team2Score.Name = "team2Score";
            this.team2Score.Size = new System.Drawing.Size(100, 20);
            this.team2Score.TabIndex = 17;
            // 
            // team1Override
            // 
            this.team1Override.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.team1Override.Location = new System.Drawing.Point(12, 226);
            this.team1Override.Name = "team1Override";
            this.team1Override.Size = new System.Drawing.Size(100, 23);
            this.team1Override.TabIndex = 18;
            this.team1Override.Text = "Override Score";
            this.team1Override.UseVisualStyleBackColor = true;
            this.team1Override.Click += new System.EventHandler(this.team1Override_Click);
            // 
            // team2Override
            // 
            this.team2Override.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.team2Override.Location = new System.Drawing.Point(172, 226);
            this.team2Override.Name = "team2Override";
            this.team2Override.Size = new System.Drawing.Size(100, 23);
            this.team2Override.TabIndex = 19;
            this.team2Override.Text = "Override Score";
            this.team2Override.UseVisualStyleBackColor = true;
            this.team2Override.Click += new System.EventHandler(this.team2Override_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(104, 152);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 20;
            this.stopButton.Text = "Stop Match";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // resumeButton
            // 
            this.resumeButton.Location = new System.Drawing.Point(104, 94);
            this.resumeButton.Name = "resumeButton";
            this.resumeButton.Size = new System.Drawing.Size(75, 23);
            this.resumeButton.TabIndex = 21;
            this.resumeButton.Text = "Resume";
            this.resumeButton.UseVisualStyleBackColor = true;
            this.resumeButton.Click += new System.EventHandler(this.resumeButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(105, 123);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(75, 23);
            this.pauseButton.TabIndex = 22;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // sendButton
            // 
            this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sendButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sendButton.Location = new System.Drawing.Point(243, 23);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(41, 23);
            this.sendButton.TabIndex = 23;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // RefForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.resumeButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.team2Override);
            this.Controls.Add(this.team1Override);
            this.Controls.Add(this.team2Score);
            this.Controls.Add(this.team1Score);
            this.Controls.Add(this.arduinoDataLbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.timeBar);
            this.Controls.Add(this.team2Toggle);
            this.Controls.Add(this.team1Toggle);
            this.Controls.Add(this.teamLabel2);
            this.Controls.Add(this.teamLabel1);
            this.Controls.Add(this.team2Shove);
            this.Controls.Add(this.team2Disable);
            this.Controls.Add(this.team2Band);
            this.Controls.Add(this.team2Ping);
            this.Controls.Add(this.team1Shove);
            this.Controls.Add(this.team1Disable);
            this.Controls.Add(this.team1Band);
            this.Controls.Add(this.team1Ping);
            this.Controls.Add(this.startButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RefForm";
            this.Text = "Referee Controls";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RefForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button team1Ping;
        private System.Windows.Forms.Button team1Band;
        private System.Windows.Forms.Button team1Shove;
        private System.Windows.Forms.Button team1Disable;
        private System.Windows.Forms.Button team2Shove;
        private System.Windows.Forms.Button team2Disable;
        private System.Windows.Forms.Button team2Band;
        private System.Windows.Forms.Button team2Ping;
        private System.Windows.Forms.Label teamLabel1;
        private System.Windows.Forms.Label teamLabel2;
        private System.Windows.Forms.CheckBox team1Toggle;
        private System.Windows.Forms.CheckBox team2Toggle;
        private System.Windows.Forms.ProgressBar timeBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label arduinoDataLbl;
        private System.Windows.Forms.TextBox team1Score;
        private System.Windows.Forms.TextBox team2Score;
        private System.Windows.Forms.Button team1Override;
        private System.Windows.Forms.Button team2Override;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button resumeButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button sendButton;
    }
}