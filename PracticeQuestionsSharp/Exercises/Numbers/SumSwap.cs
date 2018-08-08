using System.Collections.Generic;
using System.Linq;

namespace PracticeQuestionsSharp.Exercises.Numbers
{
    public static class SumSwap
    {
        //Given two arrays of integers, find a pair of values (one value from each array) that you
        // can swap to 
        public static ArrayIndexes FindIndexToSwap(int[] arr1, int[] arr2)
        {
            ArrayIndexes result = new ArrayIndexes {FirstArrIndex = -1, SecondArrIndex = -1};
            //Dictionary to store value, index
            Dictionary<int, int> dict1 = new Dictionary<int, int>();
            Dictionary<int, int> dict2 = new Dictionary<int, int>();
            int sum1 = 0, sum2 = 0;

            //Get the sums of each array and add each element to a dictionary
            for (int i = 0; i < arr1.Length; ++i)
            {
                dict1.TryAdd(i, arr1[i]);
                sum1 += arr1[i];
            }
            for (int i = 0; i < arr2.Length; ++i)
            {
                dict2.TryAdd(i, arr2[i]);
                sum2 += arr2[i];
            }

            foreach (int i in dict1.Values)
            {
                int currSum1 = sum1 - i;
                int currSum2 = sum2 + i;

                //The difference between the arrays after the first element is moved
                int j = currSum2 - currSum1;
                //Odd differences will imbalance the arrays so we can't use them
                if (j % 2 != 0) continue;
                //We need a value half the difference, to even the arrays out
                j /= 2;

                if (dict2.ContainsValue(j))
                {
                    result.FirstArrIndex = dict1.First(pair => pair.Value == i).Key;
                    result.SecondArrIndex = dict2.First(pair => pair.Value == j).Key;
                    return result;
                }
            }

            return result;
        }
    }

    public class ArrayIndexes
    {
        public int FirstArrIndex { get; set; }
        public int SecondArrIndex { get; set; }
    }
}
