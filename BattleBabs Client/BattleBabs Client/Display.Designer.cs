﻿namespace BattleBabs_Client
{
    partial class Display
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Display));
            this.titleLabel = new System.Windows.Forms.Label();
            this.team2Name = new System.Windows.Forms.Label();
            this.team1Name = new System.Windows.Forms.Label();
            this.team1ScoreLbl = new System.Windows.Forms.Label();
            this.team2ScoreLbl = new System.Windows.Forms.Label();
            this.VSpicture = new System.Windows.Forms.PictureBox();
            this.teamchangeButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.connectButton = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.networkButton = new System.Windows.Forms.Button();
            this.bugButton = new System.Windows.Forms.Button();
            this.timerLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.generalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportBugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToArduinoControllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generalToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.scoringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.VSpicture)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleLabel.Font = new System.Drawing.Font("Modern No. 20", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(0, 24);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(984, 104);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "Robert Thirsk High School\'s Bi-Annual Battlebabs Competition";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // team2Name
            // 
            this.team2Name.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.team2Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.team2Name.Location = new System.Drawing.Point(642, 188);
            this.team2Name.MaximumSize = new System.Drawing.Size(330, 50);
            this.team2Name.Name = "team2Name";
            this.team2Name.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.team2Name.Size = new System.Drawing.Size(330, 50);
            this.team2Name.TabIndex = 4;
            this.team2Name.Text = "Team2Name";
            this.team2Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // team1Name
            // 
            this.team1Name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.team1Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.team1Name.Location = new System.Drawing.Point(12, 188);
            this.team1Name.MaximumSize = new System.Drawing.Size(330, 50);
            this.team1Name.Name = "team1Name";
            this.team1Name.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.team1Name.Size = new System.Drawing.Size(330, 50);
            this.team1Name.TabIndex = 5;
            this.team1Name.Text = "Team1Name";
            this.team1Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // team1ScoreLbl
            // 
            this.team1ScoreLbl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.team1ScoreLbl.BackColor = System.Drawing.Color.Black;
            this.team1ScoreLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.team1ScoreLbl.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.team1ScoreLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.team1ScoreLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.team1ScoreLbl.Location = new System.Drawing.Point(12, 238);
            this.team1ScoreLbl.MaximumSize = new System.Drawing.Size(330, 50);
            this.team1ScoreLbl.Name = "team1ScoreLbl";
            this.team1ScoreLbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.team1ScoreLbl.Size = new System.Drawing.Size(330, 50);
            this.team1ScoreLbl.TabIndex = 6;
            this.team1ScoreLbl.Text = "0123456789";
            this.team1ScoreLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // team2ScoreLbl
            // 
            this.team2ScoreLbl.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.team2ScoreLbl.BackColor = System.Drawing.Color.Black;
            this.team2ScoreLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.team2ScoreLbl.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.team2ScoreLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.team2ScoreLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.team2ScoreLbl.Location = new System.Drawing.Point(642, 238);
            this.team2ScoreLbl.MaximumSize = new System.Drawing.Size(330, 50);
            this.team2ScoreLbl.Name = "team2ScoreLbl";
            this.team2ScoreLbl.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.team2ScoreLbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.team2ScoreLbl.Size = new System.Drawing.Size(330, 50);
            this.team2ScoreLbl.TabIndex = 7;
            this.team2ScoreLbl.Text = "0123456789";
            this.team2ScoreLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // VSpicture
            // 
            this.VSpicture.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.VSpicture.Image = ((System.Drawing.Image)(resources.GetObject("VSpicture.Image")));
            this.VSpicture.InitialImage = null;
            this.VSpicture.Location = new System.Drawing.Point(348, 188);
            this.VSpicture.Name = "VSpicture";
            this.VSpicture.Size = new System.Drawing.Size(288, 150);
            this.VSpicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.VSpicture.TabIndex = 8;
            this.VSpicture.TabStop = false;
            // 
            // teamchangeButton
            // 
            this.teamchangeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.teamchangeButton.Location = new System.Drawing.Point(9, 526);
            this.teamchangeButton.Name = "teamchangeButton";
            this.teamchangeButton.Size = new System.Drawing.Size(87, 23);
            this.teamchangeButton.TabIndex = 9;
            this.teamchangeButton.Text = "Change Teams";
            this.teamchangeButton.UseVisualStyleBackColor = true;
            this.teamchangeButton.Click += new System.EventHandler(this.teamChange_Click);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.Location = new System.Drawing.Point(885, 526);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(87, 23);
            this.exitButton.TabIndex = 13;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // connectButton
            // 
            this.connectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.connectButton.Location = new System.Drawing.Point(195, 526);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(87, 23);
            this.connectButton.TabIndex = 14;
            this.connectButton.Text = "Arduino...";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aboutButton.Location = new System.Drawing.Point(792, 526);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(87, 23);
            this.aboutButton.TabIndex = 15;
            this.aboutButton.Text = "About";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.settingsButton.Location = new System.Drawing.Point(288, 526);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(87, 23);
            this.settingsButton.TabIndex = 16;
            this.settingsButton.Text = "Settings...";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // networkButton
            // 
            this.networkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.networkButton.Location = new System.Drawing.Point(102, 526);
            this.networkButton.Name = "networkButton";
            this.networkButton.Size = new System.Drawing.Size(87, 23);
            this.networkButton.TabIndex = 17;
            this.networkButton.Text = "Network...";
            this.networkButton.UseVisualStyleBackColor = true;
            this.networkButton.Click += new System.EventHandler(this.networkButton_Click);
            // 
            // bugButton
            // 
            this.bugButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bugButton.Location = new System.Drawing.Point(885, 497);
            this.bugButton.Name = "bugButton";
            this.bugButton.Size = new System.Drawing.Size(87, 23);
            this.bugButton.TabIndex = 18;
            this.bugButton.Text = "Report Bug";
            this.bugButton.UseVisualStyleBackColor = true;
            this.bugButton.Click += new System.EventHandler(this.bugButton_Click);
            // 
            // timerLabel
            // 
            this.timerLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.timerLabel.BackColor = System.Drawing.Color.Black;
            this.timerLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.timerLabel.Font = new System.Drawing.Font("Erbos Draco 1st Open NBP", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.timerLabel.Location = new System.Drawing.Point(324, 341);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(338, 81);
            this.timerLabel.TabIndex = 19;
            this.timerLabel.Text = "000.00";
            this.timerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generalToolStripMenuItem,
            this.connectionsToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // generalToolStripMenuItem
            // 
            this.generalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.reportBugToolStripMenuItem});
            this.generalToolStripMenuItem.Name = "generalToolStripMenuItem";
            this.generalToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.generalToolStripMenuItem.Text = "General";
            // 
            // connectionsToolStripMenuItem
            // 
            this.connectionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.networkingToolStripMenuItem,
            this.connectToArduinoControllerToolStripMenuItem});
            this.connectionsToolStripMenuItem.Name = "connectionsToolStripMenuItem";
            this.connectionsToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.connectionsToolStripMenuItem.Text = "Connections";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generalToolStripMenuItem1,
            this.scoringToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // reportBugToolStripMenuItem
            // 
            this.reportBugToolStripMenuItem.Name = "reportBugToolStripMenuItem";
            this.reportBugToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.reportBugToolStripMenuItem.Text = "Report Bug";
            // 
            // networkingToolStripMenuItem
            // 
            this.networkingToolStripMenuItem.Name = "networkingToolStripMenuItem";
            this.networkingToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.networkingToolStripMenuItem.Text = "Networking";
            // 
            // connectToArduinoControllerToolStripMenuItem
            // 
            this.connectToArduinoControllerToolStripMenuItem.Name = "connectToArduinoControllerToolStripMenuItem";
            this.connectToArduinoControllerToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.connectToArduinoControllerToolStripMenuItem.Text = "Connect to Arduino Controller";
            // 
            // generalToolStripMenuItem1
            // 
            this.generalToolStripMenuItem1.Name = "generalToolStripMenuItem1";
            this.generalToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.generalToolStripMenuItem1.Text = "General";
            // 
            // scoringToolStripMenuItem
            // 
            this.scoringToolStripMenuItem.Name = "scoringToolStripMenuItem";
            this.scoringToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.scoringToolStripMenuItem.Text = "Scoring";
            this.scoringToolStripMenuItem.Click += new System.EventHandler(this.scoringToolStripMenuItem_Click);
            // 
            // Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.bugButton);
            this.Controls.Add(this.networkButton);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.teamchangeButton);
            this.Controls.Add(this.VSpicture);
            this.Controls.Add(this.team2ScoreLbl);
            this.Controls.Add(this.team1ScoreLbl);
            this.Controls.Add(this.team1Name);
            this.Controls.Add(this.team2Name);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1004, 604);
            this.Name = "Display";
            this.Text = "BattleBabs Scoreboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Display_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.VSpicture)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label team2Name;
        private System.Windows.Forms.Label team1Name;
        private System.Windows.Forms.Label team1ScoreLbl;
        private System.Windows.Forms.Label team2ScoreLbl;
        private System.Windows.Forms.PictureBox VSpicture;
        private System.Windows.Forms.Button teamchangeButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button networkButton;
        private System.Windows.Forms.Button bugButton;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem generalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportBugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem networkingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToArduinoControllerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generalToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem scoringToolStripMenuItem;
    }
}

