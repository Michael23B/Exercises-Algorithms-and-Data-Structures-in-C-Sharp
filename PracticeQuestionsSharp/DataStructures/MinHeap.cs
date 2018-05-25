using System;
using System.Collections;
using System.Collections.Generic;

namespace PracticeQuestionsSharp.DataStructures
{
    //Array based min-heap
    public class MinHeap<T> : IEnumerable<T> where T : IComparable<T>
    {
        public int Count => nodes.Count;
        public bool IsEmpty => nodes.Count == 0;

        private IList<T> nodes = new List<T>();

        public MinHeap() { }

        //Create a minimum binary tree from a sorted (increasing) array
        public MinHeap(IList<T> sortedArray)
        {
            nodes = new List<T>(sortedArray.Count);
            foreach (var element in sortedArray)
            {
                nodes.Add(element);
            }
        }

        public MinHeap<T> Insert(T data)
        {
            nodes.Add(data);
            int i = nodes.Count - 1;

            while (i > 0)
            {
                int j = (i + 1) / 2 - 1;

                if (nodes[i].CompareTo(nodes[j]) >= 0) break;

                SwapNodes(i, j);
                i = j;
            }

            return this;
        }

        public T ExtractMin()
        {
            if (IsEmpty) throw new InvalidOperationException("Cannot remove from empty heap.");

            T result = nodes[0];
            nodes[0] = nodes[nodes.Count - 1];
            nodes.RemoveAt(nodes.Count - 1);

            MinHeapify(0);

            return result;
        }

        public T Peek()
        {
            if (IsEmpty) throw new InvalidOperationException("Cannot call Peek() on empty heap.");
            return nodes[0];
        }

        private void MinHeapify(int origin)
        {
            while (true)
            {
                int left = (origin + 1) * 2 - 1;
                int right = (origin + 1) * 2;

                int min = left < nodes.Count && nodes[left].CompareTo(nodes[origin]) < 0 ? left : origin;

                min = right < nodes.Count && nodes[right].CompareTo(nodes[min]) < 0 ? right : min;

                if (min != origin)
                {
                    SwapNodes(origin, min);
                    origin = min;
                    continue;
                }
                break;
            }
        }

        private void SwapNodes(int first, int second)
        {
            T temp = nodes[first];
            nodes[first] = nodes[second];
            nodes[second] = temp;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return nodes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return nodes.GetEnumerator();
        }
    }
}