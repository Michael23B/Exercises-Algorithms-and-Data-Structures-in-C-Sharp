# Exercises, Algorithms and Data Structures in C# 
This project is a collection of my solutions to programming questions. Most of the questions either came from [this book](http://www.crackingthecodinginterview.com/) or from various programming websites. Since they're my own solutions, I can't guarantee every single one is correct. I test them to make sure the solution works however there are surely plenty of mistakes that I've missed.

The following are the solutions categorized:


## [Algorithms](/PracticeQuestionsSharp/Algorithms/)
[Binary Search](/PracticeQuestionsSharp/Algorithms/BinarySearch.cs)

`Generic implementation of a binary search algorithm.`

[Breadth First Search](/PracticeQuestionsSharp/Algorithms/BreadthFirstSearch.cs)

`Iterative depth-first search that returns the node with the target data.`

[Depth First Search](/PracticeQuestionsSharp/Algorithms/DepthFirstSearch.cs)

`Iterative depth-first search that returns the node with the target data.`

[Fisher Yates Shuffle](/PracticeQuestionsSharp/Algorithms/FisherYatesShuffle.cs)

`Implementation of Fishes-Yates shuffle algorithm.`

[Heap Sort](/PracticeQuestionsSharp/Algorithms/HeapSort.cs)

`Heap sort generic implementation.`

[Merge Sort](/PracticeQuestionsSharp/Algorithms/MergeSort.cs)

`Merge sort generic implementation.`


## [Binary Tree](/PracticeQuestionsSharp/Exercises/Binary%20Tree/)
[Paths With Sum](/PracticeQuestionsSharp/Exercises/Binary%20Tree/PathsWithSum.cs)

`Given a binary tree, find all paths (from a node to a leaf) that sum to a given number.`

[Binary Tree From Sorted Array](/PracticeQuestionsSharp/Exercises/Binary%20Tree/BinaryTreeFromSortedArray.cs)

`Creates a binary tree and returns the root from a sorted array.`

[Random Element](/PracticeQuestionsSharp/Exercises/Binary%20Tree/RandomElement.cs)

`Create a Binary Tree class from scratch with Insert, Remove and Find methods.In addition, add a GetRandom() method that returns a random node. All nodes should be equally likely to be chosen.`

[Successor](/PracticeQuestionsSharp/Exercises/Binary%20Tree/Successor.cs)

`Write an algorithm to find the "next" node (in-order successor) of a given node in a binary search tree. You may assume that each node has a link to it's parent.`

[Is Subtree](/PracticeQuestionsSharp/Exercises/Binary%20Tree/IsSubtree.cs)

`Find whether a binary tree is a subtree of another binary tree. This implementation defines subtree as sharing the same data for each node and the same children for each node (including null children).`

[Depth Lists](/PracticeQuestionsSharp/Exercises/Binary%20Tree/DepthLists.cs)

`Return a list for each depth of a binary tree. Array-based tree with IEnumerable implemented to move through the array in order.`


## [Bits](/PracticeQuestionsSharp/Exercises/Bits/)
[Draw Line](/PracticeQuestionsSharp/Exercises/Bits/DrawLine.cs)

`A monochrome screen is stored as a single array of bytes, allowing eight consecutive pixels to be stored in one byte.  The screen has width w, where w is divisible by 8 (that is, no byte will be split across rows).  The height of the screen, of course, can be derived from the length of the array and the width. Implement a function that draws a horizontal line from(xl, y) to(x2, y). Function signiture: drawLine(byte[] screen, int width, int x, int x2, int y).`

[Binary To String](/PracticeQuestionsSharp/Exercises/Bits/BinaryToString.cs)

`Given a real number between 0 and 1 that is passed in as a double, print the binary representation. If it cannot be represented in 32 characters, print "ERROR.".`

[Longest Bit Sequence](/PracticeQuestionsSharp/Exercises/Bits/LongestBitSequence.cs)

`Given an int, you can flip exactly one bit from 0 to 1. Find the longest sequence of 1s you could create.`

[Power Of Two](/PracticeQuestionsSharp/Exercises/Bits/PowerOfTwo.cs)

`The code checks if n is a power of two since powers of two are represented as a 1 followed only by 0s. Taking 1 away removes the first 1 and changes all the 0s to 1s meaning the & matches no digits and results in 0. Since n == 0 also returns true but isn't a power of 2 we need to check for n != 0 first.`

[Insertion](/PracticeQuestionsSharp/Exercises/Bits/Insertion.cs)

`Given two 32-bit numbers, N and M, and two bit positions, i and j, insert M into N starting at bit j and ending at bit i. You may assume there is enough bits for M to fit.`

[Pairwise Swap](/PracticeQuestionsSharp/Exercises/Bits/PairwiseSwap.cs)

`Swap the even and odd bits in an integer using as few instructions as possible.`

[Convert Int To Int](/PracticeQuestionsSharp/Exercises/Bits/ConvertIntToInt.cs)

`Write a function to determine the number of bits you would need to flip to convert int A to int B.`


## [DataStructures](/PracticeQuestionsSharp/DataStructures/)
[Stack](/PracticeQuestionsSharp/DataStructures/Stack.cs)

`Stack implementation using my linked list.`

[Simple Graph](/PracticeQuestionsSharp/DataStructures/SimpleGraph.cs)

`Simple graph implementation for use in some exercises. Has links to nodes and thats about it.`

[Queue](/PracticeQuestionsSharp/DataStructures/Queue.cs)

`Generic implementation of a queue using my linked list implementation. Code is largely the same as stack implementation.`

[Priority Queue](/PracticeQuestionsSharp/DataStructures/PriorityQueue.cs)

`Generic implementation of a priority queue using my own queue implementation.`

[Min Heap](/PracticeQuestionsSharp/DataStructures/MinHeap.cs)

`Array based min-heap.`

[Linked List](/PracticeQuestionsSharp/DataStructures/LinkedList.cs)

`Generic implementation of a linked list. Allows access to elements directly as well as passing nodes in to methods manually, meaning it's unsafe but allows for neat optimizations in certain situations.`

[Binary Search Tree](/PracticeQuestionsSharp/DataStructures/BinarySearchTree.cs)

`Generic implementation of a Binary Search Tree.`

[AVL Tree](/PracticeQuestionsSharp/DataStructures/AVLTree.cs)

`Generic implementation of an AVL Tree.`


## [Dynamic Programming](/PracticeQuestionsSharp/Exercises/Dynamic%20Programming/)
[Staircase Steps](/PracticeQuestionsSharp/Exercises/Dynamic%20Programming/StaircaseSteps.cs)

`A child is running up a staircase with n steps and can hop either 1, 2 or 3 steps at a time. Count how many possible ways the child could run up the steps.`

[Power Set](/PracticeQuestionsSharp/Exercises/Dynamic%20Programming/PowerSet.cs)

`The power set of any set S is the set of all subsets of S, including the empty set and S itself.`

[Path Through Grid](/PracticeQuestionsSharp/Exercises/Dynamic%20Programming/PathThroughGrid.cs)

`Given a grid, find a path from the top left to the bottom right using only right and down movements. Some squares are off limits and the path cannot contain them.`

[Parentheses Permutations](/PracticeQuestionsSharp/Exercises/Dynamic%20Programming/ParenthesesPermutations.cs)

`Return all valid permutations of n pairs of parentheses.`

[Coins](/PracticeQuestionsSharp/Exercises/Dynamic%20Programming/Coins.cs)

`Given an infinite number of coins in denominations: 25c, 10c, 5c and 1c, find all permutations of coins to represent n cents.`

[Diving Board](/PracticeQuestionsSharp/Exercises/Dynamic%20Programming/DivingBoard.cs)

`You are building a diving board by placing a bunch of planks of wood end-to-end. Using exactly k planks of sizes shorter or longer generate all possible diving board lengths.`

[Colour Fill](/PracticeQuestionsSharp/Exercises/Dynamic%20Programming/ColourFill.cs)

`Implement a colour fill method, like you would see in a paint application.`

[String Permutations](/PracticeQuestionsSharp/Exercises/Dynamic%20Programming/StringPermutations.cs)

`Compute all permutations of a string of unique characters.`

[Magic Index](/PracticeQuestionsSharp/Exercises/Dynamic%20Programming/MagicIndex.cs)

`A magic index in a given array A[0...n-1] is defined to be an index such that A[i] == i. Given a sorted array of distinct integers, write a method to find a magic index, if one exists, in array A.`

[Tower Of Hanoi](/PracticeQuestionsSharp/Exercises/Dynamic%20Programming/TowerOfHanoi.cs)

`The Tower of Hanoi is a puzzle where you must move a tower from one pole to another. The tower is a stack of pieces. You may only move one piece at a time, place smaller pieces onto larger pieces and you must take the top piece of a stack to move. Implement a function to solve this puzzle.`


## [Helper](/PracticeQuestionsSharp/Helper/)
[Profiler](/PracticeQuestionsSharp/Helper/Profiler.cs)

`Accepts a function and logs the execution time. Usage: Profiler.ProfileAndExecute(() => yourMethod(args), repeat?, name?);`

[Create Read Me](/PracticeQuestionsSharp/Helper/CreateReadMe.cs)

`Generates a README.md file for this GitHub project. Finds every ".cs" file, fetches a description from the comments and generates a relative link to that file.`

[Extension Methods](/PracticeQuestionsSharp/Helper/ExtensionMethods.cs)

`A couple of extension methods I've used throughout the project.`


## [Linked List](/PracticeQuestionsSharp/Exercises/Linked%20List/)
[MergeK Sorted Lists](/PracticeQuestionsSharp/Exercises/Linked%20List/MergeKSortedLists.cs)

`Merge k sorted linked lists and return it as one sorted list. Analyze and describe its complexity.`

[Partition](/PracticeQuestionsSharp/Exercises/Linked%20List/Partition.cs)

`Partition a linked list around an element such that all elements less than the partition value come before it and all elements greater come after it. The order of the elements doesn't matter.`

[Remove Dupes](/PracticeQuestionsSharp/Exercises/Linked%20List/RemoveDupes.cs)

`Remove duplicates from a linked list.`

[Sum From Lists](/PracticeQuestionsSharp/Exercises/Linked%20List/SumFromLists.cs)

`Two numbers represented by linked lists where each node contains a single digit.  The digits are stored in reverse order. eg. 7 1 6 + 5 9 2 = 617 + 295 -> 2 1 9 (912).`

[Loop Detection](/PracticeQuestionsSharp/Exercises/Linked%20List/LoopDetection.cs)

`Given a circular linked list return the point that the loop begins.`


## [Numbers](/PracticeQuestionsSharp/Exercises/Numbers/)
[Merge Intervals](/PracticeQuestionsSharp/Exercises/Numbers/MergeIntervals.cs)

`Given a collection of intervals, merge all overlapping intervals eg. [[1,4],[4,5]] -> [[1,5]].`

[Most Living People](/PracticeQuestionsSharp/Exercises/Numbers/MostLivingPeople.cs)

`Given a list of people with their birth and death years, compute the year with most people alive. Where int[n][0] = birth year & int[n][1] = death year`

[Multiply With Bit Shifting](/PracticeQuestionsSharp/Exercises/Numbers/MultiplyWithBitShifting.cs)

`Perform multiplication using only bit shift operations, addition and subtraction.`

[Prime](/PracticeQuestionsSharp/Exercises/Numbers/Prime.cs)

`Print all primes to n.`

[Rotated Array Min](/PracticeQuestionsSharp/Exercises/Numbers/RotatedArrayMin.cs)

`Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand. Find the minimum value.`

[Smallest Difference](/PracticeQuestionsSharp/Exercises/Numbers/SmallestDifference.cs)

`Given two arrays of integers, find the smallest difference between any two elements, one from each array.`

[Sum Swap](/PracticeQuestionsSharp/Exercises/Numbers/SumSwap.cs)

`Given two arrays of integers, find a pair of values (one value from each array) that you can swap to `

[Swap Numbers In Place](/PracticeQuestionsSharp/Exercises/Numbers/SwapNumbersInPlace.cs)

`Write a function to swap a number in place.`

[Add Operations](/PracticeQuestionsSharp/Exercises/Numbers/AddOperations.cs)

`Write methods for multiply, subtract and divide (*,-,/) using only the add (+) operator.`

[Contiguous Sequence Largest Sum](/PracticeQuestionsSharp/Exercises/Numbers/ContiguousSequenceLargestSum.cs)

`Given an array of integers, find the contiguous sequence with the largest sum.`

[Fibonacci](/PracticeQuestionsSharp/Exercises/Numbers/Fibonacci.cs)

`Return the n-th Fibonacci number.`

[K Difference](/PracticeQuestionsSharp/Exercises/Numbers/KDifference.cs)

`Given an array of n distinct numbers, find all pairs that have a difference of k.`


## [PracticeQuestionsSharp](/PracticeQuestionsSharp/)
[Program](/PracticeQuestionsSharp/Program.cs)

`This file is just for testing solutions.`


## [Queue](/PracticeQuestionsSharp/Exercises/Queue/)
[Queue Animal Shelter](/PracticeQuestionsSharp/Exercises/Queue/QueueAnimalShelter.cs)

`An animal shelter that operates on a first-in first-out basis housing only cats and dogs. Customers can request either a cat, a dog or any animal. They receive the oldest of that type. Implement a queue with the following operations: enqueue, dequeueAny, dequeueDog and dequeueCat.`


## [Searching and Sorting](/PracticeQuestionsSharp/Exercises/Searching%20and%20Sorting/)
[Tic Tac Toe Winner](/PracticeQuestionsSharp/Exercises/Searching%20and%20Sorting/TicTacToeWinner.cs)

`Write a function that determines the winner of a game of Tic Tac Toe.`

[Sorted Merge](/PracticeQuestionsSharp/Exercises/Searching%20and%20Sorting/SortedMerge.cs)

`Given two sorted arrays (A and B) where A has enough space at the end to fit B, merge array B into array A.`


## [Stack](/PracticeQuestionsSharp/Exercises/Stack/)
[Sort Stack](/PracticeQuestionsSharp/Exercises/Stack/SortStack.cs)

`Implement a stack sorting method using only an additional stack (no other data structures). Methods allowed: Push(), Pop(), Peek(), IsEmpty().`

[Min Stack](/PracticeQuestionsSharp/Exercises/Stack/MinStack.cs)

`Stack that can also return the minimum value in constant time.`


## [Strings](/PracticeQuestionsSharp/Exercises/Strings/)
[Pattern Matching](/PracticeQuestionsSharp/Exercises/Strings/PatternMatching.cs)

`Knuth-Morris-Pratt pattern matching algorithm.`

[String To Int](/PracticeQuestionsSharp/Exercises/Strings/StringToInt.cs)

`Implement atoi which converts a string to an integer.`

[Unique Chars](/PracticeQuestionsSharp/Exercises/Strings/UniqueChars.cs)

`Check if a string is made of distinct characters.`

[Int To Words](/PracticeQuestionsSharp/Exercises/Strings/IntToWords.cs)

`Given an integer, return the english words to say that number.`

[Palindrome Permutation](/PracticeQuestionsSharp/Exercises/Strings/PalindromePermutation.cs)

`Determine whether a string is a permutation of a palindrome.`


## [UnitTests](/UnitTests/)
[AVL Tree Tests](/UnitTests/AVLTreeTests.cs)

`Unit tests for AVL Tree.`

[Heap Tests](/UnitTests/HeapTests.cs)

`Unit tests for heap.`

[Linked List Tests](/UnitTests/LinkedListTests.cs)

`Unit tests for linked list.`

[Queue Tests](/UnitTests/QueueTests.cs)

`Unit tests for queue.`

[Stack Tests](/UnitTests/StackTests.cs)

`Unit tests for stack.`

[Test Helper Classes](/UnitTests/TestHelperClasses.cs)

`Dummy classes used during unit testing.`

*This file was created automatically. You can see the code for that [here](/PracticeQuestionsSharp/Helper/CreateReadMe.cs).*
