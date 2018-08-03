using System.Collections.Generic;
using PracticeQuestionsSharp.DataStructures;

namespace PracticeQuestionsSharp.Exercises.Linked_List
{
    //Remove duplicates from a linked list
    public static class RemoveDupes
    {
        public static int RemoveDuplicates<T>(this DataStructures.LinkedList<T> list)
        {
            Node<T> n = list.Head;
            Dictionary<T, T> dict = new Dictionary<T, T>();
            int removedCount = 0;

            while (n != null)
            {
                if (!dict.TryAdd(n.Data, n.Data))
                {
                    n = n.Prev;
                    list.RemoveNode(n.Next);
                    removedCount++;
                }

                n = n.Next;
            }

            return removedCount;
        }
    }
}
