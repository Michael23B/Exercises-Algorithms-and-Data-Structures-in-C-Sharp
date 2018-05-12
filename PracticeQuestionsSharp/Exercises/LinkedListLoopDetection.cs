using System.Collections.Generic;
using PracticeQuestionsSharp.DataStructures;

namespace PracticeQuestionsSharp.Exercises
{
    //Given a circular linked list return the point that the loop begins
    public static class LinkedListLoopDetection
    {
        public static Node<T> DetectLoop<T>(this DataStructures.LinkedList<T> list)
        {
            Node<T> n = list.Head;
            Dictionary<Node<T>, Node<T>> dict = new Dictionary<Node<T>, Node<T>>();

            if (n == null) return null;

            dict.Add(n, n);

            while (n.Next != null && dict.TryAdd(n.Next, n.Next)) n = n.Next;

            return n;
        }
    }
}
