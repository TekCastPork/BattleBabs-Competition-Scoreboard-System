using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleBabs_Client
{
    public partial class RefFormSettings : Form
    {
        public static Boolean isShowing = false;
        public RefFormSettings()
        {
            InitializeComponent();
        }

        private void applyTeam1_Click(object sender, EventArgs e)
        {
            RefForm.team1ScoreNames[0] = Name1.Text;
            RefForm.team1ScoreNames[1] = Name2.Text;
            RefForm.team1ScoreNames[2] = Name3.Text;
            RefForm.team1ScoreNames[3] = Name4.Text;
            RefForm.team1ScoreValues[0] = (int) Score1.Value;
            RefForm.team1ScoreValues[1] = (int) Score2.Value;
            RefForm.team1ScoreValues[2] = (int) Score3.Value;
            RefForm.team1ScoreValues[3] = (int) Score4.Value;
        }

        private void applyTeam2_Click(object sender, EventArgs e)
        {
            RefForm.team2ScoreNames[0] = Name1.Text;
            RefForm.team2ScoreNames[1] = Name2.Text;
            RefForm.team2ScoreNames[2] = Name3.Text;
            RefForm.team2ScoreNames[3] = Name4.Text;
            RefForm.team2ScoreValues[0] = (int)Score1.Value;
            RefForm.team2ScoreValues[1] = (int)Score2.Value;
            RefForm.team2ScoreValues[2] = (int)Score3.Value;
            RefForm.team2ScoreValues[3] = (int)Score4.Value;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            isShowing = false;
        }

        private void RefFormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
