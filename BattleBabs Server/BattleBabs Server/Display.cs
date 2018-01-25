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
        AboutBox about = new AboutBox();
        Thread guiUpdate = new Thread(new ThreadStart(updateComponents));
        public Display()
        {
            InitializeComponent();
            PipeServer.openServer();
        }
        delegate void SetTextCallback(string text);

        private void place1Update(string text)
        {
            if (this.place1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(place1Update);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.place1.Text = text;
            }
        }
        private void updateComponents()
        {
            Console.WriteLine("Updating screen components");
            place1Update(GameUtility.rank[0].ToString());
        }
        private void Display_FormClosing(object sender, FormClosingEventArgs e)
        {
            PipeServer.closeServers();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            if (AboutBox.isShowing == false)
            {
                AboutBox.isShowing = true;
                about.Show();
            }
        }
    }
}
