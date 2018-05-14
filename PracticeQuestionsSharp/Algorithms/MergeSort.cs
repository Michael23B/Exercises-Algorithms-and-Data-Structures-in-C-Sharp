using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using PracticeQuestionsSharp.DataStructures;

namespace PracticeQuestionsSharp.Algorithms
{
    public static class MergeSorting
    {
        public static IList<int> MergeSortInt(this IList<int> collection)
        {
            return MergeSortInner(collection);
        }

        public static IList<int> MergeSortInner(IList<int> unsorted)
        {
            if (unsorted.Count <= 1) return unsorted;

            IList<int> result = new List<int>(unsorted.Count);

            if (unsorted.Count == 2)
            {
                result.Add(unsorted[0] < unsorted[1] ? unsorted[0] : unsorted[1]);
                result.Add(unsorted[0] < unsorted[1] ? unsorted[1] : unsorted[0]);
            }
            else
            {
                result = Merge(MergeSortInner(unsorted.Take(unsorted.Count / 2).ToList()), MergeSortInner(unsorted.Skip(unsorted.Count / 2).ToList()));
            }

            return result;
        }

        public static IList<int> Merge(IList<int> left, IList<int> right)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            IList<int> result = new List<int>(left.Count + right.Count);

            while (leftIndex < left.Count && rightIndex < right.Count)
            {
                if (left[leftIndex] < right[rightIndex])
                {
                    result.Add(left[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    result.Add(right[rightIndex]);
                    rightIndex++;
                }
            }

            while (leftIndex < left.Count)
            {
                result.Add(left[leftIndex]);
                leftIndex++;
            }
            while (rightIndex < right.Count)
            {
                result.Add(right[rightIndex]);
                rightIndex++;
            }

            return result;
        }
    }
}