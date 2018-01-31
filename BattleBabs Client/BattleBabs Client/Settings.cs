using System;
using System.Windows.Forms;
using System.IO;

namespace BattleBabs_Client
{
    public partial class Settings : Form
    {
        Boolean loadSuccess = false;
        string[] settings = { "", "", "", "", "" };
        string[] loadedSettings = { "", "", "", "", "" };
        /*
         * Settings as follows:
         * [0] IP
         * [1] Port
         * [2] Match Duration
         * [3] Seed
         * [4] Use seed?
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
                    if (int.Parse(loadedSettings[4]) == 1)
                    {
                        GameUtility.useSeeded = true;
                        GameUtility.setSeed();
                    }
                    else
                    {
                        GameUtility.useSeeded = false;
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
                File.WriteAllLines("./config.cfg", settings);
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
                return File.ReadAllLines("./config.cfg");
                
            } catch(Exception e)
            {
                Console.WriteLine("Exception! {0}. The file may not exist or may be corrupt.", e.ToString());
                loadSuccess = false;
                return null;
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Applying setting changes.");
            GameUtility.alterGameTime((int)timerCount.Value);
            GameUtility.useSeeded = seedBox.Checked;
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
            settings[3] = GameUtility.SEED.ToString();
            settings[2] = GameUtility.gameTime.ToString();
            settings[1] = Networking.port.ToString();
            settings[0] = Networking.IP;
            GameUtility.setSeed();
            this.Hide();
            saveSettings();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
