using System;
using System.Collections.Generic;

namespace PracticeQuestionsSharp.Algorithms
{
    public static class BinarySearch
    {
        //Generic implementation of a binary search algorithm.
        public static int Search<T>(this IList<T> collection, T data) where T : IComparable
        {
            int max = collection.Count - 1;
            int min = 0;

            while (min <= max)
            {
                int mid = min + (max - min) / 2;
                int comparison = data.CompareTo(collection[mid]);

                switch (comparison)
                {
                    case 1:
                        min = mid + 1;
                        break;
                    case -1:
                        max = mid - 1;
                        break;
                    case 0:
                        return mid;
                }
            }

            return -1;
        }
    }
}
