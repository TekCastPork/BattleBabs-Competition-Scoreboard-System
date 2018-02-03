using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleBabs_Server
{
    class Bracket
    {
        static string[] teams = new string[18];
        static string[] rotatingArray = new string[17];
        static string[] rotatingArray2 = new string[9];
        static string[] testResults = new string[20];
        static string fixedName;
        static int matchIndex = 0;
        static int testIndex = 0;
        /// <summary>
        /// Load 2 team name arrays into the 1 array in this class
        /// </summary>
        /// <param name="teams1"></param>
        /// <param name="teams2"></param>
        public static void loadTeams(string[] teams1, string[]teams2)
        {
            for(int i = 0; i < teams1.Length; i++)
            {
                teams[i] = teams1[i];
                teams[i + 9] = teams2[i];
                Console.WriteLine("[{0}] Name: {1}   [{2}] Name: {3}", i, teams[i], i + 9, teams[i + 9]);
            }
            Console.WriteLine("Complete.");
        }

        public static void generateCyclicMatchList()
        {
            Console.WriteLine("Generating arrays to use in a cyclic function for Round-Robin bracketing.");
            fixedName = teams[0]; //Cyclic algorithm has one item always fixed
            for(int i = 0; i < rotatingArray.Length; i++)
            {
                rotatingArray[i] = teams[i+1]; // load the rest into a new array for rotating
            }
            Console.WriteLine("Arrays generated");

        }

        public static void generateTestMatchList()
        {
            if (Display.sessionId == 0)
            {
                for (int i = 0; i < rotatingArray2.Length; i++)
                {
                    rotatingArray2[i] = GameUtility.names[i];
                }
            } else
            {
                for (int i = 0; i < rotatingArray2.Length; i++)
                {
                    rotatingArray2[i] = GameUtility.session2Names[i];
                }
            }
        }

        public static string[] getNextCyclicMatch()
        {
            Console.WriteLine("Getting next match");
            string[] returnArray = { fixedName, rotatingArray[0] };
            rotatingArray = rotateArray();
            return returnArray;
        }

        private static string[] rotateArray()
        {
            string[] holdingArray = new string[17];
            for(int i = 0; i < rotatingArray.Length; i++)
            Console.WriteLine("Now rotating array.");
            for (int i = 0; i < rotatingArray.Length; i++)
            {
                if(i+1 > rotatingArray.Length-1)
                {
                    Console.WriteLine("The attempted move would go out of bounds, shifting this value to the front instead.");
                    holdingArray[0] = rotatingArray[i];
                } else
                {
                    Console.WriteLine("The attmepted move will not go out of bound, shifting value 1 right");
                    holdingArray[i + 1] = rotatingArray[i];
                }
            }
            Console.WriteLine("Complete");
            return holdingArray;
        }

        private static string[] rotateArray2()
        {
            string[] holdingArray = new string[9];
            for (int i = 0; i < rotatingArray2.Length; i++)
                Console.WriteLine("Now rotating array.");
            for (int i = 0; i < rotatingArray2.Length; i++)
            {
                if (i + 2 > rotatingArray2.Length - 1)
                {
                    Console.WriteLine("The attempted move would go out of bounds, shifting this value to the front instead.");
                    holdingArray[0] = rotatingArray2[i];
                }
                else
                {
                    Console.WriteLine("The attmepted move will not go out of bound, shifting value 1 right");
                    holdingArray[i + 2] = rotatingArray2[i];
                }
            }
            Console.WriteLine("Complete");
            return holdingArray;
        }

        public static string[] getSession1NextMatch()
        {
            Console.WriteLine("Getting next match");
            if(matchIndex == 9)
            {
                matchIndex = 0;
            }
            string[] returnArray = { rotatingArray2[0 + matchIndex], rotatingArray2[8 - matchIndex] };
            rotatingArray2 =  rotateArray2();
            return returnArray;
        }

        public static void testAboveFunction()
        {
            string[] initial = getSession1NextMatch();
            Boolean matched1 = false;
            Boolean matched2 = false;
            string[] test = new string[2];
            test = getSession1NextMatch();
            testResults[0] = initial[0] + "," + initial[1];
            while (true)
            {                
                if(test[0].Equals(initial[0]))
                {
                    Console.WriteLine("First entry matched");
                    matched1 = true;
                } else
                {
                    matched1 = false;
                }
                if(test[1].Equals(initial[1]))
                {
                    Console.WriteLine("Second entry matched.");
                    matched2 = true;
                } else
                {
                    matched2 = false;
                }
                if(matched1 && matched2)
                {
                    Console.WriteLine("Both times matched! breaking (it took {0} times to reach this state)" , testIndex);
                    testResults[testIndex+1] = test[0] + "," + test[1];                
                } else
                {
                    testResults[testIndex+1] = test[0] + "," + test[1];
                    testIndex++;
                    Console.WriteLine("Passed test {0}", testIndex);
                    test = getSession1NextMatch();
                }
                if(testIndex == 20)
                {
                    break;

                }

            }
        }
    }
}
