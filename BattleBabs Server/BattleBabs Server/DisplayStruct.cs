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
    public partial class DisplayStruct : Form
    {
        public static Boolean updateDisplay = false;
        Thread guiUpdate;
        public DisplayStruct()
        {
            InitializeComponent();
            guiUpdate = new Thread(new ThreadStart(updateComponents))
            {
                Name = "DisplayUpdate",
                IsBackground = true
            };
            guiUpdate.Start();
            PersistenceStruct.loadTeamData();
            GameData.teamEntries = SorterStruct.sortStructure(GameData.teamEntries);
        }

        private void updateComponents()
        {
            while (true)
            {
                Thread.Sleep(200);
                if (updateDisplay)
                {
                    updateDisplay = false;
                    GameData.teamData teamInfo = new GameData.teamData();
                    Label[] nameLabels = {
                name1,name2,name3,name4,name5,name6,name7,name8,name9,name10,
                name11,name12,name13,name14,name15,name16,name17,name18
            };
                    Label[] scoreLabels = {
                score1,score2,score3,score4,score5,score6,score7,score8,score9,score10,
                score11,score12,score13,score14,score15,score16,score17,score18
            };
                    Label[] rankLabels = {
                rank1,rank2,rank3,rank4,rank5,rank6,rank7,rank8,rank9,rank10,
                rank11,rank12,rank13,rank14,rank15,rank16,rank17,rank18
            };
                    Thread.Sleep(200);
                    GameData.teamEntries.OrderBy(x => x.sessionID).ToList<GameData.teamData>(); // organize by sessionID so that 9 appear in session 1 and 9 appear in session 2
                    for (int i = 0; i < GameData.teamEntries.Count; i++)
                    {
                        teamInfo = GameData.teamEntries.ElementAt(i);
                        updateLabel(nameLabels[i], teamInfo.name);
                        updateLabel(scoreLabels[i], teamInfo.score.ToString());
                        updateLabel(rankLabels[i], teamInfo.rank.ToString());
                    }
                }
            }

        }
        delegate void UpdateCallback(Label label, string message);
        private void updateLabel(Label label, string message)
        {
            if(label.InvokeRequired)
            {
                UpdateCallback d = new UpdateCallback(updateLabel);
                this.Invoke(d,new object[] { label, message });
            } else
            {
                label.Text = message;
            }
        }
    }
}
