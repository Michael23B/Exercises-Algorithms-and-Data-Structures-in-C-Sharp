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
            //TODO: improvement - check all the previous numbers and see if the add to higher than 0,
            //TODO: if so the sequence containing them will always be higher than this current sequence so we don't need to check again

            int endIndex = startIndex + count;
            if (endIndex >= collection.Count) return;

            int sum = 0;
            var sequence = new List<int>(count + 1);

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

            FindLargestSequence(startIndex, count + 1, collection, max);
        }

        //Maintain access to max throughout recursed method
        private class MaxContiguousSum
        {
            public int MaxSum { get; set; } = Int32.MinValue;
            public List<int> MaxSequence { get; set; }
        }
    }
}
