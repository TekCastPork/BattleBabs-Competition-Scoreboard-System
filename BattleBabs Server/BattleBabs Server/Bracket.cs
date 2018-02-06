using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Combinatorics.Collections;

namespace BattleBabs_Server
{
    class Bracket
    {
        static string[] allCombinations = new string[40]; // We can only run this class for one session! DO NOT PASS BOTH SESSION NAMESETS
        static Boolean[] isChosen = new Boolean[40]; // used with random to make sure dupes arent picked, since going one by one is the combinations would make many teams have multiple battles side by side
        static Random chooser = new Random();
        /// <summary>
        /// Get all possible combinations of the names. ONLY PASS 1 SESSION TO THIS FUNCTION AND ENSURE IT IS IN A TRY CATCH
        /// </summary>
        /// <param name="names"></param>
        /// <returns></returns>
        public static void getCombinations(string[] names)
        {
            int index = 0;
            var teamNames = new List<string>(names.ToList<string>());
            var c = new Combinations<string>(teamNames, 2);
            foreach(var v in c)
            {
                allCombinations[index] = string.Join(",", v);
                index++;
            }
            Console.WriteLine("All combinations generated.");
        }
    }
       
}
