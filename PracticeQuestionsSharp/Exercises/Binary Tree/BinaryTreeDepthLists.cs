using System;
using System.Collections.Generic;
using PracticeQuestionsSharp.DataStructures;

namespace PracticeQuestionsSharp.Exercises.Binary_Tree
{
    public static class BinaryTreeDepthLists
    {
        //Return a list for each depth of a binary tree.
        //Array-based tree with IEnumerable implemented to move through the array in order
        public static List<List<T>> GetDepthLists<T>(this MinHeap<T> tree) where T : IComparable<T>
        {
            if (tree == null || tree.IsEmpty) return null;

            var depthLists = new List<List<T>>();
            depthLists.Add(new List<T>());

            int nodesAtDepth = 1;
            int currentNodes = 0;

            foreach (T node in tree)
            {
                if (currentNodes == nodesAtDepth)
                {
                    nodesAtDepth *= 2;
                    currentNodes = 0;
                    depthLists.Add(new List<T>());
                }

                depthLists[depthLists.Count - 1].Add(node);
                currentNodes++;
            }

            return depthLists;
        }
    }
}
