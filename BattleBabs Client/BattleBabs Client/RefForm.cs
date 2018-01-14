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
        public static string receivedData;
        public static string selectedPort = "";
        public static Thread heartBeat = new Thread(new ThreadStart(isConnectionAlive));

        //FUNCTIONS//
        public RefForm()
        {
            InitializeComponent();
            heartBeat.IsBackground = true;
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
                Console.WriteLine("Now determining Event so we know what to send to server pipe.");
                byte data = 255;
                Boolean send = true;
                try
                {
                    switch (int.Parse(receivedData)) //This switch handles all possible events from the arduino and has a failsafe incase we cannot setermine the error
                    { //Team 2 events will by their event number plus 128 in to ensure they don't get seen as team 1 events
                      //Team 1 events will be their event number plus 1 so that there is a size 1 gap between them and the start match event
                        case 0:
                            Console.WriteLine("Command received was a start match command. Starting Match");
                            data = 0; // set the data to send to 0 instead of 255 to signify the starting of the match
                            setDataText("Match Start.");
                            break;
                        case 1:
                            Console.WriteLine("Command received was a team 1 band score.");
                            data = 2; // set the data to send to 2 (event 1 + offset) to signify team one scoring points via rubber bands
                            setDataText("Team 1 Rubber Bands");
                            break;
                        case 2:
                            Console.WriteLine("Command received was a team 1 ping pong score.");
                            data = 3; // set the data to send to 3 (event 2 + offset) to signify team one scoring points via ping pong balls
                            setDataText("Team 1 Ping Pong");
                            break;
                        case 3:
                            Console.WriteLine("Command received was a team 1 push off score.");
                            data = 4; // set the data to send to 4 (event 3 + offset) to signify team one scoring points via pushing team 2 off
                            setDataText("Team 1 Pushing");
                            break;
                        case 4:
                            Console.WriteLine("Command received was a team 1 disabled score.");
                            data = 5; // set the data to send to 5 (event 4 + offset) to signify team one scoring points via disabling team 2
                            setDataText("Team 1 Disable");
                            break;
                        case 5:
                            Console.WriteLine("Command received was a team 2 band score.");
                            data = 133; // set the data to send to 133 (event 5 + team 2 offset) to signify team 2 scoring points via rubber bands
                            setDataText("Team 2 Rubber Bands");
                            break;
                        case 6:
                            Console.WriteLine("Command received was a team 2 ping pong score.");
                            data = 134; // set the data to send to 134 (event 6 + team 2 offset) to signify team 2 scoring points via ping pong balls
                            setDataText("Team 2 Ping Pong");
                            break;
                        case 7:
                            Console.WriteLine("Command received was a team 2 push off score.");
                            data = 135; // set the data to send to 135 (event 7 + team 2 offset) to signify team 2 scoring points via pushing team 1 off
                            setDataText("Team 2 Pushing");
                            break;
                        case 8:
                            Console.WriteLine("Command received was a team 2 disabled score.");
                            data = 136; // set the data t osend to 136 (event 8 + team 2 offset) to signify team 2 scoring points via disabling team 1
                            setDataText("Team 2 Disable");
                            break;
                        default:
                            Console.WriteLine("Command was not determinable.");
                            send = false;
                            break;
                    }
                } catch (Exception w)
                {
                    Console.WriteLine("Exception caught! {0}", w.ToString());
                    Console.WriteLine("Data received was [{0}], we cannot parse a integer from that.", receivedData);
                }
                if (send)
                {
                    PipeClient.sendToServer(data); // send the data byte to the server via the pipe connection
                }
            }
        }

      /*  private void arduinoport_DataReceived(string Data)
        {
                setDataText(Data);
            if (receivedFull)
            {
                receivedFull = false; // make this if only run once
                Console.WriteLine("Now determining Event so we know what to send to server pipe.");
                byte data = 255;
                Boolean send = true;
                try
                {
                    switch (int.Parse(receivedData)) //This switch handles all possible events from the arduino and has a failsafe incase we cannot setermine the error
                    { //Team 2 events will by their event number plus 128 in to ensure they don't get seen as team 1 events
                      //Team 1 events will be their event number plus 1 so that there is a size 1 gap between them and the start match event
                        case 0:
                            Console.WriteLine("Command received was a start match command. Starting Match");
                            data = 0; // set the data to send to 0 instead of 255 to signify the starting of the match
                            setDataText("Match Start.");
                            break;
                        case 1:
                            Console.WriteLine("Command received was a team 1 band score.");
                            data = 2; // set the data to send to 2 (event 1 + offset) to signify team one scoring points via rubber bands
                            setDataText("Team 1 Rubber Bands");
                            break;
                        case 2:
                            Console.WriteLine("Command received was a team 1 ping pong score.");
                            data = 3; // set the data to send to 3 (event 2 + offset) to signify team one scoring points via ping pong balls
                            setDataText("Team 1 Ping Pong");
                            break;
                        case 3:
                            Console.WriteLine("Command received was a team 1 push off score.");
                            data = 4; // set the data to send to 4 (event 3 + offset) to signify team one scoring points via pushing team 2 off
                            setDataText("Team 1 Pushing");
                            break;
                        case 4:
                            Console.WriteLine("Command received was a team 1 disabled score.");
                            data = 5; // set the data to send to 5 (event 4 + offset) to signify team one scoring points via disabling team 2
                            setDataText("Team 1 Disable");
                            break;
                        case 5:
                            Console.WriteLine("Command received was a team 2 band score.");
                            data = 133; // set the data to send to 133 (event 5 + team 2 offset) to signify team 2 scoring points via rubber bands
                            setDataText("Team 2 Rubber Bands");
                            break;
                        case 6:
                            Console.WriteLine("Command received was a team 2 ping pong score.");
                            data = 134; // set the data to send to 134 (event 6 + team 2 offset) to signify team 2 scoring points via ping pong balls
                            setDataText("Team 2 Ping Pong");
                            break;
                        case 7:
                            Console.WriteLine("Command received was a team 2 push off score.");
                            data = 135; // set the data to send to 135 (event 7 + team 2 offset) to signify team 2 scoring points via pushing team 1 off
                            setDataText("Team 2 Pushing");
                            break;
                        case 8:
                            Console.WriteLine("Command received was a team 2 disabled score.");
                            data = 136; // set the data t osend to 136 (event 8 + team 2 offset) to signify team 2 scoring points via disabling team 1
                            setDataText("Team 2 Disable");
                            break;
                        default:
                            Console.WriteLine("Command was not determinable.");
                            send = false;
                            break;
                    }
                }
                catch (Exception w)
                {
                    Console.WriteLine("Exception caught! {0}", w.ToString());
                    Console.WriteLine("Data received was [{0}], we cannot parse a integer from that.", receivedData);
                }
                if (send)
                {
                    PipeClient.sendToServer(data); // send the data byte to the server via the pipe connection
                }
            }
        } */

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
    }
}
