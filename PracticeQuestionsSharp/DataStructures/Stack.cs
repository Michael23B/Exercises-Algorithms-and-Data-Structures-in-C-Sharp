//Stack implementation using my linked list implementation

using System;

namespace PracticeQuestionsSharp.DataStructures
{
    public class Stack<T>
    {
        public Stack()
        {
            list = new LinkedList<T>();
        }

        public Stack<T> Push(T data)
        {
            list.Add(data);
            return this;
        }

        public T Pop()
        {
            if (IsEmpty) throw new InvalidOperationException("Stack empty.");
            T result = list.Tail.Data;
            list.RemoveNode(list.Tail);
            return result;
        }

        public T Peek()
        {
            return list.Tail.Data;
        }

        public bool IsEmpty => list.Head == null;

        private readonly LinkedList<T> list;
    }
}
