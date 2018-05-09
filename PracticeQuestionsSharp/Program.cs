using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Resources;
using System.Text;

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

    public static class Helper
    {
        public static string SortString(string s)
        {
            char[] chars = s.ToArray();
            Array.Sort(chars);
            return new string(chars);
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

    //Check if a string is made of distinct characters
    class Unique
    {
        public static bool IsUnique(string s)
        {
            Dictionary<char, char> dict = new Dictionary<char, char>();

            foreach (char c in s)
            {
                if (!dict.TryAdd(c, c)) return false;
            }

            return true;
        }

        //Using no data structures
        public static bool IsUnique2(string s)
        {
            s = Helper.SortString(s);

            for (int i = 0; i < s.Length - 1; ++i)
            {
                if (s[i] == s[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
    }

    class Palindrome
    {
        //Determine whether a string is a permutation of a palindrom
        public static bool IsPalindromePermutation(string s)
        {
            int singleCharCount = 0;
            s = Helper.SortString(s).ToLower();

            for (int i = 0; i < s.Length; ++i)
            {
                if (i + 1 >= s.Length) break;
                Console.WriteLine($"Comparing {s[i]} and {s[i + 1]}");

                if (s[i] == s[i + 1]) i++;    //we can ignore the next character because it has a pair
                else
                {
                    singleCharCount++;
                    if (singleCharCount > 0 && s.Length % 2 == 0) return false; //cannot have unpaired character in an even length palindrome
                    if (singleCharCount > 1 && s.Length % 2 == 1) return false; //odd length palindromes have a single unpaired character
                }
            }

            return true;
        }
    }

    class Fib
    {
        //Recursive
        public static int Fibonacci1(int n)
        {
            if (n < 2) return n;
            return Fibonacci1(n - 1) + Fibonacci1(n - 2);
        }

        //Memoized
        public static int Fibonacci2(int n)
        {
            int[] fib = new int[n + 1];
            fib[0] = 0;
            fib[1] = 1;

            for (int i = 2; i <= n; ++i)
            {
                fib[i] = fib[i - 1] + fib[i - 2];
            }

            return fib[n];
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
            /*
            Profiler.ProfileAndExecute(() => Prime.PrimesToN1(2000000));
            Profiler.ProfileAndExecute(() => Prime.PrimesToN2(2000000));
            */

            //Unique string
            /*
            StringBuilder sb = new StringBuilder();
            for (char c = '0'; c < 127; ++c)
            {
                sb.Append(c);
            }

            string input = sb.ToString();
            Console.WriteLine(input);
            //input += '0';

            Profiler.ProfileAndExecute(() => Unique.IsUnique(input));
            Profiler.ProfileAndExecute(() => Unique.IsUnique2(input));
            */

            //Palindrome permutation
            /*
            Profiler.ProfileAndExecute(() => Palindrome.IsPalindromePermutation("acdbdacbs"));
            */

            //Fib

            Profiler.ProfileAndExecute(() => Fib.Fibonacci1(25));
            Profiler.ProfileAndExecute(() => Fib.Fibonacci2(75));
        }
    }
}