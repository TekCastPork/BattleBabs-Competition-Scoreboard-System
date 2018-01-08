using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Display
{
    public partial class Team_Entry : Form
    {
        string[] teamNames = new string[15];
        public Team_Entry()
        {
            InitializeComponent();

        }

        private void Team_Entry_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("Team Entry Form is closing");
        }

        private void okbutton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("OK Button hit.");
            Display.team1 = teamBox1.SelectedText;
            Display.team2 = teamBox2.SelectedText;
            Display.teamEntryForm.Hide();
        }

        private void loadbutton_Click(object sender, EventArgs e)
        {
            loadNamesFile.ShowDialog();
        }

        private void loadNamesFile_FileOk(object sender, CancelEventArgs e)
        {
            Console.WriteLine("File Selected.");
            Console.WriteLine("File is: " + loadNamesFile.FileName);
            teamNames = File.ReadAllLines(loadNamesFile.FileName);
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
