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
using System.Threading;

namespace Display
{
    public partial class RefForm : Form
    {

        public RefForm()
        {
            InitializeComponent();
            getArduinoPort();

        }

        private void RefForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void arduinoport_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            Console.WriteLine("Data was received from the arduino.");
            Console.WriteLine("Data:  " + arduinoport.ReadLine());
        }
        /// <summary>
        /// This fuction will establish communication with the arduino by "auto-detecting" the COM port the arduino is on
        /// </summary>
        private void getArduinoPort()
        {
            Console.WriteLine("Now attempting to connect to the arduino, this will have a timeout of 30 seconds");
            string[] originalPorts;
            string[] latestPorts;
            originalPorts = SerialPort.GetPortNames();
            latestPorts = originalPorts;
            int timeoutIndex = 0;
            Boolean detected = false;
            while (timeoutIndex != 5)
            {
                Console.WriteLine(timeoutIndex);
                latestPorts = SerialPort.GetPortNames();
                if (latestPorts.Length > originalPorts.Length)
                {
                    Console.WriteLine("COM port change detected, a COM port was added, the arduino was plugged in");
                    detected = true;
                    break; // break the while loop since the port was detected
                }
                else
                {
                    Console.WriteLine("no COM port change detected.");
                    Thread.Sleep(1000);
                    timeoutIndex++;
                }
            }
            if (detected)
            {
                Console.WriteLine("The arduino was detected, now we must connect to it.");
                ////TODO: do arduino connection stuff once I find my arduino
            }
            else
            {
                Console.WriteLine("No arduino was detected in the 30 second range. Either the user is lazy and didnt plug it in or it was not detected. Resorting to no arduino.");
            }
        }
    }
}
