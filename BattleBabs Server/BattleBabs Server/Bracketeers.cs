using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Combinatorics.Collections;
using System.Drawing.Text;
using System.IO;
using System.Threading;

namespace BattleBabs_Server
{
    public partial class Bracketeers : Form
    {
        
        public static string[] allCombinations = new string[36]; // We can only run this class for one session! DO NOT PASS BOTH SESSION NAMESETS
        public static Boolean[] isChosen = new Boolean[36]; // used with random to make sure dupes arent picked, since going one by one is the combinations would make many teams have multiple battles side by side
        static int index = 0;
        public static Boolean isShowing = false;
        Thread updateThread;

        public Bracketeers(string[] names) // we will need to pass the initial names to the class when we make it, allowing to to call it on creation for the first time.
        {
            InitializeComponent();
            getCombinations(names);
            PrivateFontCollection privateFonts = new PrivateFontCollection();
            privateFonts.AddFontFile(Path.Combine(Application.StartupPath, "GODOFWAR.TTF"));
            Font titleFont = new Font(privateFonts.Families[0], 20);
            updateThread = new Thread(new ThreadStart(updateComponents));
            updateThread.IsBackground = true;
            updateThread.Start();
        }        

        delegate void SetColorCallback(Label labelToUpdate, Boolean isDone);
        delegate void SetTextCallback(Label labelToUpdate, string text);

        public static void updateBoolean(string name1, string name2, Boolean matchComplete)
        {
            for(int i = 0; i < allCombinations.Length; i++)
            {
                string[] splitString = allCombinations[i].Split(',');
                if(splitString[0].Equals(name1))
                {
                    Console.WriteLine("name 1 has found itself at index {0}, now testing name 2", i);
                    if(splitString[1].Equals(name2))
                    {
                        Console.WriteLine("name 2 matches at this index ({0})", i);
                        Console.WriteLine("WE HAVE FOUND THE MATCH FOR PHASE 1-A");
                        isChosen[i] = true;
                        Console.WriteLine("Set Color flag raised!");
                    } else
                    {
                        Console.WriteLine("name 2 did not match at this index {0}", i);
                    }
                }
                else if(splitString[1].Equals(name1))
                {
                    Console.WriteLine("name 1 has found itself at index {0}, now testing name 2. BTW it was reversed in the scoreboard", i);
                    if (splitString[0].Equals(name2))
                    {
                        Console.WriteLine("name 2 matches at this index ({0})", i);
                        Console.WriteLine("WE HAVE FOUND THE MATCH FOR PHASE 1-B");
                        isChosen[i] = true;
                        Console.WriteLine("Set Color flag raised!");
                    }
                    else
                    {
                        Console.WriteLine("name 2 did not match at this index {0}", i);
                    }
                }
            }
        }

        private void updateComponents()
        {
            while (true)
            {
                Thread.Sleep(200);
                int index = 0;
                foreach (Label c in Controls.OfType<Label>())
                {
                    updateText(c, allCombinations[index]);
                    updateColor(c, isChosen[index]);
                    index++;
                }
            }
        }
        private void updateColor(Label labelToUpdate, Boolean isDone)
        {
            if (labelToUpdate.InvokeRequired)
            {
                SetColorCallback d = new SetColorCallback(updateColor);
                this.Invoke(d, new object[] { labelToUpdate, isDone });
            }
            else
            {
                if (isDone == false)
                {
                    labelToUpdate.ForeColor = Color.Black;
                } else
                {
                    labelToUpdate.ForeColor = Color.LawnGreen;
                }
                    
            }
        }

        private void updateText(Label labelToUpdate, string text)
        {
            if (labelToUpdate.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(updateText);
                this.Invoke(d, new object[] { labelToUpdate, text });
            }
            else {

                string actualString;
                string[] splitIntake;
                splitIntake = text.Split(',');
                actualString = String.Join(" VS ", splitIntake);
                labelToUpdate.Text = actualString;
            }
                
        }

        private void Bracketeers_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Bracket loading.");
            Logger.writeGeneralLog("Bracket form is loading, loading from persistence file");
            load();
        }

