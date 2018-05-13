using System;
/*
Queue implementation using my linked list implementation.
Also copied from stack implementation mostly.
*/
namespace PracticeQuestionsSharp.DataStructures
{
    public class Queue<T>
    {
        public Queue()
        {
            list = new LinkedList<T>();
            Count = 0;
        }

        public Queue<T> Enqueue(T data)
        {
            list.Add(data);
            Count++;
            return this;
        }

        public T Dequeue()
        {
            if (IsEmpty) throw new InvalidOperationException("Queue empty.");
            T result = list.Head.Data;
            list.RemoveNode(list.Head);
            Count--;
            return result;
        }

        public T Peek()
        {
            return list.Head.Data;
        }

        public void Clear()
        {
            list.Clear();
            Count = 0;
        }

        public bool IsEmpty => Count == 0;
        public int Count { get; private set; }

        private readonly LinkedList<T> list;
    }
}
