using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticeQuestionsSharp.DataStructures
{
    //Generic implementation of a priority queue using my own queue implementation.
    public class PriorityQueue<T> : Queue<T>
    {
        public PriorityQueue<T> Enqueue(T data, int priority = 1)
        {
            if (!queues.ContainsKey(priority)) queues.Add(priority, new Queue<T>());

            queues[priority].Enqueue(data);

            return this;
        }

        public new T Dequeue()
        {
            if (IsEmpty) throw new InvalidOperationException("Queue empty.");

            var currQueue = queues.First();

            T result = currQueue.Value.Dequeue();

            if (currQueue.Value.IsEmpty) queues.Remove(currQueue.Key);

            return result;
        }

        public new T Peek()
        {
            return queues.First().Value.Peek();
        }

        public new void Clear()
        {
            foreach (Queue<T> queue in queues.Values) queue.Clear();
        }

        public new int Count => queues.Sum(x => x.Value.Count);
        public new bool IsEmpty => Count == 0;

        private readonly SortedDictionary<int, Queue<T>> queues = new SortedDictionary<int, Queue<T>>();
    }
}