        static Boolean firstRun = true;
        /// <summary>
        /// Get all possible combinations of the names. ONLY PASS 1 SESSION TO THIS FUNCTION AND ENSURE IT IS IN A TRY CATCH
        /// TODO: change getCombinations so that when the session is changed it saves the current bracket to respective session persistence,
        /// then checks the newly provided names against the other persistence, if they are the same load from persistence instead,
        /// otherwise do normal load.
        /// </summary>
        /// <param name="names"></param>
        /// <returns></returns>
        public static void getCombinations(string[] names)
        {
            string[] loadedTestingNames = new string[36];
            if (firstRun)
            {
                Logger.writeWarningLog("First Run! Skipping initial save");
                firstRun = false;
            }
            else
            {
                Logger.writeGeneralLog("Session changing, saving current session!");
                save(true);
            }            
            Boolean namesSame = true;
            Logger.writeGeneralLog("getCombinations has been called.");
            Logger.writeWarningLog("Given names may be the same as the opposite persistence file, a check will be performed.");
            if(Display.sessionId == 1)
            {
                Logger.writeGeneralLog("New session is session 1(2), reading from rounds2.persist");
                loadedTestingNames = File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard", "rounds2.persist"));
                for(int i = 0; i < loadedTestingNames.Length; i++)
                {
                    Logger.writeGeneralLog(loadedTestingNames[i]);
                }
            } else
            {
                Logger.writeGeneralLog("New session is session 0(1), reading from rounds.persist");
                loadedTestingNames = File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard", "rounds.persist"));
                for (int i = 0; i < loadedTestingNames.Length; i++)
                {
                    Logger.writeGeneralLog(loadedTestingNames[i]);
                }
            }
            string[] loadedCombos;
            string[] loadedFlags = new string[36];
            if(Display.sessionId == 1)
            {
                Logger.writeGeneralLog("Reading from Session 2 persistence files (rounds2 and flags2");
                loadedCombos = File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard", "rounds2.persist"));
                loadedFlags = File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard", "flags2.persist"));
            } else
            {
                Logger.writeGeneralLog("Reading from Session 1 persistence files (rounds and flags)");
                loadedFlags = File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard", "flags.persist"));
                loadedCombos = File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard", "rounds.persist"));
            }
            Logger.writeGeneralLog("Testing loaded flags to make sure there is data.");
            if(loadedFlags.Length == 0)
            {
                Logger.writeCriticalLog("Loaded flags loaded with length 0! NO FLAGS WERE LOADED! Loading default flags into memory and file");
                string[] defaultFlags = { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" };
                if (Display.sessionId == 1)
                {
                    File.WriteAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard", "flags2.persist"), defaultFlags);
                    loadedFlags = File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard", "flags2.persist"));
                }
                else
                {
                    File.WriteAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard", "flags.persist"), defaultFlags);
                    loadedFlags = File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard", "flags.persist"));
                }
                
            }
            Logger.writeGeneralLog("Creating all possible combinations of teams: " + String.Join(", ", names));
            index = 0;
            var teamNames = new List<string>(names.ToList<string>());
            var c = new Combinations<string>(teamNames, 2);
            foreach (var v in c)
            {
                allCombinations[index] = string.Join(",", v);
                isChosen[index] = false;
                index++;
            }
            Console.WriteLine("All combinations generated.");
            Logger.writeGeneralLog("Generated all possible combinations successfully.");
            for (int i = 0; i < isChosen.Length; i++)
            {
                isChosen[i] = false;
                Console.WriteLine("flag at index {0} reset.", i);
            }
            //CHECK IF SAME
            Logger.writeGeneralLog("Printing out names");
            for (int i = 0; i < loadedTestingNames.Length; i++)
            {
                Logger.writeGeneralLog(String.Format("{0} : {1}", loadedTestingNames[i], allCombinations[i]));
                if (loadedTestingNames[i].Equals(allCombinations[i]))
                {
                    Logger.writeGeneralLog(String.Format("[{0}] Names matched",i));
                }
                else
                {
                    Logger.writeWarningLog("Name was different, setting sameName to false and breaking for loop.");
                    namesSame = false;
                }
            }
            if(namesSame == true)
            {
                Logger.writeGeneralLog("Names were matched! Overridding with peristents.");
                for(int i = 0; i < allCombinations.Length; i++)
                {
                    try
                    {
                        allCombinations[i] = loadedTestingNames[i];
                    } catch (Exception e)
                    {
                        Logger.writeExceptionLog(e);
                        break;
                    }
                }
                for(int i = 0; i < isChosen.Length; i++)
                {
                   if(loadedFlags[i].Equals("1"))
                    {
                        isChosen[i] = true;
                    } else
                    {
                        isChosen[i] = false;
                    }
                }
            } else
            {
                Logger.writeGeneralLog("Names werent matched, not overriding.");
                for (int i = 0; i < loadedFlags.Length; i++)
                {
                    if (loadedFlags[i].Equals("1"))
                    {
                        isChosen[i] = true;
                    }
                    else
                    {
                        isChosen[i] = false;
                    }
                }
            }
        }

        private void Bracketeers_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("Cancelling close operation, hiding instead");
            Logger.writeWarningLog("Bracket form was told to close, but closing would dispose its object! Cancelling close operation and hiding instead.");
            e.Cancel = true;
            save(false);
            this.Hide();
            isShowing = false;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Resetting flags");
            for(int i = 0; i < isChosen.Length; i++)
            {
                isChosen[i] = false;
                Console.WriteLine("flag at index {0} reset.", i);
            }
        }

