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

        //FUNCTIONS//
        public RefForm()
        {
            InitializeComponent();
            getArduinoPort();

        }

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
                Console.WriteLine("How determining Event so we know what to send to server pipe.");
                byte data = 255;
                Boolean send = true;
                switch(int.Parse(receivedData)) //This switch handles all possible events from the arduino and has a failsafe incase we cannot setermine the error
                { //Team 2 events will by their event number plus 128 in to ensure they don't get seen as team 1 events
                  //Team 1 events will be their event number plus 1 so that there is a size 1 gap between them and the start match event
                    case 0:
                        Console.WriteLine("Command received was a start match command. Starting Match");
                        data = 0; // set the data to send to 0 instead of 255 to signify the starting of the match
                        break;
                    case 1:
                        Console.WriteLine("Command received was a team 1 band score.");
                        data = 2; // set the data to send to 2 (event 1 + offset) to signify team one scoring points via rubber bands
                        break;
                    case 2:
                        Console.WriteLine("Command received was a team 1 ping pong score.");
                        data = 3; // set the data to send to 3 (event 2 + offset) to signify team one scoring points via ping pong balls
                        break;
                    case 3:
                        Console.WriteLine("Command received was a team 1 push off score.");
                        data = 4; // set the data to send to 4 (event 3 + offset) to signify team one scoring points via pushing team 2 off
                        break;
                    case 4:
                        Console.WriteLine("Command received was a team 1 disabled score.");
                        data = 5; // set the data to send to 5 (event 4 + offset) to signify team one scoring points via diabling team 2
                        break;
                    case 5:
                        Console.WriteLine("Command received was a team 2 band score.");
                        data = 133; // set the data to send to 133 (event 5 + team 2 offset) to signify team 2 scoring points via rubber bands
                        break;
                    case 6:
                        Console.WriteLine("Command received was a team 2 ping pong score.");
                        data = 134; // set the data to send to 134 (event 6 + team 2 offset) to signify team 2 scoring points via ping pong balls
                        break;
                    case 7:
                        Console.WriteLine("Command received was a team 2 push off score.");
                        data = 135; // set the data to send to 135 (event 7 + team 2 offset) to signify team 2 scoring points via pushing team 1 off
                        break;
                    case 8:
                        Console.WriteLine("Command received was a team 2 disabled score.");
                        data = 136; // set the data t osend to 136 (event 8 + team 2 offset) to signify team 2 scoring points via disabling team 1
                        break;
                    default:
                        Console.WriteLine("Command was not determinable.");
                        send = false;
                        break;
                }
                if (send)
                {
                    PipeClient.sendToServer(data); // send the data byte to the server via the pipe connection
                }
            }
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
            while (timeoutIndex != 10)
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
                arduinoport.BaudRate = 9600; // set the baud rate to the default for arduinos.
                arduinoport.PortName = latestPorts[latestPorts.Length - 1]; // set the COM port to use
                arduinoport.ReceivedBytesThreshold = 1;
                arduinoport.NewLine = "\n";
                arduinoport.Open(); // assume direct control
                Console.WriteLine("Connected to arduino via COM port {0}", latestPorts[latestPorts.Length - 1]);
            }
            else
            {
                Console.WriteLine("No arduino was detected in the 30 second range. Either the user is lazy and didnt plug it in or it was not detected. Resorting to no arduino.");
            }
        }

        delegate void SetTextCallback(string text);

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
