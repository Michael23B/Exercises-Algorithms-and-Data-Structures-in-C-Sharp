using System;
/*
We can implement our own (faster) count rather than LinkedList.Count() 
because we don't allow access to the list directly.
*/
namespace PracticeQuestionsSharp.DataStructures
{
    //Stack implementation using my linked list.
    public class Stack<T>
    {
        public Stack()
        {
            list = new LinkedList<T>();
            Count = 0;
        }

        public Stack<T> Push(T data)
        {
            list.Add(data);
            Count++;
            return this;
        }

        public T Pop()
        {
            if (IsEmpty) throw new InvalidOperationException("Stack empty.");
            T result = list.Tail.Data;
            list.RemoveNode(list.Tail);
            Count--;
            return result;
        }

        public T Peek()
        {
            return list.Tail.Data;
        }

        //Poor implementation of this since default(T) could be a useful value for some types (int, char).
        // As long as you aren't using those default values however, it does the job.
        public T TryPeek()
        {
            return IsEmpty ? default(T) : list.Tail.Data;
        }

        public void Clear()
        {
            list.Clear();
            Count = 0;
        }

        public void Print(bool reverse = false)
        {
            list.Print(reverse);
        }

        public bool IsEmpty => Count == 0;
        public int Count { get; private set; }

        private readonly LinkedList<T> list;
    }
}
