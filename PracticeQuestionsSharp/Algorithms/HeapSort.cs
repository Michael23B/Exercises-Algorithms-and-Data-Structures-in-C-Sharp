using System;
using System.Collections.Generic;
using PracticeQuestionsSharp.DataStructures;

namespace PracticeQuestionsSharp.Algorithms
{
    public static class HeapSort
    {
        public static List<T> HeapSortAscending<T>(this IList<T> collection) where T : IComparable
        {
            var minHeap = new MinHeap<T>();
            var sorted = new List<T>(collection.Count);
            foreach (T element in collection)
            {
                minHeap.Insert(element);
            }

            while(!minHeap.IsEmpty) sorted.Add(minHeap.ExtractMin());

            return sorted;
        }
    }
}
