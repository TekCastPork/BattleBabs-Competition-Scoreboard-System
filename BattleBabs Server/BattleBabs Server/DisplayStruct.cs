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
        Thread guiUpdate;
        public DisplayStruct()
        {
            InitializeComponent();
            guiUpdate = new Thread(new ThreadStart(updateComponents))
            {
                Name = "DisplayUpdate",
                IsBackground = true
            };
        }

        private void updateComponents()
        {
            GameData.teamData teamInfo = new GameData.teamData();
            Label[] nameLabels = {
                name1,name2,name3,name4,name5,name6,name7,name8,name9,name10,
                name11,name12,name13,name14,name15,name16,name17,name18
            };
            Thread.Sleep(200);
            for(int i = 0; i < GameData.teamEntries.Count; i++)
            {
                teamInfo = GameData.teamEntries.ElementAt(i);
                updateLabel(nameLabels[i], teamInfo.name);
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
