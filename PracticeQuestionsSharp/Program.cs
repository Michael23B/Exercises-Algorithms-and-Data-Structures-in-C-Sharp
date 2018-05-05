using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PracticeQuestionsSharp
{
    class Profiler
    {
        public static T Execute<T>(Func<T> method)
        {
            return method();
        }

        //Accepts a function and profiles the execution time
        public static T ProfileAndExecute<T>(Func<T> method)
        {
            Stopwatch watch = Stopwatch.StartNew();

            Console.WriteLine("Starting method...");

            var result = method();

            Console.WriteLine("Result: " + result);

            Console.WriteLine(watch.ElapsedMilliseconds + " milliseconds elapsed.");
            watch.Stop();

            return result;
        }
    }

    //Given an array of n distinct numbers, find all pairs that have a difference of k
    class Kdif
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

    class Program
    {
        public static void Main()
        {
            //K difference
            int[] array = new int[10000];
            for (int i = 0; i < array.Length; ++i) array[i] = i;

            Profiler.ProfileAndExecute(() => Kdif.FindKDifferencePairs1(array, 10));
            Profiler.ProfileAndExecute(() => Kdif.FindKDifferencePairs2(array, 10));
        }
    }
}
