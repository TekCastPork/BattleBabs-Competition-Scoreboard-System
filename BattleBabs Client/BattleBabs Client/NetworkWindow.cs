﻿using System;
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
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach(var ip in host.AddressList)
            {
                if(ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    Console.WriteLine("An available IP: {0}.", ip.ToString()) ;
                    MessageBox.Show("Available IP: " + ip.ToString(), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
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