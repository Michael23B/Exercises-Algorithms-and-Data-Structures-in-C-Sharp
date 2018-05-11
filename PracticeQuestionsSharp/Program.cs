using System;
using System.Security.Cryptography.X509Certificates;
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
            
            //Linked list implementation
            LinkedList<int> list = new LinkedList<int>();
            Node<int> constantTimeCheck = new Node<int>();
            for (int i = 0; i < 10000000; ++i)
            {
                list.Add(i);
                if (i == 5000000) constantTimeCheck = list.Tail;
            }

            Profiler.ProfileAndExecute(() => list.RemoveNode(constantTimeCheck));
            Profiler.ProfileAndExecute(() => list.Remove(5000002));
            //TODO: Add actual tests

            //Sum linked lists
            LinkedList<int> list1 = new LinkedList<int>(7);
            list1.Add(1);
            list1.Add(6);
            LinkedList<int> list2 = new LinkedList<int>(5);
            list2.Add(9);
            list2.Add(2);
            var list3 = SumLinkedLists.SumLists(list1, list2);
            list3.Print();
            */

            LinkedList<int> list = new LinkedList<int>(7);
            list.Add(7);
            list.Add(7);
            list.Add(1);
            list.Add(4);
            list.Add(1);
            list.Add(2);
            list.Add(7);

            Console.WriteLine($"{list.RemoveDuplicates()} items removed.");
            list.Print();
        }
    }
}