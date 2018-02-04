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
            this.aboutButton = new System.Windows.Forms.Button();
            this.ipLabel = new System.Windows.Forms.Label();
            this.loadButton = new System.Windows.Forms.Button();
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
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.sessionButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.sessionLabel = new System.Windows.Forms.Label();
            this.ipInfoLabel = new System.Windows.Forms.Label();
            this.matchupButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleLabel.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(984, 32);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "BattleBab Competition Leaderboard";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aboutButton
            // 
            this.aboutButton.Location = new System.Drawing.Point(890, 27);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(82, 23);
            this.aboutButton.TabIndex = 2;
            this.aboutButton.Text = "About...";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // ipLabel
            // 
            this.ipLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipLabel.Location = new System.Drawing.Point(12, 27);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(237, 23);
            this.ipLabel.TabIndex = 3;
            this.ipLabel.Text = "IP: 255.255.255.255";
            this.ipLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // loadButton
            // 
            this.loadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.loadButton.Location = new System.Drawing.Point(807, 27);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(77, 23);
            this.loadButton.TabIndex = 4;
            this.loadButton.Text = "Load Teams";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // loadfile
            // 
            this.loadfile.FileOk += new System.ComponentModel.CancelEventHandler(this.loadfile_FileOk);
            // 
            // team1
            // 
            this.team1.AutoSize = true;
            this.team1.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.team1.Location = new System.Drawing.Point(87, 91);
            this.team1.Margin = new System.Windows.Forms.Padding(5, 10, 3, 10);
            this.team1.Name = "team1";
            this.team1.Size = new System.Drawing.Size(162, 35);
            this.team1.TabIndex = 5;
            this.team1.Text = "teamLabel1";
            // 
            // team2
            // 
            this.team2.AutoSize = true;
            this.team2.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.team2.Location = new System.Drawing.Point(87, 146);
            this.team2.Margin = new System.Windows.Forms.Padding(5, 10, 3, 10);
            this.team2.Name = "team2";
            this.team2.Size = new System.Drawing.Size(162, 35);
            this.team2.TabIndex = 6;
            this.team2.Text = "teamLabel2";
            // 
            // team3
            // 
            this.team3.AutoSize = true;
            this.team3.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.team3.Location = new System.Drawing.Point(87, 201);
            this.team3.Margin = new System.Windows.Forms.Padding(5, 10, 3, 10);
            this.team3.Name = "team3";
            this.team3.Size = new System.Drawing.Size(162, 35);
            this.team3.TabIndex = 7;
            this.team3.Text = "teamLabel3";
            // 
            // team4
            // 
            this.team4.AutoSize = true;
            this.team4.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.team4.Location = new System.Drawing.Point(87, 256);
            this.team4.Margin = new System.Windows.Forms.Padding(5, 10, 3, 10);
            this.team4.Name = "team4";
            this.team4.Size = new System.Drawing.Size(162, 35);
            this.team4.TabIndex = 10;
            this.team4.Text = "teamLabel4";
            // 
            // team5
            // 
            this.team5.AutoSize = true;
            this.team5.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.team5.Location = new System.Drawing.Point(87, 311);
            this.team5.Margin = new System.Windows.Forms.Padding(5, 10, 3, 10);
            this.team5.Name = "team5";
            this.team5.Size = new System.Drawing.Size(162, 35);
            this.team5.TabIndex = 9;
            this.team5.Text = "teamLabel5";
            // 
            // team6
            // 
            this.team6.AutoSize = true;
            this.team6.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.team6.Location = new System.Drawing.Point(87, 366);
            this.team6.Margin = new System.Windows.Forms.Padding(5, 10, 3, 10);
            this.team6.Name = "team6";
            this.team6.Size = new System.Drawing.Size(162, 35);
            this.team6.TabIndex = 8;
            this.team6.Text = "teamLabel6";
            // 
            // team7
            // 
            this.team7.AutoSize = true;
            this.team7.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.team7.Location = new System.Drawing.Point(87, 421);
            this.team7.Margin = new System.Windows.Forms.Padding(5, 10, 3, 10);
            this.team7.Name = "team7";
            this.team7.Size = new System.Drawing.Size(162, 35);
            this.team7.TabIndex = 11;
            this.team7.Text = "teamLabel7";
            // 
            // team8
            // 
            this.team8.AutoSize = true;
            this.team8.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.team8.Location = new System.Drawing.Point(87, 476);
            this.team8.Margin = new System.Windows.Forms.Padding(5, 10, 3, 10);
            this.team8.Name = "team8";
            this.team8.Size = new System.Drawing.Size(162, 35);
            this.team8.TabIndex = 12;
            this.team8.Text = "teamLabel8";
            // 
            // team9
            // 
            this.team9.AutoSize = true;
            this.team9.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.team9.Location = new System.Drawing.Point(87, 531);
            this.team9.Margin = new System.Windows.Forms.Padding(5, 10, 3, 10);
            this.team9.Name = "team9";
            this.team9.Size = new System.Drawing.Size(162, 35);
            this.team9.TabIndex = 13;
            this.team9.Text = "teamLabel9";
            // 
            // score1
            // 
            this.score1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.score1.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.score2.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.score3.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.score4.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.score5.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.score6.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.score7.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.score8.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.score9.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score9.Location = new System.Drawing.Point(681, 531);
            this.score9.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.score9.Name = "score9";
            this.score9.Size = new System.Drawing.Size(288, 35);
            this.score9.TabIndex = 22;
            this.score9.Text = "scoreLabel9";
            this.score9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(19, 91);
            this.label8.Margin = new System.Windows.Forms.Padding(10, 10, 3, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 35);
            this.label8.TabIndex = 23;
            this.label8.Text = "1st";
            this.label8.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(19, 146);
            this.label9.Margin = new System.Windows.Forms.Padding(10, 10, 3, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 35);
            this.label9.TabIndex = 24;
            this.label9.Text = "2nd";
            this.label9.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(19, 201);
            this.label10.Margin = new System.Windows.Forms.Padding(10, 10, 3, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 35);
            this.label10.TabIndex = 25;
            this.label10.Text = "3rd";
            this.label10.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(19, 256);
            this.label11.Margin = new System.Windows.Forms.Padding(10, 10, 3, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 35);
            this.label11.TabIndex = 26;
            this.label11.Text = "4th";
            this.label11.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(19, 311);
            this.label12.Margin = new System.Windows.Forms.Padding(10, 10, 3, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 35);
            this.label12.TabIndex = 27;
            this.label12.Text = "5th";
            this.label12.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(19, 366);
            this.label13.Margin = new System.Windows.Forms.Padding(10, 10, 3, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 35);
            this.label13.TabIndex = 28;
            this.label13.Text = "6th";
            this.label13.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(19, 421);
            this.label14.Margin = new System.Windows.Forms.Padding(10, 10, 3, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 35);
            this.label14.TabIndex = 29;
            this.label14.Text = "7th";
            this.label14.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(19, 476);
            this.label15.Margin = new System.Windows.Forms.Padding(10, 10, 3, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 35);
            this.label15.TabIndex = 30;
            this.label15.Text = "8th";
            this.label15.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(19, 531);
            this.label16.Margin = new System.Windows.Forms.Padding(10, 10, 3, 10);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(57, 35);
            this.label16.TabIndex = 31;
            this.label16.Text = "9th";
            this.label16.Visible = false;
            // 
            // resetButton
            // 
            this.resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resetButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.resetButton.Location = new System.Drawing.Point(165, 27);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(84, 23);
            this.resetButton.TabIndex = 32;
            this.resetButton.Text = "Reset Scores";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // sessionButton
            // 
            this.sessionButton.Location = new System.Drawing.Point(713, 28);
            this.sessionButton.Name = "sessionButton";
            this.sessionButton.Size = new System.Drawing.Size(88, 23);
            this.sessionButton.TabIndex = 33;
            this.sessionButton.Text = "Switch Session";
            this.sessionButton.UseVisualStyleBackColor = true;
            this.sessionButton.Click += new System.EventHandler(this.sessionButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(710, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Session:";
            // 
            // sessionLabel
            // 
            this.sessionLabel.AutoSize = true;
            this.sessionLabel.Location = new System.Drawing.Point(754, 54);
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
            this.ipInfoLabel.Size = new System.Drawing.Size(301, 19);
            this.ipInfoLabel.TabIndex = 36;
            this.ipInfoLabel.Text = "Multiple IPs are avaiable! Click here for more info.";
            this.ipInfoLabel.Click += new System.EventHandler(this.ipInfoLabel_Click);
            // 
            // matchupButton
            // 
            this.matchupButton.Location = new System.Drawing.Point(890, 55);
            this.matchupButton.Name = "matchupButton";
            this.matchupButton.Size = new System.Drawing.Size(82, 23);
            this.matchupButton.TabIndex = 37;
            this.matchupButton.Text = "Next Matchup";
            this.matchupButton.UseVisualStyleBackColor = true;
            this.matchupButton.Visible = false;
            this.matchupButton.Click += new System.EventHandler(this.matchupButton_Click);
            // 
            // Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(984, 585);
            this.Controls.Add(this.matchupButton);
            this.Controls.Add(this.ipInfoLabel);
            this.Controls.Add(this.sessionLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sessionButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
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
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.ipLabel);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Display";
            this.Text = "BattleBab\'s Leaderboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Display_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.Button loadButton;
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button sessionButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label sessionLabel;
        private System.Windows.Forms.Label ipInfoLabel;
        private System.Windows.Forms.Button matchupButton;
    }
}

