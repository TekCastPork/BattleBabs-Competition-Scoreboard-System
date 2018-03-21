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
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            TextBox[] names = { Name1, Name2, Name3, Name4 };
            NumericUpDown[] points = { Score1, Score2, Score3, Score4 };
            int index = 0;
            foreach(TextBox c in names)
            {
                try
                {
                    RefForm.ScoreNames[index] = c.Text;
                } catch (Exception e1)
                {
                    Logger.writeExceptionLog(e1);
                    Logger.writeCriticalLog("IF YOU SEE THIS THEN SCORENAMES HAS A LENGTH OF 0 AND STUFF CANT BE STORED IN IT!");
                }
                index++;

            }
            index = 0;
            foreach(NumericUpDown c in points)
            {
                try
                {
                    RefForm.ScoreValues[index] = (int)c.Value;
                } catch (Exception e2)
                {
                    Logger.writeExceptionLog(e2);
                    Logger.writeCriticalLog("IF YOU SEE THIS THEN SCOREVALUES HAS A LENGTH OF 0 AND STUFF CANT BE STORED IN IT!");
                }
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
