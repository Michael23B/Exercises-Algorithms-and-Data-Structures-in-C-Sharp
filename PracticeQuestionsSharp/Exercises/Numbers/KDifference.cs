using System;
using System.Collections.Generic;

namespace PracticeQuestionsSharp.Exercises.Numbers
{
    //Given an array of n distinct numbers, find all pairs that have a difference of k.
    public static class KDifference
    {
        //Brute force solution
        public static int FindKDifferencePairs1(int[] arr, int k)
        {
            int count = 0;

            for (int i = 0; i < arr.Length - 1; ++i)
            {
                for (int j = i + 1; j < arr.Length; ++j)
                {
                    if (Math.Abs(arr[i] - arr[j]) == k) count++;
                }
            }

            return count;
        }

        //Hash solution
        public static int FindKDifferencePairs2(int[] arr, int k)
        {
            int count = 0;
            Dictionary<int, int> dict = new Dictionary<int, int>();

            foreach (int i in arr)
                dict.Add(i, i);

            foreach (int i in arr)
                if (dict.ContainsKey(i + k))
                    count++;

            return count;
        }
    }
}