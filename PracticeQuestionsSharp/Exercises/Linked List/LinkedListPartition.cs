using System;
using PracticeQuestionsSharp.DataStructures;

namespace PracticeQuestionsSharp.Exercises.Linked_List
{
    public static class LinkedListPartition
    {
        public static LinkedList<T> PartitionAround<T>(this LinkedList<T> list, T partition) where T : IComparable<T>
        {
            LinkedList<T> pre = new LinkedList<T>();
            LinkedList<T> post = new LinkedList<T>();

            foreach (T element in list)
            {
                if (element.CompareTo(partition) == 0) pre.Add(element);
                else if (element.CompareTo(partition) < 0)
                {
                    if (pre.Head != null) pre.AddBefore(element, pre.Head);
                    else pre.Add(element);
                }
                else if (element.CompareTo(partition) > 0) post.Add(element);
            }

            foreach (T element in post) pre.Add(element);

            return pre;
        }
    }
}
