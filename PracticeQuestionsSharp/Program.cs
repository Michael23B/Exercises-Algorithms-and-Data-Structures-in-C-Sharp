using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PracticeQuestionsSharp
{
    class Profiler
    {
        public static T Execute<T>(Func<T> method)
        {
            return method();
        }

        //Accepts a function and logs the execution time
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

    //Print all primes to n
    class Prime
    {
        //Brute force
        public static List<int> PrimesToN1(int n)
        {
            bool primeFlag = true;
            List<int> primes = new List<int>();

            for (int i = 1; i < n; ++i)
            {
                for (int j = 2; j < Math.Sqrt(i); ++j)
                {
                    if (i % j == 0)
                    {
                        primeFlag = false;
                        break;
                    }
                }

                if (primeFlag) primes.Add(i);
                else primeFlag = true;
            }

            //foreach (int i in primes) Console.Write(i + " ");
            Console.WriteLine("");
            return primes;
        }

        //Memoize
        //Only divide by the previous prime numbers.
        //The runtime difference between this and the standard function isnt obvious until very large numbers
        public static List<int> PrimesToN2(int n)
        {
            bool primeFlag = true;
            List<int> primes = new List<int>();
            primes.Add(2);

            for (int i = 3; i < n; ++i)
            {
                foreach (int prime in primes)
                {
                    if (prime > Math.Sqrt(i)) break;
                    if (i % prime == 0)
                    {
                        primeFlag = false;
                        break;
                    }
                }

                if (primeFlag) primes.Add(i);
                else primeFlag = true;
            }

            primes.Prepend(1);

            //foreach (int i in primes) Console.Write(i + " ");
            Console.WriteLine("");
            return primes;
        }
    }

    class Program
    {
        public static void Main()
        {
            //K difference
            /*
            int[] array = new int[10000];
            for (int i = 0; i < array.Length; ++i) array[i] = i;

            Profiler.ProfileAndExecute(() => Kdif.FindKDifferencePairs1(array, 10));
            Profiler.ProfileAndExecute(() => Kdif.FindKDifferencePairs2(array, 10));
            */

            //Primes
            Profiler.ProfileAndExecute(() => Prime.PrimesToN1(2000000));
            Profiler.ProfileAndExecute(() => Prime.PrimesToN2(2000000));
        }
    }
}