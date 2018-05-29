using System;
using System.Linq;
using PracticeQuestionsSharp.DataStructures;

namespace PracticeQuestionsSharp.Exercises.Linked_List
{
    //Merge k sorted linked lists and return it as one sorted list. Analyze and describe its complexity.
    public static class MergeKSortedLists
    {
        public static DataStructures.LinkedList<T> MergeSortedLists<T>(Node<T>[] nodes) where T : IComparable<T>
        {
            var result = new DataStructures.LinkedList<T>();

            while (nodes.Any(x => x != null))
            {
                //Find min element and index
                //I believe we can't use Linq for this because we need the reference in the array
                Node<T> min = null;
                int minIndex = 0;
                for (int i = 0; i < nodes.Length; ++i)
                {
                    if (nodes[i] == null) continue;
                    if (min == null)
                    {
                        min = nodes[i];
                        minIndex = i;
                    }
                    else if (nodes[i].Data.CompareTo(min.Data) < 0)
                    {
                        min = nodes[i];
                        minIndex = i;
                    }
                }

                result.Add(min.Data);
                nodes[minIndex] = nodes[minIndex].Next;
            }

            return result;
        }
    }
}
