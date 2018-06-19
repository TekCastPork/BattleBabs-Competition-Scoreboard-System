using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace BattleBabs_Client
{
    public partial class ArduinoForm : Form
    {
        System.Timers.Timer timer = new System.Timers.Timer();        
        public static Boolean showRefreshString = false;
        public string[] portList;
        public ArduinoForm()
        {
            
            InitializeComponent();
            Thread updateThread = new Thread(new ThreadStart(updateText))
            {
                Name = "Arduino_GUI_Update",
                IsBackground = true
            };
            updateThread.Start();
            timer.Interval = 5000;
            timer.AutoReset = false;
            timer.Enabled = false;
            timer.Elapsed += timerEnlapsed;
            getSerialPorts();
            refreshLabel.Hide();
        }

        delegate void SetCallback(Boolean mode);

        public void updateText()
        {
            while (true)
            {
                SetRefreshMode(showRefreshString);
                Thread.Sleep(500);
            }
        }

        private void SetRefreshMode(Boolean mode)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (refreshLabel.InvokeRequired)
            {
                SetCallback d = new SetCallback(SetRefreshMode);
                refreshLabel.Invoke(d, new object[] { mode });
            }
            else
            {
                if(mode)
                {
                    refreshLabel.Show();
                } else
                {
                    refreshLabel.Hide();
                }
            }
        }

        private void timerEnlapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            showRefreshString = false;
            timer.Enabled = false;
        }

        private void getSerialPorts()
        {
            Console.WriteLine("Gathering all connected COM ports...");
            portList = SerialPort.GetPortNames();
            Console.WriteLine("All COM ports Gathered, now putting ports to drop down.");
            Console.WriteLine("Removing previous entries.");
            comPortBox.Items.Clear();
            Console.WriteLine("Adding COM port names.");
            for (int i = 0; i < portList.Length; i++)
            {
                comPortBox.Items.Insert(i, portList[i]);
            }


        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            Boolean dataMatch = false;
            for (int i = 0; i < portList.Length; i++) {
                if (comPortBox.Text.Equals(portList[i])) {
                    Console.WriteLine("It matched!");
                    dataMatch = true;
                    break;
                } else
                {
                    Console.WriteLine("Data did not match.");
                    dataMatch = false;
                }
            }
            if(dataMatch)
            {
                Display.connectOpen = false;
                Console.WriteLine("OK button was hit, handing selected port [{0}] to RefForm", comPortBox.Text);
                RefForm.selectedPort = comPortBox.Text;
                RefForm.connectArduinoPort(); // connect to the arduino and begin a connection checking thread
                Display.arduinoForm.Hide();
            } else
            {
                Console.WriteLine("The COM port box was null, is we sent this then the prgoram would crash!");
                MessageBox.Show("No COM port selected, please select a COM port", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Cancel button hit.");
            Display.connectOpen = false;
            Display.arduinoForm.Hide();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Refresh button hit! Refreshing Ports");
            getSerialPorts();
            showRefreshString = true;
            timer.Enabled = true;
        }

        private void ArduinoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
