using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using PracticeQuestionsSharp.Algorithms;
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

            //Sum linked lists
            LinkedList<int> list1 = new LinkedList<int>(7);
            list1.Add(1);
            list1.Add(6);
            LinkedList<int> list2 = new LinkedList<int>(5);
            list2.Add(9);
            list2.Add(2);
            var list3 = SumLinkedLists.SumLists(list1, list2);
            list3.Print();
            
            //Remove linked list duplicates
            LinkedList<int> dupeList = new LinkedList<int>(7) { 7,7,1,4,1,2,7 };

            Console.WriteLine($"{dupeList.RemoveDuplicates()} items removed.");
            dupeList.Print();
            
            //Loop detection
            LinkedList<int> circularList = new LinkedList<int>(1) { 2,3,4,5 };
            circularList.Add(2);
            circularList.Add(3);
            circularList.Add(4);
            circularList.Add(5);

            circularList.Tail.Next = circularList.Tail.Prev.Prev;

            Profiler.ProfileAndExecute(() => circularList.DetectLoop().Data);
            
            //Sorting stack (using two stacks only)
            Stack<int> stackToSort = new Stack<int>();
            for (int i = 2500; i >= 0; --i) stackToSort.Push(i);

            Profiler.ProfileAndExecute(() => stackToSort.Sort());
            
            int[] arr = {1, 5, 43, 1, 2, 6, 1, 3};
            Profiler.ProfileAndExecute(() => arr = arr.MergeSort().ToArray());
            //foreach (int i in arr) Console.Write($"{i},");

            List<int> list = new List<int>();
            for (int i = 500000; i >= 0; --i) list.Add(i);
            Profiler.ProfileAndExecute(() => list = list.MergeSort());
            //foreach (int i in list) Console.Write($"{i},");
            */
            //Animal shelter queue
            Console.WriteLine(DateTime.Now);
            QueueAnimalShelter animalQueue = new QueueAnimalShelter();
            animalQueue.Enqueue("Cat1", QueueAnimalShelter.Species.Cat)
                .Enqueue("Cat2", QueueAnimalShelter.Species.Cat)
                .Enqueue("Dog", QueueAnimalShelter.Species.Dog)
                .Enqueue("Dog2", QueueAnimalShelter.Species.Dog)
                .Enqueue("Dog3", QueueAnimalShelter.Species.Dog)
                .Enqueue("Cat3", QueueAnimalShelter.Species.Cat);

            QueueAnimalShelter animalQueue2 = new QueueAnimalShelter();
            animalQueue2.Enqueue("Cat1", QueueAnimalShelter.Species.Cat)
                .Enqueue("Cat2", QueueAnimalShelter.Species.Cat)
                .Enqueue("Dog", QueueAnimalShelter.Species.Dog)
                .Enqueue("Dog2", QueueAnimalShelter.Species.Dog)
                .Enqueue("Dog3", QueueAnimalShelter.Species.Dog)
                .Enqueue("Cat3", QueueAnimalShelter.Species.Cat);


            while (!animalQueue.IsDogsEmpty) Console.WriteLine(animalQueue.DequeueDog().Name);
            while (!animalQueue.IsCatsEmpty) Console.WriteLine(animalQueue.DequeueCat().Name);

            while (!animalQueue2.IsEmpty) Console.WriteLine(animalQueue2.DequeueAny().Name);
        }
    }
}