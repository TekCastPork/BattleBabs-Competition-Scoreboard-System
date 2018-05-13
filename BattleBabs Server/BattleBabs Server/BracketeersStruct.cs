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
using Combinatorics.Collections;

namespace BattleBabs_Server
{
    public partial class BracketeersStruct : Form
    {
        public static Boolean isShowing = false;
        struct bracketData
        {
            public string matchName;
            public Boolean played;
        };
        static List<bracketData> matchEntries = new List<bracketData>(36); // 36 matches max (9 teams at a time pick 2)
        static List<bracketData> loadedEntries = new List<bracketData>(36);
        public BracketeersStruct()
        {
            InitializeComponent();
        }

        public static void getCombinations(int sessionID, Boolean isLoading)
        { //Save data as MatchName:played
            if(isLoading)
            {
                Console.WriteLine("Program loading, reading from persistence and comparing to determine which to use");
                string[] loadedData = PersistenceStruct.loadBracketData();
                bracketData loadData = new bracketData();
                for(int i = 0; i < loadedData.Length; i++)
                {
                    string[] splitData = loadedData[i].Split(':');
                    loadData.matchName = splitData[0];
                    if (splitData[1].Equals("1"))
                    {
                        loadData.played = true;
                    } else
                    {
                        loadData.played = false;
                    }
                    loadedEntries.Insert(i, loadData);

                }
                Console.WriteLine("Data Loaded, now generating combination from team info");
                var teamNames = new List<string>();

                for(int i = 0; i < GameData.teamEntries.Count; i++)
                {
                    teamNames.Insert(i, GameData.teamEntries.ElementAt(i).name);
                }
                var combinations = new Combinations<string>(teamNames,2);
                int index = 0;
                bracketData data = new bracketData();
                foreach(var v in combinations)
                {
                    data.matchName = String.Join(" VS ", v);
                    data.played = false;
                    matchEntries.Insert(index, data);
                    index++;
                }
                Console.WriteLine("Lists made, comparing.");
                Boolean match = true;
                for(int i = 0; i < matchEntries.Count; i++)
                {
                    if(loadedEntries.ElementAt(i).matchName.Equals(matchEntries.ElementAt(i).matchName))
                    {
                        Console.WriteLine("Match");
                    } else
                    {
                        Console.WriteLine("MISMATCH");
                        match = false;
                        break;
                    }
                }
                if(match)
                {
                    Console.WriteLine("Games matches, using persistence.");
                } else
                {
                    Console.WriteLine("Games mismatch, using created.");
                }

            } else
            {
                Console.WriteLine("Program not loading, creating bracket.");
            }
        }

        private void BracketeersStruct_FormClosing(object sender, FormClosingEventArgs e)
        {
            isShowing = false;
            e.Cancel = true;
            this.Hide();
        }
    }
}
