﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Combinatorics.Collections;
using System.Drawing.Text;
using System.IO;
using System.Threading;

namespace BattleBabs_Server
{
    public partial class Bracketeers : Form
    {
        static string[] allCombinations = new string[36]; // We can only run this class for one session! DO NOT PASS BOTH SESSION NAMESETS
        static Boolean[] isChosen = new Boolean[36]; // used with random to make sure dupes arent picked, since going one by one is the combinations would make many teams have multiple battles side by side
        static int index = 0;
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

        public void updateBoolean(string name1, string name2, Boolean matchComplete)
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
                        isChosen[i] = true;
                    } else
                    {
                        Console.WriteLine("name 2 did not match at this index {0}", i);
                    }
                } else if(splitString[1].Equals(name1))
                {
                    Console.WriteLine("name 1 has found itself at index {0}, now testing name 2. BTW it was reversed in the scoreboard", i);
                    if (splitString[0].Equals(name2))
                    {
                        Console.WriteLine("name 2 matches at this index ({0})", i);
                        isChosen[i] = true;
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
            Thread.Sleep(200);
            int index = 0;
            foreach(Label c in Controls.OfType<Label>())
            {
                updateText(c, allCombinations[index]);
                updateColor(c, isChosen[index]);
                index++;
            }
        }
        private void updateColor(Label labelToUpdate, Boolean isDone)
        {
            if (isDone)
            {
                if (labelToUpdate.InvokeRequired)
                {
                    SetColorCallback d = new SetColorCallback(updateColor);
                    this.Invoke(d, new object[] { labelToUpdate });
                }
                else
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
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    labelToUpdate.Text = text;
                }
        }

        private void Bracketeers_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Get all possible combinations of the names. ONLY PASS 1 SESSION TO THIS FUNCTION AND ENSURE IT IS IN A TRY CATCH
        /// </summary>
        /// <param name="names"></param>
        /// <returns></returns>
        public static void getCombinations(string[] names)
        {
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
        }
    }
}
