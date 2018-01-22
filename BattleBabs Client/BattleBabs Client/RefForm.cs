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
        //VARIABLES//
        public static SerialPort arduinoport;
        public static string receivedData;
        public static string selectedPort = "";
        public static Thread heartBeat = new Thread(new ThreadStart(isConnectionAlive));

        //FUNCTIONS//
        public RefForm()
        {
            InitializeComponent();
            heartBeat.IsBackground = true;
            arduinoport = new SerialPort();
        }

        /// <summary>
        /// This function is threaded and just checks to see if the COm port is still connected,
        /// aka, if the arduino is still plugged in after connection has been established
        /// </summary>
        public static void isConnectionAlive()
        {
            while (true)
            {
                if (arduinoport.IsOpen)
                {
                    Console.WriteLine("Port is still alive.");
                }
                else
                {
                    Console.WriteLine("Comms port is dead");
                    MessageBox.Show("Lost Connection with Arduino Controller.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                }
                Thread.Sleep(750);
            }
        }

        /// <summary>
        /// Handles Form closing functions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        /// <summary>
        /// This function handles the data received from the arduino and determines what event happened to send to the server via the pipe connection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void arduinoport_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            Boolean receivedFull = false;
            
            Console.WriteLine("Data was received from the arduino.");
            try
            {
                receivedData = arduinoport.ReadLine();
                Console.WriteLine("Data received was: {0} ", receivedData);
                setDataText(receivedData);
                receivedFull = true; // to ensure things later on
            } catch (Exception e1)
            {
                Console.WriteLine("Exception {0} caught from arduinoport.ReadLine() (Line 35 RefForm.cs)", e1.ToString());
            }

            if(receivedFull)
            {
                receivedFull = false; // make this if only run once
                Console.WriteLine("Now determining Event so points may be assigned.");
                try
                {
                    switch (int.Parse(receivedData)) //This switch handles all possible events from the arduino and has a failsafe incase we cannot setermine the error
                    { 
                        case 0:
                            Console.WriteLine("Command received was a start match command. Starting Match");
                            setDataText("Match Start.");
                            break;
                        case 1:
                            Console.WriteLine("Command received was a team 1 band score.");
                            setDataText("Team 1 Rubber Bands");
                            break;
                        case 2:
                            Console.WriteLine("Command received was a team 1 ping pong score.");
                            setDataText("Team 1 Ping Pong");
                            break;
                        case 3:
                            Console.WriteLine("Command received was a team 1 push off score.");
                            setDataText("Team 1 Pushing");
                            break;
                        case 4:
                            Console.WriteLine("Command received was a team 1 disabled score.");
                            setDataText("Team 1 Disable");
                            break;
                        case 5:
                            Console.WriteLine("Command received was a team 2 band score.");
                            setDataText("Team 2 Rubber Bands");
                            break;
                        case 6:
                            Console.WriteLine("Command received was a team 2 ping pong score.");
                            setDataText("Team 2 Ping Pong");
                            break;
                        case 7:
                            Console.WriteLine("Command received was a team 2 push off score.");
                            setDataText("Team 2 Pushing");
                            break;
                        case 8:
                            Console.WriteLine("Command received was a team 2 disabled score.");
                            setDataText("Team 2 Disable");
                            break;
                        default:
                            Console.WriteLine("Command was not determinable.");
                            break;
                    }
                } catch (Exception w)
                {
                    Console.WriteLine("Exception caught! {0}", w.ToString());
                    Console.WriteLine("Data received was [{0}], we cannot parse a integer from that for some reason.", receivedData);
                }
            }
        }

        /// <summary>
        /// This fuction will establish communication with the arduino by "auto-detecting" the COM port the arduino is on
        /// </summary>
        public static void connectArduinoPort()
        {
            try
            {
                arduinoport.BaudRate = 9600; // set the baud rate to the default for arduinos.
                arduinoport.PortName = selectedPort; // set the COM port to use
                arduinoport.ReceivedBytesThreshold = 1;
                arduinoport.NewLine = "\n";
                arduinoport.Open(); // assume direct control
                Console.WriteLine("Connected to arduino via COM port {0}", selectedPort);
                heartBeat.Start();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Caught! {0}", e.ToString());
            }
        }

        /// <summary>
        /// Delegate used for editing event label's text
        /// </summary>
        /// <param name="text"></param>
        delegate void SetTextCallback(string text);

        /// <summary>
        /// Used to edit the text of the recent event label, by either modifying directly or invoking if required
        /// </summary>
        /// <param name="text"></param>
        private void setDataText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.arduinoDataLbl.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(setDataText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.arduinoDataLbl.Text = text;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Start Match button pressed.");
            Display.enableMatch = true;

        }

        private void team1Ping_Click(object sender, EventArgs e)
        {

        }

        private void team1Band_Click(object sender, EventArgs e)
        {

        }

        private void team1Disable_Click(object sender, EventArgs e)
        {

        }

        private void team1Shove_Click(object sender, EventArgs e)
        {

        }

        private void team2Ping_Click(object sender, EventArgs e)
        {

        }

        private void team2Band_Click(object sender, EventArgs e)
        {

        }

        private void team2Disable_Click(object sender, EventArgs e)
        {

        }

        private void team2Shove_Click(object sender, EventArgs e)
        {

        }

        private void team1Toggle_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void team1Override_Click(object sender, EventArgs e)
        {

        }

        private void team2Toggle_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void team2Override_Click(object sender, EventArgs e)
        {

        }
    }
}
