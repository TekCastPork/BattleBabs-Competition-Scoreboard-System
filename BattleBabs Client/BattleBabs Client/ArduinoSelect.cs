using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace BattleBabs_Client
{
    public partial class ArduinoForm : Form
    {
        public string[] portList;
        public ArduinoForm()
        {
            InitializeComponent();
            getSerialPorts();
        }

        private void getSerialPorts()
        {
            Console.WriteLine("Gathering all connected COM ports...");
            portList = SerialPort.GetPortNames();
            Console.WriteLine("All COM ports Gathered, now putting ports to drop down.");

            Console.WriteLine("Removing previous entries.");
            for (int i = 0; i < portList.Length; i++)
            {
                try
                {
                    comPortBox.Items.Remove(i);
                } catch (Exception e)
                {
                    Console.WriteLine("Exception catched! {0}", e.ToString());
                }
            }
            Console.WriteLine("Adding COM port names.");
            for (int i = 0; i < portList.Length; i++)
            {
                comPortBox.Items.Insert(i, portList[i]);
            }


        }

        private void selectButton_Click(object sender, EventArgs e)
        {

        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Refresh button hit! Refreshing Ports");
            getSerialPorts();
        }
    }
}
