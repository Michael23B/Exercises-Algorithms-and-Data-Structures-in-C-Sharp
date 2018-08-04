using System;
using PracticeQuestionsSharp.DataStructures;

//Implement a stack sorting method using only an additional stack (no other data structures).
// Methods allowed: Push(), Pop(), Peek(), IsEmpty().

namespace PracticeQuestionsSharp.Exercises.Stack
{
    public static class SortStack
    {
        //This is mega inefficient my god it's bad surely theres a better way.
        //Gets the stack size, then finds the biggest value and places it at the bottom.
        //It repeats this for each item in the stack.
        //Doesn't take into account if the order is already sorted at any point so it's always worst case runtime
        public static Stack<T> Sort<T>(this Stack<T> stack) where T : IComparable<T>
        {
            if (stack == null || stack.IsEmpty) return null;

            Stack<T> buffer = new Stack<T>();
            int sortedCount = 0;
            int count = FindStackCount(stack, buffer);

            ResetStack(stack, buffer);

            if (count == 1) return stack;

            while (sortedCount != count)
            {
                SendMaxToBottomOfStack(stack, buffer);
                sortedCount++;
            }

            return stack;
        }

        //TODO: pass the sorted count to speed this up slightly
        static int FindStackCount<T>(Stack<T> stack, Stack<T> buffer)
        {
            int count = 0;

            while (!stack.IsEmpty)
            {
                buffer.Push(stack.Pop());
                count++;
            }

            return count;
        }

        //Finds the max item by iterating through the whole stack, then places it at the bottom
        static void SendMaxToBottomOfStack<T>(Stack<T> stack, Stack<T> buffer) where T : IComparable<T>
        {
            T max = stack.Pop();

            while (!stack.IsEmpty)
            {
                if (max.CompareTo(stack.Peek()) > 0) buffer.Push(stack.Pop());
                else
                {
                    buffer.Push(max);
                    max = stack.Pop();
                }
            }

            stack.Push(max);
            ResetStack(stack, buffer);
        }

        //Puts the buffer back into the stack
        static void ResetStack<T>(Stack<T> stack, Stack<T> buffer)
        {
            while (!buffer.IsEmpty) stack.Push(buffer.Pop());
        }
    }
}
