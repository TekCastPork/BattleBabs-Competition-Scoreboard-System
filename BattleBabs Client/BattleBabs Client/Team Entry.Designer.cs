namespace BattleBabs_Client
{
    partial class Team_Entry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Team_Entry));
            this.teamBox1 = new System.Windows.Forms.ComboBox();
            this.teamBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.okbutton = new System.Windows.Forms.Button();
            this.loadbutton = new System.Windows.Forms.Button();
            this.loadNamesFile = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // teamBox1
            // 
            this.teamBox1.FormattingEnabled = true;
            this.teamBox1.Location = new System.Drawing.Point(12, 51);
            this.teamBox1.Name = "teamBox1";
            this.teamBox1.Size = new System.Drawing.Size(160, 21);
            this.teamBox1.TabIndex = 0;
            // 
            // teamBox2
            // 
            this.teamBox2.FormattingEnabled = true;
            this.teamBox2.Location = new System.Drawing.Point(12, 163);
            this.teamBox2.Name = "teamBox2";
            this.teamBox2.Size = new System.Drawing.Size(160, 21);
            this.teamBox2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Team 2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Team 1";
            // 
            // okbutton
            // 
            this.okbutton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.okbutton.Location = new System.Drawing.Point(0, 207);
            this.okbutton.Name = "okbutton";
            this.okbutton.Size = new System.Drawing.Size(188, 23);
            this.okbutton.TabIndex = 4;
            this.okbutton.Text = "OK";
            this.okbutton.UseVisualStyleBackColor = true;
            this.okbutton.Click += new System.EventHandler(this.okbutton_Click);
            // 
            // loadbutton
            // 
            this.loadbutton.Location = new System.Drawing.Point(121, 12);
            this.loadbutton.Name = "loadbutton";
            this.loadbutton.Size = new System.Drawing.Size(55, 23);
            this.loadbutton.TabIndex = 5;
            this.loadbutton.Text = "Load...";
            this.loadbutton.UseVisualStyleBackColor = true;
            this.loadbutton.Click += new System.EventHandler(this.loadbutton_Click);
            // 
            // loadNamesFile
            // 
            this.loadNamesFile.InitialDirectory = "C:\\";
            this.loadNamesFile.Title = "Choose Team Names File";
            this.loadNamesFile.FileOk += new System.ComponentModel.CancelEventHandler(this.loadNamesFile_FileOk);
            // 
            // Team_Entry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(188, 230);
            this.Controls.Add(this.loadbutton);
            this.Controls.Add(this.okbutton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.teamBox2);
            this.Controls.Add(this.teamBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Team_Entry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Team Entry";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Team_Entry_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox teamBox1;
        private System.Windows.Forms.ComboBox teamBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button okbutton;
        private System.Windows.Forms.Button loadbutton;
        private System.Windows.Forms.OpenFileDialog loadNamesFile;
    }
}