﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace BattleBabs_Client
{
    public partial class Team_Entry : Form
    {
        string[] teamNames = new string[16];
        public Team_Entry()
        {
            InitializeComponent();
            Console.WriteLine("Loading team names from persist file");
            try
            {
                teamNames = File.ReadAllLines("./Teamnames.persist");
                for (int i = 0; i < teamNames.Length; i++)
                {
                    teamBox1.Items.Remove(i);
                    teamBox2.Items.Remove(i);
                }
                Console.WriteLine("Adding team names.");
                for (int i = 0; i < teamNames.Length; i++)
                {
                    teamBox1.Items.Insert(i, teamNames[i]);
                    teamBox2.Items.Insert(i, teamNames[i]);
                }
                teamBox1.Items.Insert(8, "[[[------Session Splitter------]]]");
                teamBox2.Items.Insert(8, "[[[------Session Splitter------]]]");
            } catch (Exception e)
            {
                Console.WriteLine("Exception! {0} {1}", e.Message, e.TargetSite);
            }
            Console.WriteLine("Complete.");

        }

        /// <summary>
        /// Thrown when the team entry form is closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Team_Entry_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("Team Entry Form is closing");
        }

        /// <summary>
        /// Thrown when the OK btton is hit, used to set the new teams
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okbutton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("OK Button hit.");
            Display.team1 = teamBox1.Text;
            Display.team2 = teamBox2.Text;
            Console.WriteLine("Team 1 is: " + Display.team1);
            Console.WriteLine("Team 2 is: " + Display.team2);
            Display.teamEntryForm.Hide();
            Display.teamOpen = false;
        }

        /// <summary>
        /// Thrown when the load button is hit, used to load team names
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadbutton_Click(object sender, EventArgs e)
        {
            loadNamesFile.ShowDialog(); // make a windows load file dialog
        }

        /// <summary>
        /// Thrown when the load file ok is hit, gets file path.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadNamesFile_FileOk(object sender, CancelEventArgs e)
        {
            Console.WriteLine("File Selected.");
            Console.WriteLine("File is: " + loadNamesFile.FileName);
            teamNames = File.ReadAllLines(loadNamesFile.FileName);
            File.WriteAllLines("./Teamnames.persist", teamNames);
            Console.WriteLine("Adding team names to the drop down boxes.");
            Console.WriteLine("Clearing drop down box values.");
            for (int i = 0; i < teamNames.Length; i++)
            {
                teamBox1.Items.Remove(i);
                teamBox2.Items.Remove(i);
            }
            Console.WriteLine("Adding team names.");
            for (int i = 0; i < teamNames.Length; i++)
            {
                teamBox1.Items.Insert(i, teamNames[i]);
                teamBox2.Items.Insert(i, teamNames[i]);
            }
            Console.WriteLine("Complete.");
        }
    }
}
