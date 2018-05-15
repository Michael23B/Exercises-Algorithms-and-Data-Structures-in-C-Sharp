using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticeQuestionsSharp.Algorithms
{
    public static class MergeSorting
    {
        //We return a list since we want to accept arrays but returning an IList (as a list) will crash when assigning to an array
        public static List<T> MergeSort<T>(this IList<T> collection) where T :  IComparable<T>
        {
            return (List<T>)Sort(collection);
        }

        private static IList<T> Sort<T>(IList<T> unsorted) where T : IComparable<T>
        {
            if (unsorted.Count <= 1) return unsorted;

            IList<T> result = new List<T>(unsorted.Count);

            if (unsorted.Count == 2)
            {
                result.Add(unsorted[0].CompareTo(unsorted[1]) < 1 ? unsorted[0] : unsorted[1]);
                result.Add(unsorted[0].CompareTo(unsorted[1]) < 1 ? unsorted[1] : unsorted[0]);
            }
            else
            {
                result = Merge(Sort(unsorted.Take(unsorted.Count / 2).ToList()), Sort(unsorted.Skip(unsorted.Count / 2).ToList()));
            }

            return result;
        }

        private static IList<T> Merge<T>(IList<T> left, IList<T> right) where T : IComparable<T>
        {
            int leftIndex = 0;
            int rightIndex = 0;
            IList<T> result = new List<T>(left.Count + right.Count);

            while (leftIndex < left.Count && rightIndex < right.Count)
            {
                if (left[leftIndex].CompareTo(right[rightIndex]) < 1)
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