namespace BattleBabs_Server
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
            this.ipLabel = new System.Windows.Forms.Label();
            this.loadfile = new System.Windows.Forms.OpenFileDialog();
            this.team1 = new System.Windows.Forms.Label();
            this.team2 = new System.Windows.Forms.Label();
            this.team3 = new System.Windows.Forms.Label();
            this.team4 = new System.Windows.Forms.Label();
            this.team5 = new System.Windows.Forms.Label();
            this.team6 = new System.Windows.Forms.Label();
            this.team7 = new System.Windows.Forms.Label();
            this.team8 = new System.Windows.Forms.Label();
            this.team9 = new System.Windows.Forms.Label();
            this.score1 = new System.Windows.Forms.Label();
            this.score2 = new System.Windows.Forms.Label();
            this.score3 = new System.Windows.Forms.Label();
            this.score4 = new System.Windows.Forms.Label();
            this.score5 = new System.Windows.Forms.Label();
            this.score6 = new System.Windows.Forms.Label();
            this.score7 = new System.Windows.Forms.Label();
            this.score8 = new System.Windows.Forms.Label();
            this.score9 = new System.Windows.Forms.Label();
            this.rank1 = new System.Windows.Forms.Label();
            this.rank2 = new System.Windows.Forms.Label();
            this.rank3 = new System.Windows.Forms.Label();
            this.rank4 = new System.Windows.Forms.Label();
            this.rank5 = new System.Windows.Forms.Label();
            this.rank6 = new System.Windows.Forms.Label();
            this.rank7 = new System.Windows.Forms.Label();
            this.rank8 = new System.Windows.Forms.Label();
            this.rank9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sessionLabel = new System.Windows.Forms.Label();
            this.ipInfoLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutThisSoftwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportBugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matchListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadTeamNamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetScoresCANNOTBEUNDONEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleLabel.Font = new System.Drawing.Font("GodOfWar", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(0, 24);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(984, 32);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "BattleBot Competition Leaderboard";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ipLabel
            // 
            this.ipLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipLabel.Location = new System.Drawing.Point(12, 27);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(142, 23);
            this.ipLabel.TabIndex = 3;
            this.ipLabel.Text = "IP: 255.255.255.255";
            this.ipLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // loadfile
            // 
            this.loadfile.FileOk += new System.ComponentModel.CancelEventHandler(this.loadfile_FileOk);
            // 
            // team1
            // 
            this.team1.AutoSize = true;
            this.team1.Font = new System.Drawing.Font("GodOfWar", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.team1.Location = new System.Drawing.Point(111, 91);
            this.team1.Margin = new System.Windows.Forms.Padding(5, 10, 3, 10);
            this.team1.Name = "team1";
            this.team1.Size = new System.Drawing.Size(178, 25);
            this.team1.TabIndex = 5;
            this.team1.Text = "teamLabel1";
            // 
            // team2
            // 
            this.team2.AutoSize = true;
            this.team2.Font = new System.Drawing.Font("GodOfWar", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.team2.Location = new System.Drawing.Point(111, 146);
            this.team2.Margin = new System.Windows.Forms.Padding(5, 10, 3, 10);
            this.team2.Name = "team2";
            this.team2.Size = new System.Drawing.Size(182, 25);
            this.team2.TabIndex = 6;
            this.team2.Text = "teamLabel2";
            // 
            // team3
            // 
            this.team3.AutoSize = true;
            this.team3.Font = new System.Drawing.Font("GodOfWar", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.team3.Location = new System.Drawing.Point(111, 201);
            this.team3.Margin = new System.Windows.Forms.Padding(5, 10, 3, 10);
            this.team3.Name = "team3";
            this.team3.Size = new System.Drawing.Size(182, 25);
            this.team3.TabIndex = 7;
            this.team3.Text = "teamLabel3";
            // 
            // team4
            // 
            this.team4.AutoSize = true;
            this.team4.Font = new System.Drawing.Font("GodOfWar", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.team4.Location = new System.Drawing.Point(111, 256);
            this.team4.Margin = new System.Windows.Forms.Padding(5, 10, 3, 10);
            this.team4.Name = "team4";
            this.team4.Size = new System.Drawing.Size(183, 25);
            this.team4.TabIndex = 10;
            this.team4.Text = "teamLabel4";
            // 
            // team5
            // 
            this.team5.AutoSize = true;
            this.team5.Font = new System.Drawing.Font("GodOfWar", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.team5.Location = new System.Drawing.Point(111, 311);
            this.team5.Margin = new System.Windows.Forms.Padding(5, 10, 3, 10);
            this.team5.Name = "team5";
            this.team5.Size = new System.Drawing.Size(181, 25);
            this.team5.TabIndex = 9;
            this.team5.Text = "teamLabel5";
            // 
            // team6
            // 
            this.team6.AutoSize = true;
            this.team6.Font = new System.Drawing.Font("GodOfWar", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.team6.Location = new System.Drawing.Point(111, 366);
            this.team6.Margin = new System.Windows.Forms.Padding(5, 10, 3, 10);
            this.team6.Name = "team6";
            this.team6.Size = new System.Drawing.Size(182, 25);
            this.team6.TabIndex = 8;
            this.team6.Text = "teamLabel6";
            // 
            // team7
            // 
            this.team7.AutoSize = true;
            this.team7.Font = new System.Drawing.Font("GodOfWar", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.team7.Location = new System.Drawing.Point(111, 421);
            this.team7.Margin = new System.Windows.Forms.Padding(5, 10, 3, 10);
            this.team7.Name = "team7";
            this.team7.Size = new System.Drawing.Size(180, 25);
            this.team7.TabIndex = 11;
            this.team7.Text = "teamLabel7";
            // 
            // team8
            // 
            this.team8.AutoSize = true;
            this.team8.Font = new System.Drawing.Font("GodOfWar", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.team8.Location = new System.Drawing.Point(111, 476);
            this.team8.Margin = new System.Windows.Forms.Padding(5, 10, 3, 10);
            this.team8.Name = "team8";
            this.team8.Size = new System.Drawing.Size(183, 25);
            this.team8.TabIndex = 12;
            this.team8.Text = "teamLabel8";
            // 
            // team9
            // 
            this.team9.AutoSize = true;
            this.team9.Font = new System.Drawing.Font("GodOfWar", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.team9.Location = new System.Drawing.Point(111, 531);
            this.team9.Margin = new System.Windows.Forms.Padding(5, 10, 3, 10);
            this.team9.Name = "team9";
            this.team9.Size = new System.Drawing.Size(182, 25);
            this.team9.TabIndex = 13;
            this.team9.Text = "teamLabel9";
            // 
            // score1
            // 
            this.score1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.score1.Font = new System.Drawing.Font("GodOfWar", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score1.Location = new System.Drawing.Point(681, 91);
            this.score1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.score1.Name = "score1";
            this.score1.Size = new System.Drawing.Size(288, 35);
            this.score1.TabIndex = 14;
            this.score1.Text = "scoreLabel1";
            this.score1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // score2
            // 
            this.score2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.score2.Font = new System.Drawing.Font("GodOfWar", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score2.Location = new System.Drawing.Point(681, 146);
            this.score2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.score2.Name = "score2";
            this.score2.Size = new System.Drawing.Size(288, 35);
            this.score2.TabIndex = 15;
            this.score2.Text = "scoreLabel2";
            this.score2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // score3
            // 
            this.score3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.score3.Font = new System.Drawing.Font("GodOfWar", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score3.Location = new System.Drawing.Point(681, 201);
            this.score3.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.score3.Name = "score3";
            this.score3.Size = new System.Drawing.Size(288, 35);
            this.score3.TabIndex = 16;
            this.score3.Text = "scoreLabel3";
            this.score3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // score4
            // 
            this.score4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.score4.Font = new System.Drawing.Font("GodOfWar", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score4.Location = new System.Drawing.Point(681, 256);
            this.score4.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.score4.Name = "score4";
            this.score4.Size = new System.Drawing.Size(288, 35);
            this.score4.TabIndex = 17;
            this.score4.Text = "scoreLabel4";
            this.score4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // score5
            // 
            this.score5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.score5.Font = new System.Drawing.Font("GodOfWar", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score5.Location = new System.Drawing.Point(681, 311);
            this.score5.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.score5.Name = "score5";
            this.score5.Size = new System.Drawing.Size(288, 35);
            this.score5.TabIndex = 18;
            this.score5.Text = "scoreLabel5";
            this.score5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // score6
            // 
            this.score6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.score6.Font = new System.Drawing.Font("GodOfWar", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score6.Location = new System.Drawing.Point(681, 366);
            this.score6.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.score6.Name = "score6";
            this.score6.Size = new System.Drawing.Size(288, 35);
            this.score6.TabIndex = 19;
            this.score6.Text = "scoreLabel6";
            this.score6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // score7
            // 
            this.score7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.score7.Font = new System.Drawing.Font("GodOfWar", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score7.Location = new System.Drawing.Point(681, 421);
            this.score7.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.score7.Name = "score7";
            this.score7.Size = new System.Drawing.Size(288, 35);
            this.score7.TabIndex = 20;
            this.score7.Text = "scoreLabel7";
            this.score7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // score8
            // 
            this.score8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.score8.Font = new System.Drawing.Font("GodOfWar", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score8.Location = new System.Drawing.Point(681, 476);
            this.score8.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.score8.Name = "score8";
            this.score8.Size = new System.Drawing.Size(288, 35);
            this.score8.TabIndex = 21;
            this.score8.Text = "scoreLabel8";
            this.score8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // score9
            // 
            this.score9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.score9.Font = new System.Drawing.Font("GodOfWar", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score9.Location = new System.Drawing.Point(681, 531);
            this.score9.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.score9.Name = "score9";
            this.score9.Size = new System.Drawing.Size(288, 35);
            this.score9.TabIndex = 22;
            this.score9.Text = "scoreLabel9";
            this.score9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // rank1
            // 
            this.rank1.AutoSize = true;
            this.rank1.Font = new System.Drawing.Font("GodOfWar", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rank1.Location = new System.Drawing.Point(19, 91);
            this.rank1.Margin = new System.Windows.Forms.Padding(10, 10, 3, 10);
            this.rank1.Name = "rank1";
            this.rank1.Size = new System.Drawing.Size(54, 25);
            this.rank1.TabIndex = 23;
            this.rank1.Text = "1st";
            // 
            // rank2
            // 
            this.rank2.AutoSize = true;
            this.rank2.Font = new System.Drawing.Font("GodOfWar", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rank2.Location = new System.Drawing.Point(19, 146);
            this.rank2.Margin = new System.Windows.Forms.Padding(10, 10, 3, 10);
            this.rank2.Name = "rank2";
            this.rank2.Size = new System.Drawing.Size(66, 25);
            this.rank2.TabIndex = 24;
            this.rank2.Text = "2nd";
            // 
            // rank3
            // 
            this.rank3.AutoSize = true;
            this.rank3.Font = new System.Drawing.Font("GodOfWar", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rank3.Location = new System.Drawing.Point(19, 201);
            this.rank3.Margin = new System.Windows.Forms.Padding(10, 10, 3, 10);
            this.rank3.Name = "rank3";
            this.rank3.Size = new System.Drawing.Size(64, 25);
            this.rank3.TabIndex = 25;
            this.rank3.Text = "3rd";
            // 
            // rank4
            // 
            this.rank4.AutoSize = true;
            this.rank4.Font = new System.Drawing.Font("GodOfWar", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rank4.Location = new System.Drawing.Point(19, 256);
            this.rank4.Margin = new System.Windows.Forms.Padding(10, 10, 3, 10);
            this.rank4.Name = "rank4";
            this.rank4.Size = new System.Drawing.Size(65, 25);
            this.rank4.TabIndex = 26;
            this.rank4.Text = "4th";
            // 
            // rank5
            // 
            this.rank5.AutoSize = true;
            this.rank5.Font = new System.Drawing.Font("GodOfWar", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rank5.Location = new System.Drawing.Point(19, 311);
            this.rank5.Margin = new System.Windows.Forms.Padding(10, 10, 3, 10);
            this.rank5.Name = "rank5";
            this.rank5.Size = new System.Drawing.Size(63, 25);
            this.rank5.TabIndex = 27;
            this.rank5.Text = "5th";
            // 
            // rank6
            // 
            this.rank6.AutoSize = true;
            this.rank6.Font = new System.Drawing.Font("GodOfWar", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rank6.Location = new System.Drawing.Point(19, 366);
            this.rank6.Margin = new System.Windows.Forms.Padding(10, 10, 3, 10);
            this.rank6.Name = "rank6";
            this.rank6.Size = new System.Drawing.Size(64, 25);
            this.rank6.TabIndex = 28;
            this.rank6.Text = "6th";
            // 
            // rank7
            // 
            this.rank7.AutoSize = true;
            this.rank7.Font = new System.Drawing.Font("GodOfWar", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rank7.Location = new System.Drawing.Point(19, 421);
            this.rank7.Margin = new System.Windows.Forms.Padding(10, 10, 3, 10);
            this.rank7.Name = "rank7";
            this.rank7.Size = new System.Drawing.Size(62, 25);
            this.rank7.TabIndex = 29;
            this.rank7.Text = "7th";
            // 
            // rank8
            // 
            this.rank8.AutoSize = true;
            this.rank8.Font = new System.Drawing.Font("GodOfWar", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rank8.Location = new System.Drawing.Point(19, 476);
            this.rank8.Margin = new System.Windows.Forms.Padding(10, 10, 3, 10);
            this.rank8.Name = "rank8";
            this.rank8.Size = new System.Drawing.Size(65, 25);
            this.rank8.TabIndex = 30;
            this.rank8.Text = "8th";
            // 
            // rank9
            // 
            this.rank9.AutoSize = true;
            this.rank9.Font = new System.Drawing.Font("GodOfWar", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rank9.Location = new System.Drawing.Point(19, 531);
            this.rank9.Margin = new System.Windows.Forms.Padding(10, 10, 3, 10);
            this.rank9.Name = "rank9";
            this.rank9.Size = new System.Drawing.Size(64, 25);
            this.rank9.TabIndex = 31;
            this.rank9.Text = "9th";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(902, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Session:";
            // 
            // sessionLabel
            // 
            this.sessionLabel.AutoSize = true;
            this.sessionLabel.Location = new System.Drawing.Point(955, 38);
            this.sessionLabel.Name = "sessionLabel";
            this.sessionLabel.Size = new System.Drawing.Size(14, 13);
            this.sessionLabel.TabIndex = 35;
            this.sessionLabel.Text = "X";
            // 
            // ipInfoLabel
            // 
            this.ipInfoLabel.AutoSize = true;
            this.ipInfoLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ipInfoLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipInfoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ipInfoLabel.Location = new System.Drawing.Point(12, 55);
            this.ipInfoLabel.Name = "ipInfoLabel";
            this.ipInfoLabel.Size = new System.Drawing.Size(381, 19);
            this.ipInfoLabel.TabIndex = 36;
            this.ipInfoLabel.Text = "This machine has multiple possible IPs! Click here for more info.";
            this.ipInfoLabel.Click += new System.EventHandler(this.ipInfoLabel_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.generalToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 39;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutThisSoftwareToolStripMenuItem,
            this.reportBugToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // aboutThisSoftwareToolStripMenuItem
            // 
            this.aboutThisSoftwareToolStripMenuItem.Name = "aboutThisSoftwareToolStripMenuItem";
            this.aboutThisSoftwareToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.aboutThisSoftwareToolStripMenuItem.Text = "About This Software";
            this.aboutThisSoftwareToolStripMenuItem.Click += new System.EventHandler(this.aboutThisSoftwareToolStripMenuItem_Click);
            // 
            // reportBugToolStripMenuItem
            // 
            this.reportBugToolStripMenuItem.Name = "reportBugToolStripMenuItem";
            this.reportBugToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.reportBugToolStripMenuItem.Text = "Report Bug";
            this.reportBugToolStripMenuItem.Click += new System.EventHandler(this.reportBugToolStripMenuItem_Click);
            // 
            // generalToolStripMenuItem
            // 
            this.generalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.switchSessionToolStripMenuItem,
            this.matchListToolStripMenuItem});
            this.generalToolStripMenuItem.Name = "generalToolStripMenuItem";
            this.generalToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.generalToolStripMenuItem.Text = "General";
            // 
            // switchSessionToolStripMenuItem
            // 
            this.switchSessionToolStripMenuItem.Name = "switchSessionToolStripMenuItem";
            this.switchSessionToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.switchSessionToolStripMenuItem.Text = "Switch Session";
            this.switchSessionToolStripMenuItem.Click += new System.EventHandler(this.switchSessionToolStripMenuItem_Click);
            // 
            // matchListToolStripMenuItem
            // 
            this.matchListToolStripMenuItem.Name = "matchListToolStripMenuItem";
            this.matchListToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.matchListToolStripMenuItem.Text = "Match List";
            this.matchListToolStripMenuItem.Click += new System.EventHandler(this.matchListToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadTeamNamesToolStripMenuItem,
            this.resetScoresCANNOTBEUNDONEToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // loadTeamNamesToolStripMenuItem
            // 
            this.loadTeamNamesToolStripMenuItem.Name = "loadTeamNamesToolStripMenuItem";
            this.loadTeamNamesToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.loadTeamNamesToolStripMenuItem.Text = "Load Team Names";
            this.loadTeamNamesToolStripMenuItem.Click += new System.EventHandler(this.loadTeamNamesToolStripMenuItem_Click);
            // 
            // resetScoresCANNOTBEUNDONEToolStripMenuItem
            // 
            this.resetScoresCANNOTBEUNDONEToolStripMenuItem.Name = "resetScoresCANNOTBEUNDONEToolStripMenuItem";
            this.resetScoresCANNOTBEUNDONEToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.resetScoresCANNOTBEUNDONEToolStripMenuItem.Text = "Reset Scores (CANNOT BE UNDONE)";
            this.resetScoresCANNOTBEUNDONEToolStripMenuItem.Click += new System.EventHandler(this.resetScoresCANNOTBEUNDONEToolStripMenuItem_Click);
            // 
            // Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(984, 585);
            this.Controls.Add(this.ipInfoLabel);
            this.Controls.Add(this.sessionLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rank9);
            this.Controls.Add(this.rank8);
            this.Controls.Add(this.rank7);
            this.Controls.Add(this.rank6);
            this.Controls.Add(this.rank5);
            this.Controls.Add(this.rank4);
            this.Controls.Add(this.rank3);
            this.Controls.Add(this.rank2);
            this.Controls.Add(this.rank1);
            this.Controls.Add(this.score9);
            this.Controls.Add(this.score8);
            this.Controls.Add(this.score7);
            this.Controls.Add(this.score6);
            this.Controls.Add(this.score5);
            this.Controls.Add(this.score4);
            this.Controls.Add(this.score3);
            this.Controls.Add(this.score2);
            this.Controls.Add(this.score1);
            this.Controls.Add(this.team9);
            this.Controls.Add(this.team8);
            this.Controls.Add(this.team7);
            this.Controls.Add(this.team4);
            this.Controls.Add(this.team5);
            this.Controls.Add(this.team6);
            this.Controls.Add(this.team3);
            this.Controls.Add(this.team2);
            this.Controls.Add(this.team1);
            this.Controls.Add(this.ipLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1004, 628);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1004, 628);
            this.Name = "Display";
            this.Text = "BattleBab\'s Leaderboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Display_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.OpenFileDialog loadfile;
        private System.Windows.Forms.Label team1;
        private System.Windows.Forms.Label team2;
        private System.Windows.Forms.Label team3;
        private System.Windows.Forms.Label team4;
        private System.Windows.Forms.Label team5;
        private System.Windows.Forms.Label team6;
        private System.Windows.Forms.Label team7;
        private System.Windows.Forms.Label team8;
        private System.Windows.Forms.Label team9;
        private System.Windows.Forms.Label score1;
        private System.Windows.Forms.Label score2;
        private System.Windows.Forms.Label score3;
        private System.Windows.Forms.Label score4;
        private System.Windows.Forms.Label score5;
        private System.Windows.Forms.Label score6;
        private System.Windows.Forms.Label score7;
        private System.Windows.Forms.Label score8;
        private System.Windows.Forms.Label score9;
        private System.Windows.Forms.Label rank1;
        private System.Windows.Forms.Label rank2;
        private System.Windows.Forms.Label rank3;
        private System.Windows.Forms.Label rank4;
        private System.Windows.Forms.Label rank5;
        private System.Windows.Forms.Label rank6;
        private System.Windows.Forms.Label rank7;
        private System.Windows.Forms.Label rank8;
        private System.Windows.Forms.Label rank9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label sessionLabel;
        private System.Windows.Forms.Label ipInfoLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutThisSoftwareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportBugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem switchSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matchListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadTeamNamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetScoresCANNOTBEUNDONEToolStripMenuItem;
    }
}

