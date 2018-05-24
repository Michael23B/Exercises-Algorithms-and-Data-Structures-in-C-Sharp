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
            Profiler.ProfileAndExecute(() => Prime.PrimesToN3(200000));

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
            
            SimpleGraph<int> graph = new SimpleGraph<int>();
            graph.Add(3).Add(4).Add(5).Add(6).Add(7).Add(8).Add(9);
            graph.Link(3, 4).Link(3, 5);
            graph.Link(4, 6).Link(4, 7);
            graph.Link(5, 8);
            graph.Link(7, 9);

            var path = graph.DFSPathTo(8);

            Console.WriteLine("Depth-first");
            foreach (var node in path) Console.WriteLine(node.Data);
            
            var minHeap = new MinHeap<int>(new[] {1,2,3,4,5,6,7,8,9,10});
            minHeap.Insert(5).Insert(3).Insert(8).Insert(1).Insert(4).Insert(10);

            var depthLists = minHeap.GetDepthLists();

            foreach (var list in depthLists)
            {
                foreach (var node in list) Console.Write($"{node}, ");
                Console.WriteLine("");
            }

            while (!minHeap.IsEmpty) Console.WriteLine(minHeap.ExtractMin());
            
            //Heapsort
            var unsorted = new List<int>(1000);
            for (int i = 1000; i > 0; --i) unsorted.Add(i);
            Profiler.ProfileAndExecute(() => unsorted.HeapSortAscending(), 1000);
            var priorityQueue = new PriorityQueue<int>();
            priorityQueue.Enqueue(3, 2).Enqueue(5, 2).Enqueue(1).Enqueue(6, 6).Enqueue(4, 4);

            while (!priorityQueue.IsEmpty) Console.WriteLine(priorityQueue.Dequeue());
            
            var BST = new BinarySearchTree<int>();
            BST.Insert(3).Insert(4).Insert(5).Insert(7).Insert(1).Insert(10)
               .Insert(2).Insert(6).Insert(8).Insert(-2).Insert(-3).Insert(-1).Insert(9);
            BST.Remove(1);
            BST.PrintAll();
            
            List<int> intlist = new List<int> {10, 20, 30, 40, 50};
            Console.WriteLine(intlist.Search(50));
            
            var intAvl = new AVLTree<int>();
            intAvl.Insert(3).Insert(6).Insert(2).Insert(1).Insert(8).Insert(9).Insert(-3).Insert(-2);

            intAvl.PrintAll(true);
            Console.WriteLine("-----");
            intAvl.Remove(3);
            intAvl.PrintAll(true);
            Console.WriteLine("-----");
            //TODO: add avl tests
            */
            var randTree = new BinaryTreeRandomElement<int>();

            randTree.Insert(3).Insert(5).Insert(-1);

            Console.WriteLine(randTree.GetRandom());
        }
    }
}