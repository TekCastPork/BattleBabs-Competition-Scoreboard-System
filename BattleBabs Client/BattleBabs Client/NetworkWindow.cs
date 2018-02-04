using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace BattleBabs_Client
{
    public partial class NetworkWindow: Form
    {
        public static Boolean isOpen = false;

        public NetworkWindow()
        {
            InitializeComponent();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            Networking.IP = IPBox.Text;
            Networking.update();
            isOpen = false;
            this.Hide();
        }

        private void listIPButton_Click(object sender, EventArgs e)
        {
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();

            var host = Dns.GetHostEntry(Dns.GetHostName());
            int index = 0;
            string[] IPs = new string[50]; // if a user has more than 50 network adapters god help them
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    Console.WriteLine("An available IP: {0}.", ip.ToString());
                    try
                    {
                        IPs[index] = ip.ToString();
                        index++;
                    }
                    catch (Exception e1)
                    {
                        Console.WriteLine("Exception! {1} {2} User has more than 50 network adapters. I can't handle this! Godspeed user!", e1.ToString(), e1.Message);
                    }
                }
            }
            IPs = IPs.Where(x => !string.IsNullOrEmpty(x)).ToArray(); // Take out the old air, freshen it up a little, and put it back in!
            string allIps = String.Join(Environment.NewLine, IPs);
            MessageBox.Show("All Available IPs: (Each IP is on it's own network adapter. This shows for the local machine only, these are not the IPs of the server!)" + Environment.NewLine + allIps, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            isOpen = false;
        }

        private void defaultButton_Click(object sender, EventArgs e)
        {
            Networking.IP = "127.0.0.1";
            Networking.update();
            this.Hide();
            isOpen = false;
        }
    }
}
