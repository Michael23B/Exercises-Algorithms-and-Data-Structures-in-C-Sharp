using System;
using PracticeQuestionsSharp.DataStructures;

namespace PracticeQuestionsSharp.Exercises.Linked_List
{
    //Partition a linked list around an element such that all elements less than the partition value
    // come before it and all elements greater come after it. The order of the elements doesn't matter.
    public static class Partition
    {
        //Partition around an element using enumeration
        //O(n) time. At worst we iterate through list once and then post once which may be as large as list.
        public static LinkedList<T> PartitionAround1<T>(this LinkedList<T> list, T partition) where T : IComparable<T>
        {
            LinkedList<T> pre = new LinkedList<T>();
            LinkedList<T> post = new LinkedList<T>();

            foreach (T element in list)
            {
                if (element.CompareTo(partition) < 0) pre.Add(element);
                else if (element.CompareTo(partition) > 0) post.Add(element);
                else if (element.CompareTo(partition) == 0)
                {
                    //Elements matching partition are added at the start of post.
                    if (post.Head != null) post.AddBefore(element, post.Head);
                    else post.Add(element);
                }
            }

            foreach (T element in post) pre.Add(element);

            return pre;
        }

        //Partition around an element predicate find operation
        //O(n) time. We always iterate through the list 3 times.
        public static LinkedList<T> PartitionAround2<T>(this LinkedList<T> list, T partition) where T : IComparable<T>
        {
            LinkedList<T> result = new LinkedList<T>();

            var temp = list.FindAll(x => x.CompareTo(partition) < 0);
            foreach (Node<T> element in temp) result.Add(element.Data);

            temp = list.FindAll(x => x.CompareTo(partition) == 0);
            foreach (Node<T> element in temp) result.Add(element.Data);

            temp = list.FindAll(x => x.CompareTo(partition) > 0);
            foreach (Node<T> element in temp) result.Add(element.Data);

            return result;
        }
    }
}
