using System;
using System.Windows.Forms;

namespace BattleBabs_Client
{
    public partial class RefFormSettings : Form
    {
        public static Boolean isShowing = false;
        public RefFormSettings()
        {
            InitializeComponent();
            Persistence.loadScoringData();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            TextBox[] names = { Name1, Name2, Name3, Name4 };
            NumericUpDown[] points = { Score1, Score2, Score3, Score4 };
            int index = 0;
            foreach(TextBox c in names)
            {
                RefForm.ScoreNames[index] = c.Text;
                index++;

            }
            index = 0;
            foreach(NumericUpDown c in points)
            {
                RefForm.ScoreValues[index] = (int) c.Value;
                index++;
            }
            isShowing = false;
            Persistence.saveScoringData();
        }

        private void RefFormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
