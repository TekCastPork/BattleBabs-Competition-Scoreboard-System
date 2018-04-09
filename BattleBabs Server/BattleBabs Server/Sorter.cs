using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleBabs_Server
{
    /// <summary>
    /// A WIP class to try placing ranks again
    /// </summary>
    class Sorter
    {
        /// <summary>
        /// This function will take in team names and scores and sort then from highest to lowest,
        /// returning the results in a 2D object array with names in row 1 and scores in row 2.
        /// </summary>
        /// <para name="inputNames"></para>
        /// <para name="scores"></para>
        /// <returns></returns>
        [Obsolete("Please use sortTeamData(List<GameUtility.teamData> teamData) instead in this branch")]
        public static object[] sortNames (string[] inputNames, int[] scores)
        {
            Logger.writeGeneralLog("Performing a sort.");
            string[] sortedNames = new string[inputNames.Length]; // array to hold names after sorting
            int[] sortedScores = new int[scores.Length]; // array to hold scores after sorting
            int[] inputScores = new int[scores.Length]; // used as the inputed scores, since we will need both a sorted and unsorted array
            for(int i = 0; i < scores.Length; i++)
            {
                inputScores[i] = scores[i]; // load in the scores to the input
                sortedNames[i] = inputNames[i];
                Logger.writeGeneralLog(String.Format("Input [{0}]  Score: {1}   Name: {2}", i, inputScores[i], sortedNames[i]));
            }
            // We will perform a bubble sort on the scores.
            // Doing so by coding it rather than a built in function will also allow the sorting of team names with
            // the scores.
            int bubbleLength = inputScores.Length; // get the input array length
            for(int i = 0; i < bubbleLength - 1; i++)
            {
                for(int j = 0; j < bubbleLength - i - 1; j++)
                {
                    Logger.writeGeneralLog(String.Format("Pass: {0} in rotation {1}\n", j, i));
                    Logger.writeGeneralLog(String.Format("Inputs:\n[0] Name: {0}\t\t\t Score: {1}\n" +
                        "[1] Name: {2}\t\t\t Score: {3}\n", sortedNames[j], inputScores[j], sortedNames[j + 1], inputScores[j + 1]));
                    if(inputScores[j] > inputScores[j + 1]) // if the current value is bigger than the one ahead
                    { //Swap them around
                        Logger.writeGeneralLog("Inputs were swapped.");
                        //make some holding variables
                        int swappedValue = inputScores[j];
                        string swappedName = sortedNames[j];
                        //swap the scores around
                        inputScores[j] = inputScores[j + 1];
                        inputScores[j + 1] = swappedValue;
                        //swap the names around
                        sortedNames[j] = sortedNames[j + 1];
                        sortedNames[j + 1] = swappedName;
                        //continue on
                        for (int k = 0; k < inputScores.Length; k++)
                        {
                            Logger.writeGeneralLog(String.Format("[{0}] Name: {1}\t\t\tScore: {2}", k, sortedNames[k], inputScores[k]));
                        }
                        Console.WriteLine("Running next pass...");
                    } else
                    {
                        Logger.writeGeneralLog("Inputs werent swapped");
                        for(int k = 0; k < inputScores.Length; k++)
                        {
                        Logger.writeGeneralLog(String.Format("[{0}] Name: {1}\t\t\tScore: {2}", k, sortedNames[k], inputScores[k]));
                        }
                    }
                }
            }
            Logger.writeGeneralLog("Final output of sort:\n\n");
            for (int k = 0; k < inputScores.Length; k++)
            {
                Logger.writeGeneralLog(String.Format("[{0}] Name: {1}   Score {2}", k, sortedNames[k], inputScores[k]));
            }
            Logger.writeGeneralLog("Sorting complete. Returning a object array");
            object[] returnArray = new object[18]; // a 18 object array, first 9 will be names, last 9 are scores
            Logger.writeGeneralLog("Created return array object");
            for(int i = 0; i < 9; i++) // create and fill the return array
            {
                returnArray[i] = sortedNames[i];
                returnArray[i + 9] = inputScores[i];
            }
            Logger.writeGeneralLog("Now returning...");
            
            return returnArray; // return
        }

        /// <summary>
        /// Sorts a teamData list based on the score
        /// </summary>
        /// <remarks>CAN ONLY SORT LISTS OF TYPE 'GameUtility.teamData'</remarks>
        /// <param name="teamData"></param>
        /// <returns></returns>
        public static List<GameUtility.teamData> sortTeamData(List<GameUtility.teamData> teamData)
        {
            Logger.writeGeneralLog("Now sorting team data based on score");
            List<GameUtility.teamData> sortedData = new List<GameUtility.teamData>();
            sortedData = GameUtility.teamEntries.OrderBy(x => x.score).ToList<GameUtility.teamData>();
            Logger.writeGeneralLog("Data sorted, returning");
            return sortedData;
        }
    }
}
