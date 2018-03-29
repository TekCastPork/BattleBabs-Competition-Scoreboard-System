namespace BattleBabs_Client
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.label1 = new System.Windows.Forms.Label();
            this.timerCount = new System.Windows.Forms.NumericUpDown();
            this.applyButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.seedBox = new System.Windows.Forms.CheckBox();
            this.seedText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fullScreenBox = new System.Windows.Forms.CheckBox();
            this.compName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.showChanges = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.timerCount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Match Duration (s)";
            // 
            // timerCount
            // 
            this.timerCount.Location = new System.Drawing.Point(15, 25);
            this.timerCount.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.timerCount.Name = "timerCount";
            this.timerCount.Size = new System.Drawing.Size(53, 20);
            this.timerCount.TabIndex = 1;
            this.timerCount.Value = new decimal(new int[] {
            75,
            0,
            0,
            0});
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(12, 159);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 2;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(149, 159);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // seedBox
            // 
            this.seedBox.AutoSize = true;
            this.seedBox.Location = new System.Drawing.Point(15, 51);
            this.seedBox.Name = "seedBox";
            this.seedBox.Size = new System.Drawing.Size(116, 17);
            this.seedBox.TabIndex = 4;
            this.seedBox.Text = "Use seeded RNG?";
            this.seedBox.UseVisualStyleBackColor = true;
            // 
            // seedText
            // 
            this.seedText.Location = new System.Drawing.Point(96, 24);
            this.seedText.Name = "seedText";
            this.seedText.Size = new System.Drawing.Size(78, 20);
            this.seedText.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "RNG Seed";
            // 
            // fullScreenBox
            // 
            this.fullScreenBox.AutoSize = true;
            this.fullScreenBox.Location = new System.Drawing.Point(15, 74);
            this.fullScreenBox.Name = "fullScreenBox";
            this.fullScreenBox.Size = new System.Drawing.Size(80, 17);
            this.fullScreenBox.TabIndex = 7;
            this.fullScreenBox.Text = "Fullscreen?";
            this.fullScreenBox.UseVisualStyleBackColor = true;
            // 
            // compName
            // 
            this.compName.Location = new System.Drawing.Point(12, 133);
            this.compName.Name = "compName";
            this.compName.Size = new System.Drawing.Size(209, 20);
            this.compName.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Competition Name";
            // 
            // showChanges
            // 
            this.showChanges.AutoSize = true;
            this.showChanges.Location = new System.Drawing.Point(15, 97);
            this.showChanges.Name = "showChanges";
            this.showChanges.Size = new System.Drawing.Size(179, 17);
            this.showChanges.TabIndex = 10;
            this.showChanges.Text = "Show Whats New on Next Load";
            this.showChanges.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 191);
            this.Controls.Add(this.showChanges);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.compName);
            this.Controls.Add(this.fullScreenBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.seedText);
            this.Controls.Add(this.seedBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.timerCount);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.Text = "General Settings";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.timerCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown timerCount;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox seedBox;
        private System.Windows.Forms.TextBox seedText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox fullScreenBox;
        private System.Windows.Forms.TextBox compName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox showChanges;
    }
}