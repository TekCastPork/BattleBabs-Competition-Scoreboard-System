using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace BattleBabs_Client
{
    public partial class RefForm : Form
    {
        //VARIABLES//
        public static SerialPort arduinoport;
        public static string receivedData;
        public static string selectedPort = "";
        public static Thread heartBeat = new Thread(new ThreadStart(isConnectionAlive));

        //Variables related to point system (things like methods and worth)
        public static string[]  ScoreNames = { "Ping Pong", "Rubber Band", "Disable", "Shove" };
        public static int[]     ScoreValues = {          40,            20,        60,      30 };

        string lastTeam1; // used for broadcasting
        string lastTeam2; // used for broadcasting
        Thread guiUpdate;
        //These are used for subtraction mode on team scores, these can only be toggled via the checkboxes on the GUI
        Boolean subtractModeTeam1 = false;
        Boolean subtractModeTeam2 = false;

        //FUNCTIONS//
        public RefForm()
        {
            InitializeComponent();
            heartBeat.IsBackground = true; // make the arduino connection tester a background thread so it will exit when the program exits
            arduinoport = new SerialPort(); // create a SerialPort object to use with the arduino
            arduinoport.DataReceived += arduinoport_DataReceived; //Attach a function to the data received event
            guiUpdate = new Thread(new ThreadStart(updateComponents));
            guiUpdate.IsBackground = true; // make the GUI updating thread a background thread so it exits with the program
            guiUpdate.Start(); // start the GUI updater
            setTimeProgress(GameUtility.gameTime, true); // set the initial max game time
        }

        /// <summary>
        /// Updates the buttons for team 1 and 2 based on the stored scoring method names.
        /// </summary>
        public void updateScoreNames()
        {
            //these button arrays allow me to use a for loop making updating easier
            Button[] team1Buttons = { team1Ping, team1Band, team1Disable, team1Shove };
            Button[] team2Buttons = { team2Ping, team2Band, team2Disable, team2Shove };
            string errorText = "CORRUPT";

            //Begin updating
            for(int i = 0; i < team1Buttons.Length; i++)
            {
                try
                {
                    updateButton(team1Buttons[i], ScoreNames[i]);
                } catch (Exception e)
                {
                    Logger.writeExceptionLog(e);
                    updateButton(team1Buttons[i], errorText);
                }
            }
            for(int i = 0; i < team2Buttons.Length; i++)
            {
                try
                {
                    updateButton(team2Buttons[i], ScoreNames[i]);
                }
                catch (Exception e)
                {
                    Logger.writeExceptionLog(e);
                    updateButton(team2Buttons[i], errorText);
                }
            }
            //Updating complete
        }

        delegate void SetButtonCallback(Button button, string text);

        /// <summary>
        /// Updates the text on the buttons
        /// </summary>
        /// <param name="button"></param>
        /// <param name="text"></param>
        private void updateButton(Button button, string text)
        {
            
            if (button.InvokeRequired)
            {
                SetButtonCallback d = new SetButtonCallback(updateButton);
                this.Invoke(d, new object[] { button,text });
            }
            else
            {
                button.Text = text;
            }
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
                    GameUtility.pauseMatch();
                    GameUtility.makeSpeech("Warning: connection with arduino controller lost! Match Auto-pausing!");                    
                    MessageBox.Show("Lost Connection with Arduino Controller.\n" +
                        "Please ensure the cable is fully plugged in and the arduino is on,\n" +
                        "then reconnect the arduino using the Arduino button.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                }
                Thread.Sleep(100);
            }
        }

        delegate void SetTextCallback(string text);

        private void SetTeam1Text(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.teamLabel1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTeam1Text);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.teamLabel1.Text = text;
            }
        }

        private void SetTeam2Text(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.teamLabel2.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTeam2Text);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.teamLabel2.Text = text;
            }
        }

        private void updateComponents()
        {
            while (true)
            {
                setTimeProgress(GameUtility.gameTime, true);
                setTimeProgress(GameUtility.getGameTime(), false);
                subtractModeTeam1 = team1Toggle.Checked;
                subtractModeTeam2 = team2Toggle.Checked;
                lastTeam1 = Display.team1;
                lastTeam2 = Display.team2;
                SetTeam1Text(Display.team1);
                SetTeam2Text(Display.team2);
                updateScoreNames();
                Thread.Sleep(100);
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
                    parseReceivedData(receivedData);
                } catch (Exception w)
                {
                    Console.WriteLine("Exception caught! {0}", w.ToString());
                    Console.WriteLine("Data received was [{0}], we cannot parse a integer from that for some reason.", receivedData);
                }
            }
        }

        /// <summary>
        /// Parses data received from the arduino and fires off the proper event based on the parsed data
        /// </summary>
        /// <param name="data"></param>
        void parseReceivedData(string data)
        {
            switch (int.Parse(data)) //This switch handles all possible events from the arduino and has a failsafe incase we cannot setermine the error
            {
                case 0:
                    Console.WriteLine("Command received was a start match command. Starting Match");
                    setDataText("Match Start.");
                    GameUtility.beginMatch();
                    break;
                case 1:
                    Console.WriteLine("Command received was a team 1 band score.");
                    setDataText("Team 1 Rubber Bands");
                    if (GameUtility.matchState == 1)
                    {
                        if (subtractModeTeam1)
                        {
                            Console.WriteLine("Subtraction mode is activated on team 1! Subtracting instead of adding.");
                            Display.team1Score -= ScoreValues[0];
                        }
                        else
                        {
                            Display.team1Score += ScoreValues[0];
                        }
                    }
                    break;
                case 2:
                    Console.WriteLine("Command received was a team 1 ping pong score.");
                    setDataText("Team 1 Ping Pong");
                    if (GameUtility.matchState == 1)
                    {
                        if (subtractModeTeam1)
                        {
                            Console.WriteLine("Subtraction mode is activated on team 1! Subtracting instead of adding.");
                            Display.team1Score -= ScoreValues[1];
                        }
                        else
                        {
                            Display.team1Score += ScoreValues[1];
                        }
                    }
                    break;
                case 3:
                    Console.WriteLine("Command received was a team 1 push off score.");
                    setDataText("Team 1 Pushing");
                    if (GameUtility.matchState == 1)
                    {
                        if (subtractModeTeam1)
                        {
                            Console.WriteLine("Subtraction mode is activated on team 1! Subtracting instead of adding.");
                            Display.team1Score -= ScoreValues[3];
                        }
                        else
                        {
                            Display.team1Score += ScoreValues[3];
                        }
                    }
                    break;
                case 4:
                    Console.WriteLine("Command received was a team 1 disabled score.");
                    setDataText("Team 1 Disable");
                    if (GameUtility.matchState == 1)
                    {
                        if (subtractModeTeam1)
                        {
                            Console.WriteLine("Subtraction mode is activated on team 1! Subtracting instead of adding.");
                            Display.team1Score -= ScoreValues[2];
                        }
                        else
                        {
                            Display.team1Score += ScoreValues[2];
                        }
                    }
                    break;
                case 5:
                    Console.WriteLine("Command received was a team 2 band score.");
                    setDataText("Team 2 Rubber Bands");
                    if (GameUtility.matchState == 1)
                        if (GameUtility.matchState == 1)
                        {
                            if (subtractModeTeam2)
                            {
                                Console.WriteLine("Subtraction mode is activated on team 2! Subtracting instead of adding.");
                                Display.team2Score -= ScoreValues[0];
                            }
                            else
                            {
                                Display.team2Score += ScoreValues[0];
                            }
                        }
                    break;
                case 6:
                    Console.WriteLine("Command received was a team 2 ping pong score.");
                    setDataText("Team 2 Ping Pong");
                    if (GameUtility.matchState == 1)
                    {
                        if (subtractModeTeam2)
                        {
                            Console.WriteLine("Subtraction mode is activated on team 2! Subtracting instead of adding.");
                            Display.team2Score -= ScoreValues[1];
                        }
                        else
                        {
                            Display.team2Score += ScoreValues[1];
                        }
                    }
                    break;
                case 7:
                    Console.WriteLine("Command received was a team 2 push off score.");
                    setDataText("Team 2 Pushing");
                    if (GameUtility.matchState == 1)
                    {
                        if (subtractModeTeam2)
                        {
                            Console.WriteLine("Subtraction mode is activated on team 2! Subtracting instead of adding.");
                            Display.team2Score -= ScoreValues[3];
                        }
                        else
                        {
                            Display.team2Score += ScoreValues[3];
                        }
                    }
                    break;
                case 8:
                    Console.WriteLine("Command received was a team 2 disabled score.");
                    setDataText("Team 2 Disable");
                    if (GameUtility.matchState == 1)
                    {
                        if (subtractModeTeam2)
                        {
                            Console.WriteLine("Subtraction mode is activated on team 2! Subtracting instead of adding.");
                            Display.team2Score -= ScoreValues[2];
                        }
                        else
                        {
                            Display.team2Score += ScoreValues[2];
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Command was not determinable.");
                    break;
            }
        }

        /// <summary>
        /// This fuction will establish communication with the arduino by connecting to the user specified COM port
        /// </summary>
        public static void connectArduinoPort()
        {
            try
            {
                arduinoport.BaudRate = 9600; // set the baud rate to 9600. The Arduino MUST be using this baud rate.
                arduinoport.PortName = selectedPort; // set the COM port to use
                arduinoport.ReceivedBytesThreshold = 1; // set how many bytes are needed before a event is thrown from the port
                arduinoport.NewLine = "\n"; // set the new line carrier
                arduinoport.Open(); // Open the COM port for communications
                Console.WriteLine("Connected to arduino via COM port {0}", selectedPort);
                heartBeat.Start(); // start a watcher that checks the status of the connection.

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Caught! {0}", e.ToString());
            }
        }

        delegate void SetIntCallback(float number, Boolean statement);

        /// <summary>
        /// Used to edit the text of the recent event label, by either modifying directly or invoking if required
        /// </summary>
        /// <param name="text"></param>
        private void setDataText(string text)
        {
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

        /// <summary>
        /// Used to edit the value of the progress bar, can also change the max value of said bar
        /// </summary>
        /// <param name="time"></param>
        /// <param name="maxValue"></param>
        private void setTimeProgress(float time, Boolean maxValue)
        {
            if (this.timeBar.InvokeRequired)
            {
                SetIntCallback d = new SetIntCallback(setTimeProgress);
                try
                {
                    this.Invoke(d, new object[] { time, maxValue });
                }catch(Exception e)
                {
                    Console.WriteLine(e.StackTrace.ToString());
                }
            }
            else
            {
                if (maxValue)
                {
                    this.timeBar.Maximum = (int)time;
                }
                else
                {
                    this.timeBar.Value = (int)time;
                }
            }
        }

        /* PLEASE NOTE:
         * Below are the functions that handle adding points to each team.
         * The button references (button 0, button 1, ETC) are referring to the Referee Window GUI,
         * actual button position may vary based on the design of your controllers
         */


        /// <summary>
        /// Adds points to team 1 based off of the stored point settings for button 0 (topmost)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void team1Ping_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Team 1 scored via a ping pong ball. +40 points!");
            if (GameUtility.matchState == 1)
            {
                if (subtractModeTeam1)
                {
                    Console.WriteLine("Subtraction mode is activated on team 1! Subtracting instead of adding.");
                    Display.team1Score -= ScoreValues[0];
                }
                else
                {
                    Display.team1Score += ScoreValues[0];
                }
            }
        }

        /// <summary>
        /// Adds points to team 1 based off of the stored point settings for button 1 (second from top)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void team1Band_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Team 1 scored via a rubber band. +20 points!");
            if (GameUtility.matchState == 1)
            {
                if (subtractModeTeam1)
                {
                    Console.WriteLine("Subtraction mode is activated on team 1! Subtracting instead of adding.");
                    Display.team1Score -= ScoreValues[1];
                }
                else
                {
                    Display.team1Score += ScoreValues[1];
                }
            }
        }

        /// <summary>
        /// Adds points to team 1 based off of the stored point settings for button 2 (second from bottom)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void team1Disable_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Team 1 scored via disabling team 2. +60 points!");
            if (GameUtility.matchState == 1)
            {
                if (subtractModeTeam1)
                {
                    Console.WriteLine("Subtraction mode is activated on team 1! Subtracting instead of adding.");
                    Display.team1Score -= ScoreValues[2];
                }
                else
                {
                    Display.team1Score += ScoreValues[2];
                }
            }
        }

        /// <summary>
        /// Adds points to team 1 based off the stored point settings for button 3 (bottom-most)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void team1Shove_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Team 1 scored via shoving team 2. +30 points!");
            if (GameUtility.matchState == 1)
            {
                if (subtractModeTeam1)
                {
                    Console.WriteLine("Subtraction mode is activated on team 1! Subtracting instead of adding.");
                    Display.team1Score -= ScoreValues[3];
                }
                else
                {
                    Display.team1Score += ScoreValues[3];
                }
            }
        }

        /// <summary>
        /// Adds points to team 2 based off the stored point settings for button 0 (topmost)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void team2Ping_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Team 2 scored via a ping pong ball. +40 points!");
            if (GameUtility.matchState == 1)
            {
                if (subtractModeTeam2)
                {
                    Console.WriteLine("Subtraction mode is activated on team 2! Subtracting instead of adding.");
                    Display.team2Score -= ScoreValues[0];
                }
                else
                {
                    Display.team2Score += ScoreValues[0];
                }
            }
        }

        /// <summary>
        /// Adds points to team 2 based off of the stored point settings for button 1 (second from top)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void team2Band_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Team 2 scored via a rubber band. +20 points!");
            if (GameUtility.matchState == 1)
            {
                if (subtractModeTeam2)
                {
                    Console.WriteLine("Subtraction mode is activated on team 2! Subtracting instead of adding.");
                    Display.team2Score -= ScoreValues[1];
                }
                else
                {
                    Display.team2Score += ScoreValues[1];
                }
            }
        }

        /// <summary>
        /// Adds points to team 2 based off of the stored point settings for button 2 (second from bottom)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void team2Disable_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Team 2 scored via disabling team 2. +60 points!");
            if (GameUtility.matchState == 1)
            {
                if (subtractModeTeam2)
                {
                    Console.WriteLine("Subtraction mode is activated on team 2! Subtracting instead of adding.");
                    Display.team2Score -= ScoreValues[2];
                }
                else
                {
                    Display.team2Score += ScoreValues[2];
                }
            }
        }

        /// <summary>
        /// Adds points to team 2 based off of the stored point settings for button 3 (bottom-most)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void team2Shove_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Team 2 scored via shoving team 2. +30 points!");
            if (GameUtility.matchState == 1)
            {
                if (subtractModeTeam2)
                {
                    Console.WriteLine("Subtraction mode is activated on team 2! Subtracting instead of adding.");
                    Display.team2Score -= ScoreValues[3];
                }
                else
                {
                    Display.team2Score += ScoreValues[3];
                }
            }
        }

        /// <summary>
        /// Overrides team 1's score based on what is in the textbox for team 1 in the referee window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void team1Override_Click(object sender, EventArgs e)
        {
            try
            {
                Display.team1Score = int.Parse(team1Score.Text);
            } catch (Exception e1)
            {
                Console.WriteLine("Exception! {0}", e1.Message);
            }
        } // when the override button is clicked lets override team 1's score with whats in the textbox

        /// <summary>
        /// Overrides team 2's score based on what is in the textbox for team 2 in the referee window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void team2Override_Click(object sender, EventArgs e)// when the override button is clicked lets override team 2's score with whats in the textbox
        {
            try
            {
                Display.team2Score = int.Parse(team2Score.Text);
            }
            catch (Exception e1)
            {
                Console.WriteLine("Exception! {0}", e1.Message);
            }
        }

        /* PLEASE NOTE:
         * The functions below handle the starting, stopping, pausing, and resuming of the match.
         * The send score override function is also here.
         */


        /// <summary>
        /// Starts the match and allows the score buttons to be used
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Start Match button pressed.");
            lastTeam1 = Display.team1;
            lastTeam2 = Display.team2;
            GameUtility.beginMatch();          

        }

        /// <summary>
        /// Stops the match early and does not send the results to the leaderboard for that match unless the override send button is pressed
        /// Useful for overriding scores of teams because of fouls or penalties
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Stop button is pushed!");
            GameUtility.doSend = false;
            GameUtility.endMatch();
            GameUtility.makeSpeech("The match was stopped by the referee.");
            
        }

        /// <summary>
        /// Resumes a paused match
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resumeButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Resume button pushed.");
            GameUtility.resumeMatch();
        }

        /// <summary>
        /// Pauses a match, a paused match can only be resumed or stopped, not restarted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pauseButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("pause button pushed");
            GameUtility.pauseMatch();
        }

        /// <summary>
        /// Overrides the send function, to be used in combination with the stop match button.
        /// Useful for overriding scores because of penalties or fouls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendButton_Click(object sender, EventArgs e)
        {
            Networking.sendData(Display.team1Score + ":" + Display.team2Score + ":" + lastTeam1 + ":" + lastTeam2);
            GameUtility.doSend = false; // make the start button not send in order to prevent dupes
        } // used to force send data to the leaderboard
    }
}
