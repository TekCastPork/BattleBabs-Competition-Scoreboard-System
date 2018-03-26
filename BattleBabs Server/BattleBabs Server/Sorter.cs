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
        /// <param name="inputNames"></param>
        /// <param name="scores"></param>
        /// <returns></returns>
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
                    if(inputScores[j] > inputScores[j + 1]) // if the current value is bigger than the one ahead
                    { //Swap them around
                        //make some holding variables
                        Logger.writeGeneralLog(String.Format("Swapping {0} with {1}", inputScores[j], inputScores[j + 1]));
                        Logger.writeGeneralLog(String.Format("Swapping {0} with {1}", sortedNames[j], sortedNames[j + 1]));
                        int swappedValue = inputScores[j];
                        string swappedName = inputNames[j];
                        //swap the scores around
                        inputScores[j] = inputScores[j + 1];
                        inputScores[j + 1] = swappedValue;
                        //swap the names around
                        sortedNames[j] = sortedNames[j + 1];
                        sortedNames[j + 1] = swappedName;
                        //continue on
                        Logger.writeGeneralLog(String.Format("New Name in location [{0}] is: {1}", j, sortedNames[j]));
                        Logger.writeGeneralLog(String.Format("New Value in location [{0}] is: {1}", j, inputScores[j]));
                        
                        
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
    }
}
