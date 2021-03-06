﻿using System;
using System.Windows.Forms;
using System.IO;

namespace BattleBabs_Client
{
    public partial class Settings : Form
    {
        Boolean loadSuccess = false;
        public static Boolean isShowing = false;
        string[] settings = { "", "", "", "", "","","","false" };
        string[] loadedSettings = { "", "", "", "", "","","","false" };
        /*
         * Settings as follows:
         * [0] IP
         * [1] Port
         * [2] Match Duration
         * [3] Seed
         * [4] Use seed?
         * [5] Fullscreen state
         * [6] Competition Name
         * [7] Show whats new popup
         */

        public Settings()
        {
            InitializeComponent();
            loadedSettings = loadSettings();
            if (loadSuccess)
            {
                Console.WriteLine("Settings were loaded properly! Now applying");
                try
                {
                    Networking.IP = loadedSettings[0];
                    Networking.port = int.Parse(loadedSettings[1]);
                    GameUtility.gameTime = int.Parse(loadedSettings[2]);
                    GameUtility.SEED = int.Parse(loadedSettings[3]);
                    GameUtility.compName = loadedSettings[6];
                    if(loadedSettings[7].Equals("true"))
                    {
                        GameUtility.showChanges = true;
                        showChanges.Checked = true;
                    } else if (loadedSettings[7].Equals("false"))
                    {
                        GameUtility.showChanges = false;
                        showChanges.Checked = false;
                    } else
                    {
                        GameUtility.showChanges = true;
                        showChanges.Checked = true;
                    }
                    timerCount.Value = GameUtility.gameTime;
                    compName.Text = GameUtility.compName;
                    if(int.Parse(loadedSettings[5]) == 1)
                    {
                        Display.screenMode = true;
                        fullScreenBox.Checked = true;
                    } else
                    {
                        Display.screenMode = false;
                        fullScreenBox.Checked = false;
                    }
                    if (int.Parse(loadedSettings[4]) == 1)
                    {
                        GameUtility.useSeeded = true;
                        seedBox.Checked = true;
                        GameUtility.setSeed();
                    }
                    else
                    {
                        GameUtility.useSeeded = false;
                        seedBox.Checked = false;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception! {0}. Something wierd happened while trying to apply settings.", e.Message);
                }
                Console.WriteLine("Settings loaded and applied.");
            }
        }

        public void saveSettings()
        {
            try
            {
                Console.WriteLine("Saving settings to config.");
                File.WriteAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Scoreboard", "config.cfg"), settings);
            } catch (Exception e)
            {
                Console.WriteLine("Exception! {0}", e.Message);
                Console.WriteLine("Saving failed!");
            }
        }

        public string[] loadSettings()
        {
            try
            {
                loadSuccess = true;
                return File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BattleBabs Scoreboard", "config.cfg"));
                
            } catch(Exception e)
            {
                Console.WriteLine("Exception! {0}. The file may not exist or may be corrupt.", e.ToString());
                MessageBox.Show("Configuration file was unable to be loaded, it may be missing or corrupt.\n" +
                    "IP settings, match duration, and RNG seed settings will not load for this session.", "NON-FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                loadSuccess = false;
                return null;
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Applying setting changes.");
            GameUtility.alterGameTime((int)timerCount.Value);
            GameUtility.useSeeded = seedBox.Checked;
            Display.screenMode = fullScreenBox.Checked;
            try // this try will keep the parsing of the SEED value from crashing the program incase the user enters a letter or symbol
            {
                GameUtility.SEED = int.Parse(seedText.Text);
                GameUtility.setSeed();
            } catch (Exception e1)
            {
                Console.WriteLine("Exception! {0}", e1.ToString());
            }
            if (GameUtility.useSeeded)
            {
                settings[4] = "1";
            } else
            {
                settings[4] = "0";
            }
            if(fullScreenBox.Checked)
            {
                settings[5] = "1";
            } else
            {
                settings[5] = "0";
            }
            if(compName.Text.Equals(GameUtility.compName))
            {
                settings[6] = compName.Text;
            } else
            {
                settings[6] = compName.Text;
                GameUtility.compName = compName.Text;
            }
            settings[3] = GameUtility.SEED.ToString();
            settings[2] = GameUtility.gameTime.ToString();
            settings[1] = Networking.port.ToString();
            settings[0] = Networking.IP;
            GameUtility.setSeed();
            if(showChanges.Checked == true)
            {
                settings[7] = "true";
            } else
            {
                settings[7] = "false";
            }
            this.Hide();
            saveSettings();
            isShowing = false;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
