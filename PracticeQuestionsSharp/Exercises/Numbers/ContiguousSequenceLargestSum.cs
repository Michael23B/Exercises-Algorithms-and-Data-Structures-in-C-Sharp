using System;
using System.Collections.Generic;

namespace PracticeQuestionsSharp.Exercises.Numbers
{
    //Given an array of integers, find the contiguous sequence with the largest sum.
    public static class ContiguousSequenceLargestSum
    {
        public static int LargestContiguousSum(this IList<int> collection)
        {
            MaxContiguousSum max = new MaxContiguousSum();

            //Iterate through each entry in collection as a starting point
            for (int i = 0; i < collection.Count; ++i)
            {
                FindLargestSequence(i, 0, collection, max);
            }

            //Print the sequence and then return the largest sum
            max.MaxSequence.ForEach(i => Console.Write($"{i},"));
            Console.Write('\n');

            return max.MaxSum;
        }

        private static void FindLargestSequence(int startIndex, int count, IList<int> collection, MaxContiguousSum max)
        {
            //If the previous numbers sum to greater than zero, the path using those numbers must be greater than this path
            if (PrevSumGreaterThanZero(startIndex, collection)) return;

            int endIndex = startIndex + count;
            if (endIndex >= collection.Count) return;

            int sum = 0;
            var sequence = new List<int>(count + 1);

            //Get the sum of this sequence and compare it to the current max
            for (int i = startIndex; i <= endIndex; ++i)
            {
                sum += collection[i];
                sequence.Add(collection[i]);
            }

            if (sum > max.MaxSum)
            {
                max.MaxSum = sum;
                max.MaxSequence = sequence;
            }

            //Recurse with the current starting point and sequence length + 1
            FindLargestSequence(startIndex, count + 1, collection, max);
        }

        private static bool PrevSumGreaterThanZero(int startIndex, IList<int> collection)
        {
            int sum = 0;
            for (int i = 0; i < startIndex; ++i)
                sum += collection[i];

            return sum > 0;
        }

        //Maintain access to max throughout recursed method
        private class MaxContiguousSum
        {
            public int MaxSum { get; set; } = Int32.MinValue;
            public List<int> MaxSequence { get; set; }
        }
    }
}