        private static void save(Boolean sub1)
        {
            if (sub1 == false)
            {
                Logger.writeGeneralLog("Saving combinations to persistence file incase the program crashes");
                try
                {
                    if (Display.sessionId == 0)
                    {
                        Logger.writeGeneralLog("The session was 0, saving to rounds.persist");
                        File.WriteAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard", "rounds.persist"), allCombinations);
                    }
                    else
                    {
                        Logger.writeGeneralLog("The session was 1, saving to rounds2.persist");
                        File.WriteAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard", "rounds2.persist"), allCombinations);
                    }
                }
                catch (Exception e)
                {
                    Logger.writeExceptionLog(e);
                }
                string[] booleanWrite = new string[36];
                for (int i = 0; i < booleanWrite.Length; i++)
                {
                    if (isChosen[i] == true)
                    {
                        booleanWrite[i] = "1";
                    }
                    else
                    {
                        booleanWrite[i] = "0";
                    }
                }
                Logger.writeGeneralLog("Complete, now saving played flags to persistence file.");
                try
                {
                    if (Display.sessionId == 0)
                    {
                        Logger.writeGeneralLog("The session was 0, saving to flags.persist");
                        File.WriteAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard", "flags.persist"), booleanWrite);
                    }
                    else
                    {
                        Logger.writeGeneralLog("The session was 1, saving to flags2.persist");
                        File.WriteAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard", "flags2.persist"), booleanWrite);
                    }
                }
                catch (Exception e)
                {
                    Logger.writeExceptionLog(e);
                }
            } else
            {
                Logger.writeGeneralLog("Saving combinations to persistence file incase the program crashes");
                Logger.writeWarningLog("sub1 flag is true! subtracting 1 from session ID for saving!");
                try
                {
                    if (Display.sessionId -1 == 0)
                    {
                        Logger.writeGeneralLog("The session was 0, saving to rounds.persist");
                        File.WriteAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard", "rounds.persist"), allCombinations);
                    }
                    else
                    {
                        Logger.writeGeneralLog("The session was 1, saving to rounds2.persist");
                        File.WriteAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard", "rounds2.persist"), allCombinations);
                    }
                }
                catch (Exception e)
                {
                    Logger.writeExceptionLog(e);
                }
                string[] booleanWrite = new string[36];
                for (int i = 0; i < booleanWrite.Length; i++)
                {
                    if (isChosen[i] == true)
                    {
                        booleanWrite[i] = "1";
                    }
                    else
                    {
                        booleanWrite[i] = "0";
                    }
                }
                Logger.writeGeneralLog("Complete, now saving played flags to persistence file.");
                try
                {
                    if (Display.sessionId -1 == 0)
                    {
                        Logger.writeGeneralLog("The session was 0, saving to flags.persist");
                        File.WriteAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard", "flags.persist"), booleanWrite);
                    }
                    else
                    {
                        Logger.writeGeneralLog("The session was 1, saving to flags2.persist");
                        File.WriteAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard", "flags2.persist"), booleanWrite);
                    }
                }
                catch (Exception e)
                {
                    Logger.writeExceptionLog(e);
                }

            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Save button hit, attempting to save to persist files. Note: this only saves the current session currently.");
            Logger.writeGeneralLog("Save button on the bracket frm was clicked, saving current combinations and played flags to persistence files");
            Logger.writeWarningLog("This will only save the current session!");
            save(false);
        }

        private void load()
        {
            string[] loadedNames = new string[36];
            string[] loadedFlags = new string[36];
            Boolean canContinue = false;
            Logger.writeGeneralLog("Reading from persistence files...");
            try
            {
                if (Display.sessionId == 0)
                {
                    Logger.writeGeneralLog("Session is 0, loading from rounds.persist and flags.persist");
                    loadedNames = File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard", "rounds.persist"));
                    loadedFlags = File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard", "flags.persist"));
                } else
                {
                    Logger.writeGeneralLog("Session is 1, loading from rounds2.persist and flags2.persist");
                    loadedNames = File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard", "rounds2.persist"));
                    loadedFlags = File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Leaderboard", "flags.persist"));
                }
                Logger.writeGeneralLog("Read from persistence files successfully. Setting can continue flag to true");
                canContinue = true;
            } catch(Exception e)
            {
                Logger.writeExceptionLog(e);
            }
            if (canContinue)
            {
                Logger.writeGeneralLog("Can Continue flag was true, now loading names from persistence file into memory");
                for (int i = 0; i < loadedNames.Length; i++)
                {
                    allCombinations[i] = loadedNames[i];
                }
                Logger.writeGeneralLog("Complete! Loading played flags into memory");
                Console.WriteLine("Name combinations loaded, beginning to load played flags");
                for (int i = 0; i < loadedFlags.Length; i++)
                {
                    if (loadedFlags[i].Equals("1"))
                    {
                        isChosen[i] = true;
                    }
                    else
                    {
                        isChosen[i] = false;
                    }
                }
                Console.WriteLine("Played flags have been loaded.");
                Logger.writeGeneralLog("Played flags have been loaded.");

            } else
            {
                Logger.writeWarningLog("Can Continue flag for loading of combinations and played flags was set false! reading of persistence files must have failed. Loading names and combinations based on current sessionId");
                if(Display.sessionId == 0)
                {
                    getCombinations(GameUtility.names);
                } else
                {
                    getCombinations(GameUtility.session2Names);
                }
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Load button hit, attempting to load from persist files.");
            Logger.writeGeneralLog("The load button was clicked on the brackets form, loading from persistence file");
            load();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            Logger.writeWarningLog("Refresh button for bracket window was clicked. Forcibly refreshing the screen via re-calculating the combinations.");
            if(Display.sessionId == 0)
            {
                getCombinations(GameUtility.names);
            } else
            {
                getCombinations(GameUtility.session2Names);
            }
        }

        private void forceSaveSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Save button hit, attempting to save to persist files. Note: this only saves the current session currently.");
            Logger.writeGeneralLog("Save button on the bracket frm was clicked, saving current combinations and played flags to persistence files");
            Logger.writeWarningLog("This will only save the current session!");
            save(false);
        }

        private void forceLoadSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Load button hit, attempting to load from persist files.");
            Logger.writeGeneralLog("The load button was clicked on the brackets form, loading from persistence file");
            load();
        }

        private void resetPlayedMatchesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Resetting flags");
            for (int i = 0; i < isChosen.Length; i++)
            {
                isChosen[i] = false;
                Console.WriteLine("flag at index {0} reset.", i);
            }
        }

        private void forceRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.writeWarningLog("Refresh button for bracket window was clicked. Forcibly refreshing the screen via re-calculating the combinations.");
            if (Display.sessionId == 0)
            {
                getCombinations(GameUtility.names);
            }
            else
            {
                getCombinations(GameUtility.session2Names);
            }
        }
    }
}
