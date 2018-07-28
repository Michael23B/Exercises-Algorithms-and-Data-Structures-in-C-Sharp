using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using PracticeQuestionsSharp.Algorithms;
using PracticeQuestionsSharp.DataStructures;
using PracticeQuestionsSharp.Exercises;
using PracticeQuestionsSharp.Exercises.Binary_Tree;
using PracticeQuestionsSharp.Exercises.Bits;
using PracticeQuestionsSharp.Exercises.Dynamic_Programming;
using PracticeQuestionsSharp.Exercises.Linked_List;
using PracticeQuestionsSharp.Exercises.Numbers;
using PracticeQuestionsSharp.Exercises.Searching_and_Sorting;
using PracticeQuestionsSharp.Exercises.Stack;
using PracticeQuestionsSharp.Exercises.Strings;
using PracticeQuestionsSharp.Helper;

//This file is just for testing solutions

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
            
            var randTree = new BinaryTreeRandomElement<int>();

            randTree.Insert(2).Insert(4).Insert(1).Insert(6).Insert(3).Insert(0).Insert(5);

            int[] intCounts = {0,0,0,0,0,0,0};
            int[] intCounts2 = {0,0,0,0,0,0,0};

            for (int i = 0; i < 10000; ++i) intCounts[randTree.GetRandom()]++;
            for (int i = 0; i < 10000; ++i) intCounts2[randTree.GetRandom2()]++;

            Console.WriteLine("GetRandom() results:");
            for (int i = 0; i < 7; ++i) Console.WriteLine($"{i}: {intCounts[i]}");
            Profiler.ProfileAndExecute(() => randTree.GetRandom(), 1000000, "GetRandom()");

            Console.WriteLine("GetRandom2() results:");
            for (int i = 0; i < 7; ++i) Console.WriteLine($"{i}: {intCounts2[i]}");
            Profiler.ProfileAndExecute(() => randTree.GetRandom2(), 1000000, "GetRandom2()");

            int[] sorted = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}; //12, 18
            int[] sortedSubtree = {1,2,3,4,5};
            BinaryTreeNodeWithParent<int> generatedIntTree = BinaryTreeFromSortedArray.GenerateIntegerTree(sorted);
            BinaryTreeNodeWithParent<int> generatedIntSubTree = BinaryTreeFromSortedArray.GenerateIntegerTree(sortedSubtree);

            var currNode = generatedIntTree;
            while (currNode.Left != null) currNode = currNode.Left;
            while (currNode != null)
            {
                Console.WriteLine(currNode.Data);
                currNode = currNode.Successor();
            }

            Console.WriteLine(generatedIntSubTree.IsSubtreeOf(generatedIntTree));

            var pathsWithSum = generatedIntTree.PathsWithSum(9);

            if (pathsWithSum != null)
            {
                foreach (var path in pathsWithSum)
                {
                    foreach (var node in path)
                    {
                        Console.Write($"{node.Data}, ");
                    }
                    Console.WriteLine();
                }
            }
            
            int[] sortedArrRotated = { 6, 7, 0, 1, 2, 4, 5, };

            Console.WriteLine(RotatedArrayMin.MinimumInRotatedSortedArray(sortedArrRotated));
            
            Console.WriteLine(StringToInt.Atoi("     +123k4"));
            
            DataStructures.LinkedList<int> list1 = new DataStructures.LinkedList<int>();
            DataStructures.LinkedList<int> list2 = new DataStructures.LinkedList<int>();
            DataStructures.LinkedList<int> list3 = new DataStructures.LinkedList<int>();
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            list1.Add(4);
            list2.Add(0);
            list2.Add(2);
            list3.Add(3);
            list3.Add(3);
            list3.Add(7);

            var newlist = MergeKSortedLists.MergeSortedLists(new[] {list1.Head, list2.Head, list3.Head});

            newlist.Print();

            string text = "0011001011";
            string pattern = "0101";

            Console.Write(text.KMPFindIndexOf(pattern));
            
            MinStack<int> minStack = new MinStack<int>();
            minStack.Push(5).Push(2).Push(9).Push(2).Push(1);

            while (!minStack.IsEmpty)
            {
                Console.Write(minStack.Min());
                minStack.Pop();
            }
            
            DataStructures.LinkedList<int> intList = new DataStructures.LinkedList<int>();
            intList.Add(3);
            intList.Add(-1);
            intList.Add(8);
            intList.Add(4);
            intList.Add(5);

            intList = intList.PartitionAround1(5);
            intList.Print();
            

            UInt32 uint1 = 64;
            UInt32 uint2 = 8;
            Console.Write(uint2.InsertBitInto(uint1, 1, 5));
            
            Console.WriteLine(0.00001.DoubleToBinaryString());
            Console.WriteLine(0.5.DoubleToBinaryString());
            Console.WriteLine(Convert.ToString(0, 2));
            Console.WriteLine(0.LongestSequence());
            Console.WriteLine(Convert.ToString(1, 2));
            Console.WriteLine(1.LongestSequence());
            Console.WriteLine(Convert.ToString(2, 2));
            Console.WriteLine(2.LongestSequence());
            Console.WriteLine(Convert.ToString(3, 2));
            Console.WriteLine(3.LongestSequence());
            Console.WriteLine(Convert.ToString(8, 2));
            Console.WriteLine(8.LongestSequence());
            Console.WriteLine(Convert.ToString(52, 2));
            Console.WriteLine(52.LongestSequence());
            //Explain what the following code does: ((n & (n -1)) == 0)
            int n;
            Console.WriteLine("Enter a non-integer to quit.");
            while (true)
            {
                try { n = int.Parse(Console.ReadLine()); }
                catch (Exception) { break; }
                Console.WriteLine($"{Convert.ToString(n, 2)} & {Convert.ToString(n - 1, 2)} == 0 ? {(n & (n - 1)) == 0}");
            }
            //The code checks if n is a power of two since powers of two are represented as a 1 followed only by 0s.
            //Taking 1 away removes the first 1 and changes all the 0s to 1s meaning the & matches no digits and results in 0.
            
            Console.WriteLine(0.IsPowerOfTwo());
            Console.WriteLine(1.IsPowerOfTwo());
            Console.WriteLine(2.IsPowerOfTwo());
            Console.WriteLine(3.IsPowerOfTwo());
            Console.WriteLine(4.IsPowerOfTwo());
            Console.WriteLine(512.IsPowerOfTwo());
            Console.WriteLine(511.IsPowerOfTwo());
            Console.WriteLine(513.IsPowerOfTwo());
            Console.WriteLine(1024.IsPowerOfTwo());
            
            Console.WriteLine(Convert.ToString(1046, 2));
            Console.WriteLine("00" + Convert.ToString(333, 2));
            Console.WriteLine(1046.CountFlipsToConvertTo(333));
            

            Console.WriteLine(10.SwapBits());
            Console.WriteLine(8.SwapBits());
            Console.WriteLine(0.SwapBits());
            Console.WriteLine(1.SwapBits());
            

            byte[] screen = new byte[20];
            DrawLine.DrawBitLine(ref screen, 8, 25, 55, 0);

            foreach (byte b in screen)
            {
                Console.Write('[');
                Console.Write(Convert.ToString(b, 2));
                Console.Write("], ");
            }

            int[] unshuffled = {1, 2, 3, 4, 5, 6, 7, 8};
            int[] shuffled = (int[])unshuffled.Shuffle();

            foreach (int i in shuffled)
            {
                Console.Write($"{i},");
            }
            
            List<Interval> intervalList = new List<Interval>
            {
                new Interval {Max = 18, Min = 15},
                new Interval {Max = 3, Min = 1},
                new Interval {Max = 10, Min = 8},
                new Interval {Max = 6, Min = 2}
            };

            intervalList = (List<Interval>)intervalList.MergeOverlappingIntervals();
            foreach (Interval i in intervalList)
            {
                Console.Write($"[{i.Min},{i.Max}],");
            }
            
            //Number of step permutations, non memoized vs memoized
            for (int i = 0; i < 22; ++i)
            {
                Console.WriteLine(Profiler.ProfileAndExecute(() => StaircaseSteps.StepPermutations(i), 1, "Non memoized"));
                Console.WriteLine(Profiler.ProfileAndExecute(() => StaircaseSteps.StepPermutationsMemoized(i), 1 , "Memoized"));
            }
            
            int[] orderedDistinctNumbers = {-5, -3, -2, -1, 0, 2, 5, 7, 10, 22};
            Console.WriteLine(MagicIndex.FindMagicIndexBinarySearch(orderedDistinctNumbers));
            
            int[] orderedNonDistinctNumbers = { -5, -5, 0, 0, 0, 3, 4, 4, 8, 8 };
            Console.WriteLine(MagicIndex.FindNonDistinctMagicIndexBinarySearch(orderedNonDistinctNumbers));
            
            var pSet = PowerSet.GetPowerSet(new[] { 'a', 'b', 'c', 'd' });
            Console.WriteLine("Powerset for set:");
            foreach (var subSet in pSet)
            {
                Console.Write('[');
                foreach (var i in subSet) Console.Write(i == subSet.Last() ? $"{i}" : $"{i},");
                Console.WriteLine(subSet == pSet.Last() ? "]" : "],");
            }
            
            bool[,] grid = new bool[10, 10];
            string[,] printedGrid = new string[10, 10];

            for (int i = 0; i < grid.GetLength(0); ++i)
            {
                for (int j = 0; j < grid.GetLength(1); ++j)
                {
                    grid[i, j] = true;
                    printedGrid[i, j] = "O";
                }
            }

            grid[8, 9] = false;
            grid[7, 8] = false;
            grid[0, 1] = false;
            grid[1, 1] = false;
            grid[0, 2] = false;
            grid[3, 0] = false;
            grid[3, 1] = false;
            grid[2, 5] = false;
            grid[3, 4] = false;

            printedGrid[8, 9] = "X";
            printedGrid[7, 8] = "X";
            printedGrid[0, 1] = "X";
            printedGrid[1, 1] = "X";
            printedGrid[0, 2] = "X";
            printedGrid[3, 0] = "X";
            printedGrid[3, 1] = "X";
            printedGrid[2, 5] = "X";
            printedGrid[3, 4] = "X";

            var pathToBottomRight = grid.FindPathThroughGrid();

            foreach (var xy in pathToBottomRight)
            {
                //Console.Write($"[{xy.Y},{xy.X}],");
                printedGrid[xy.Y, xy.X] = "+";
            }

            for (int i = 0; i < printedGrid.GetLength(0); ++i)
            {
                for (int j = 0; j < printedGrid.GetLength(1); ++j)Console.Write(printedGrid[i, j]);
                Console.WriteLine();
            }
            
            Console.WriteLine(MultiplyWithBitShifting.Multiply(5, 6));
            Console.WriteLine(MultiplyWithBitShifting.Multiply(6, 5));
            Console.WriteLine(MultiplyWithBitShifting.Multiply(100, 10));
            Console.WriteLine(MultiplyWithBitShifting.Multiply(23, 1));
            Console.WriteLine(MultiplyWithBitShifting.Multiply(15, 3));
            Console.WriteLine(MultiplyWithBitShifting.Multiply(5, -6));
            Console.WriteLine(MultiplyWithBitShifting.Multiply(-6, -5));
            Console.WriteLine(MultiplyWithBitShifting.Multiply(-100, 10));
            Console.WriteLine(MultiplyWithBitShifting.Multiply(-23, 1));
            Console.WriteLine(MultiplyWithBitShifting.Multiply(-15, -3));
            
            Dictionary<string, int> permCountMap = new Dictionary<string, int>();
            string stringForPermutations = "aaddac";
            var permutations = stringForPermutations.NonDistinctStringPermutations();
            Console.WriteLine(permutations.Count);
            permutations.Sort();
            foreach (var p in permutations)
            {
                if (!permCountMap.TryAdd(p, 0)) permCountMap[p]++;
                Console.WriteLine(p);
            }

            var duplicates = permCountMap.Where(kvp => kvp.Value > 0).ToList();

            Console.WriteLine(duplicates.Count);
            foreach (var d in duplicates) Console.WriteLine(d);
            
            TowersOfHanoi.TowersOfHanoiRecursive(8);
            
            var parenPerms = ParenthesesPermutations.ParenthesesPermutationsFor(5);

            foreach (string s in parenPerms) Console.WriteLine(s);
            
            var coinPerms = Coins.RepresentNCents(50);

            foreach (List<int> coins in coinPerms)
            {
                Console.Write('[');
                foreach (int c in coins) Console.Write($"{c},");
                Console.Write("]\n");
            }
            
            int[,] canvas =
            {
                {1, 1, 1, 2, 2, 1, 2, 2, 2},
                {1, 1, 1, 2, 2, 2, 2, 2, 2},
                {1, 1, 1, 2, 6, 6, 6, 4, 5},
                {1, 1, 1, 2, 2, 1, 2, 2, 2}
            };

            var canvas2 = (int[,])canvas.Clone();
            canvas2.FillColour(2, 3, 5);

            Console.WriteLine("Original:");
            for (int i = 0; i < canvas.GetLength(0); ++i)
            {
                Console.Write('[');
                for (int j = 0; j < canvas.GetLength(1); ++j)
                {
                    Console.Write($"{canvas[i, j]},");
                }
                Console.Write("]\n");
            }

            Console.WriteLine("Painted:");
            for (int i = 0; i < canvas2.GetLength(0); ++i)
            {
                Console.Write('[');
                for (int j = 0; j < canvas2.GetLength(1); ++j)
                {
                    Console.Write($"{canvas2[i,j]},");
                }
                Console.Write("]\n");
            }
            
            int?[] a = {1, 3, 5, 6, 7, null, null, null, null};
            int?[] b = {2, 4, 9, 10};

            a.MergeSortedArrays(b);

            foreach (int? i in a) Console.Write($"{i},");
            
            int[] swapNumbers = {1, 2, 3, 4, 5};

            SwapNumbersInPlace.SwapNumbers(swapNumbers, 1, 3);

            foreach (int i in swapNumbers) Console.Write(i);
            
            int[,] ticTacToeBoard = {{0, 0, 2, 0}, {0, 1, 2, 1}, { 1, 0, 2, 1 }, { 1, 0, 2, 1 } };
            Console.WriteLine(TicTacToeWinner.FindWinner(ticTacToeBoard));
            */
            int[] differenceA = {3, 152, 1, 26, 2};
            int[] differenceB = {10, 222, 13, -51};

            Console.WriteLine(SmallestDifference.FindSmallestDif(differenceA, differenceB));
        }
    }
}