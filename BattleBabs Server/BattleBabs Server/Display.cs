﻿using System;
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
        Session displaySession = new Session();
        string name = String.Empty;
        
        public Display()
        {
            InitializeComponent();
            updateScreen = new Thread(new ThreadStart(update))
            {
                Name = "Display Update Thread",
                IsBackground = true
            };
            updateScreen.Start();
        }

        //GUI update related code//
        delegate void SetUpdateCallback();
        /// <summary>
        /// This update will need to be called every time (use with events like network data receive or session change or application load/exit)
        /// </summary>
        private void update()
        {
            Label[] teamsToUpdate = { team1, team2, team3, team4, team5, team6, team7, team8, team9, team10, team11, team12, team13, team14, team15, team16 };
            Label[] scoresToUpdate = { score1, score2, score3, score4, score5, score6, score7, score8, score9, score10, score11, score12, score13, score14, score15, score16 };
            Label[] scoreTextLabels = {text1, text2, text3, text4, text5, text6, text7, text8, text9, text10, text11, text12, text13, text14, text15, text16 };
            Label[] rankTextLabels = { rank1, rank2, rank3, rank4, rank5, rank6, rank7, rank8, rank9, rank10, rank11, rank12, rank13, rank14, rank15, rank16 };
            Boolean executeOrder66 = false;
            if (sessionBox.InvokeRequired) // check to see if the session combo box requires an Invoke to get data (prevents Cross Threading Exceptions)
            {
                SetUpdateCallback d = new SetUpdateCallback(update); // If so use the delegate then Invoke
                this.Invoke(d, new object[] { });
            }
            else // If a invoke is not required
            {
                sessionBox.Items.AddRange(GameData.getStoredKeys());
                if(String.IsNullOrWhiteSpace(sessionBox.Text))
                {
                    sessionBox.Text = GameData.getStoredKeys()[0];
                }
                if (GameData.tryGetSession(sessionBox.Text)) // see if a session with the key from the session combo box exists in the dictionary
                {
                    Console.WriteLine("{0} | Session Exists", DateTime.Now);
                    executeOrder66 = true;
                }
                else
                {
                    Console.WriteLine("{0} | Session did not exist", DateTime.Now);
                    executeOrder66 = false;
                }
                if(executeOrder66) // The Time Has Come
                {
                    Console.WriteLine("Yes my Lord.");
                    displaySession = GameData.getSessionByName(sessionBox.Text);

                    //BEGIN GUI UPDATE
                    for(int i = 0; i < displaySession.teams.Count; i++)
                    {
                        updateLabel(teamsToUpdate[i], displaySession.teams.ElementAt(i).name);
                        updateLabel(scoresToUpdate[i], displaySession.teams.ElementAt(i).score.ToString());
                    }
                }
            }
            Console.WriteLine("Update function complete");
        }
        delegate void setLabelCallback(Label c, string text);
        private void updateLabel(Label c, string text)
        {
            if(c.InvokeRequired)
            {
                setLabelCallback d = new setLabelCallback(updateLabel);
                this.Invoke(d, new object[] { c, text });
            } else
            {
                c.Text = text;
            }
        }
        private void configureLabels(Label[] teamsToUpdate, Label[] scoresToUpdate, Label[] scoreTextLabels, Label[] rankTextLabels)
        {
            for (int i = 0; i < displaySession.teamCount; i++)
            {
                if (teamsToUpdate[i].InvokeRequired)
                {
                    SetUpdateCallback d = new SetUpdateCallback(update);
                    this.Invoke(d, new object[] { });
                }
                else
                {
                    teamsToUpdate[i].Visible = true;
                }
                if (scoresToUpdate[i].InvokeRequired)
                {
                    SetUpdateCallback d = new SetUpdateCallback(update);
                    this.Invoke(d, new object[] { });
                }
                else
                {
                    scoresToUpdate[i].Visible = true;
                }
                if (scoreTextLabels[i].InvokeRequired)
                {
                    SetUpdateCallback d = new SetUpdateCallback(update);
                    this.Invoke(d, new object[] { });
                }
                else
                {
                    scoreTextLabels[i].Visible = true;
                }
                if (rankTextLabels[i].InvokeRequired)
                {
                    SetUpdateCallback d = new SetUpdateCallback(update);
                    this.Invoke(d, new object[] { });
                }
                else
                {
                    rankTextLabels[i].Visible = true;
                }
            }

            for (int i = 15; i > displaySession.teamCount; i--)
            {
                if (teamsToUpdate[i].InvokeRequired)
                {
                    SetUpdateCallback d = new SetUpdateCallback(update);
                    this.Invoke(d, new object[] { });
                }
                else
                {
                    teamsToUpdate[i].Visible = false;
                }
                if (scoresToUpdate[i].InvokeRequired)
                {
                    SetUpdateCallback d = new SetUpdateCallback(update);
                    this.Invoke(d, new object[] { });
                }
                else
                {
                    scoresToUpdate[i].Visible = false;
                }
                if (scoreTextLabels[i].InvokeRequired)
                {
                    SetUpdateCallback d = new SetUpdateCallback(update);
                    this.Invoke(d, new object[] { });
                }
                else
                {
                    scoreTextLabels[i].Visible = false;
                }
                if (rankTextLabels[i].InvokeRequired)
                {
                    SetUpdateCallback d = new SetUpdateCallback(update);
                    this.Invoke(d, new object[] { });
                }
                else
                {
                    rankTextLabels[i].Visible = false;
                }
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
            if(String.IsNullOrWhiteSpace(nameBox.Text))
            {
                Console.WriteLine("Name box is empty or contains only whitespace characters, cannot create new session. Telling user");
                MessageBox.Show("Session name is null, empty, or has only whitespace characters. Please enter a different session name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                displaySession.teamCount = (int)teamCount.Value;
                GameData.saveSessionByName(displaySession, nameBox.Text);
                nameBox.Text = String.Empty;
                Console.WriteLine("Session made");
            }
        }

        private void endSession_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to end this leaderboard session?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                GameData.removeSessionByName(name);
            }
        }

        private void Display_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileSystem.saveData();
        }
    }
}
