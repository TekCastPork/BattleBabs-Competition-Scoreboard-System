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
using System.Net;
using System.Net.Sockets;

namespace BattleBabs_Server
{
    public partial class Display : Form
    {
        AboutBox about = new AboutBox();
        //   Thread guiUpdate;
        public Display()
        {
            InitializeComponent();
            //      PipeServer.openServer();
            Networking.create();
            //       guiUpdate = new Thread(new ThreadStart(updateComponents));
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    Console.WriteLine("An available IP: {0}.", ip.ToString());
                    ipLabel.Text = "IP: " + ip.ToString();
                }
            }
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
