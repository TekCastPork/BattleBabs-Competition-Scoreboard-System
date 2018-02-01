using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;

namespace BattleBabs_Server
{
    class GameUtility
    {
        public static string[] names =  { "TestName", "Team2", "ImmaTeam3", "Haiku", "Bab", "Bhab", "Robitz", "LulBot", "TAS" }; // names used on leaderboard, name names for clent program
        public static int[] round =     { 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0  };
        public static int[] points =    { 1337 , 25843 , 0 , 0 , 0 , 0 , 0 , 0 , 0  };
        public static int[] rank =      { 1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9  };
        public static int[] index =     { 0 , 1 , 2 , 3 , 4 , 5 , 6 , 7 , 8  };
               static int[] previousScores;
        public static int[] parsedScores = { 0, 0 };
        public static string[] receivedNames = { "", "", };

        //TODO Finish sorting process
        //NOTE May need redoing due to new label system

        public static void sortLists()
        {
            Console.WriteLine("Now sorting ranks of each team.");
            Console.WriteLine("Beginning by putting each team's current score into a temporary holding array for later use.");
            
            for(int i = 0; i < points.Length; i++)
            {
                previousScores[i] = points[i];
                Console.WriteLine("Score {0} now in temp array at index {1}", points[i], i);
            }
            Console.WriteLine("Scores now put into holding variable. Points array is now being sorted.");
            Array.Sort(points); // sort the points array
            Console.WriteLine("Now using some searching to locate new locations for sorting purposes.");
            for(int i = 0; i < points.Length; i++)
            {
                for(int j = 0; j < previousScores.Length; j++)
                {
                    if(points[i].Equals(previousScores[j])) // if the points array indexed with i matches the previous scores array indexed with j ( a simple scan search really)
                    {
                        Console.WriteLine("We have found a match for the scores.");
                        Console.WriteLine("points[{0}] matches previousScores[{1}]. their scores were: {2} and {3}", i, j, points[i], previousScores[j]);
                        int difference = j - i;
                        Console.WriteLine("The difference between places is {0}.", difference);
                        Console.WriteLine("Now moving items.");
                        rank[i] = rank[i] + difference;

                    }
                }
            }
        }
    }
}
