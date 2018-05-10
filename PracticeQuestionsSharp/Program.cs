using System;
using System.Text;
using PracticeQuestionsSharp.DataStructures;
using PracticeQuestionsSharp.Exercises;
using PracticeQuestionsSharp.Helper;

namespace PracticeQuestionsSharp
{
    class Program
    {
        public static void Main()
        {
            /*
            //K difference
            int[] array = new int[10000];
            for (int i = 0; i < array.Length; ++i) array[i] = i;

            Profiler.ProfileAndExecute(() => Kdif.FindKDifferencePairs1(array, 10));
            Profiler.ProfileAndExecute(() => Kdif.FindKDifferencePairs2(array, 10));

            //Primes
            Profiler.ProfileAndExecute(() => Prime.PrimesToN1(200000));
            Profiler.ProfileAndExecute(() => Prime.PrimesToN2(200000));

            //Unique string
            StringBuilder sb = new StringBuilder();
            for (char c = '0'; c < 127; ++c)
            {
                sb.Append(c);
            }

            string input = sb.ToString();
            //input += '0';

            Profiler.ProfileAndExecute(() => UniqueChars.IsUnique(input));
            Profiler.ProfileAndExecute(() => UniqueChars.IsUnique2(input));

            //Palindrome permutation
            Profiler.ProfileAndExecute(() => PalindromePermutation.IsPalindromePermutation("acdbdacbs"));
            
            //Fib
            Profiler.ProfileAndExecute(() => Fibonacci.Fibonacci1(25), 100);
            Profiler.ProfileAndExecute(() => Fibonacci.Fibonacci2(75), 1000000);
            */
            //Linked list implementation
            LinkedList<int> list = new LinkedList<int>(1);

            list.Add(2);
            list.Add(3);
            list.Add(4);

            list.At(2).Data = 2;
            list.Remove(list.Find(4));
            list.Remove(list.At(0));
            list.Remove(list.At(0));
            list.Remove(list.At(0));

            list.Add(2);
            list.Add(22);
            list.Add(222);
            list.AddBefore(23, list.Find(222));

            list.Clear();

            list.AddBefore(0, 0);
            Console.WriteLine(list.Tail.Data);
            list.AddBefore(-1, 0);

            list.Print();
        }
    }
}