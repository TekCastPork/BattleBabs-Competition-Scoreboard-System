using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace BattleBabs_Server
{
    public partial class Display : Form
    {
        Thread updateScreen;
        
        public Display()
        {
            InitializeComponent();
            updateScreen = new Thread(new ThreadStart(update))
            {
                Name = "Main Update Thread",
                IsBackground = true
            };
        }

        //GUI update related code//
        private void update()
        {
            int index = 0;
            Label[] teamsToUpdate = { team1, team2, team3, team4, team5, team6, team7, team8, team9, team10, team11, team12, team13, team14, team15, team16 };
            Label[] scoresToUpdate = { score1, score2, score3, score4, score5, score6, score7, score8, score9, score10, score11, score12, score13, score14, score15, score16 };
            while (true)
            {
                foreach (Label c in teamsToUpdate)
                {
                    try
                    {
                        updateLabel(teamsToUpdate[index], GameData.teamList.ElementAt(index).name);
                        index++;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception Occured! {0}. Message: {1}", e.ToString(), e.Message);
                    }
                }
                index = 0;
                foreach (Label c in scoresToUpdate)
                {
                    try
                    {
                        updateLabel(scoresToUpdate[index], GameData.teamList.ElementAt(index).score.ToString());
                        index++;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception Occured! {0}. Message: {1}", e.ToString(), e.Message);
                    }
                }
                index = 0;
                Thread.Sleep(100);
            }
        }
        delegate void SetLabelUpdateCallback(Label c, string text);
        private void updateLabel(Label c, string text)
        {
            if(c.InvokeRequired)
            {
                SetLabelUpdateCallback d = new SetLabelUpdateCallback(updateLabel);
                this.Invoke(d, new object[] { c, text });
            } else
            {
                c.Text = text;
            }
        }
        //End GUI update related code//

        private void loadTeam_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            Console.WriteLine("Loaded file: {0}", openFileDialog1.FileName);
        }

        private void newSession_Click(object sender, EventArgs e)
        {

        }

        private void endSession_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to end this leaderboard session?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }
    }
}
