using PracticeQuestionsSharp.DataStructures;
using System;

namespace PracticeQuestionsSharp.Exercises.Stack
{
    //Stack that can also return the minimum value in constant time.
    public class MinStack<T> : Stack<T> where T : IComparable<T>
    {
        public new MinStack<T> Push(T data)
        {
            base.Push(data);
            UpdateMin(data, true);
            return this;
        }

        public new T Pop()
        {
            return UpdateMin(base.Pop(), false);
        }

        public new void Clear()
        {
            base.Clear();
            minValues.Clear();
        }

        public T Min()
        {
            if (IsEmpty) throw new InvalidOperationException("Stack empty.");
            return minValues.Peek();
        }

        private T UpdateMin(T data, bool push)
        {
            if (minValues.IsEmpty || data.CompareTo(minValues.Peek()) <= 0 && push)
            {
                minValues.Push(data);
            }
            else if (data.CompareTo(minValues.Peek()) == 0 && !push)
            {
                minValues.Pop();
            }

            return data;
        }

        private readonly Stack<T> minValues = new Stack<T>();
    }
}
