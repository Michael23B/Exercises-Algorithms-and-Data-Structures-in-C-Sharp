using System;

namespace PracticeQuestionsSharp.Exercises.Binary_Tree
{
    //Write an algorithm to find the "next" node (in-order successor) of a given node in a binary search tree.
    //You may assume that each node has a link to it's parent
    public static class BinaryTreeSuccessor
    {
        public static BinaryTreeNodeWithParent<T> Successor<T>(this BinaryTreeNodeWithParent<T> node) where T : IComparable<T>
        {
            if (node.Right != null) return MinNode(node.Right);

            while (node.Parent != null)
            {
                BinaryTreeNodeWithParent<T> prev = node;
                node = node.Parent;
                if (node?.Left == prev) return node;
            }

            return null;
        }

        private static BinaryTreeNodeWithParent<T> MinNode<T>(BinaryTreeNodeWithParent<T> node) where T : IComparable<T>
        {
            while (node.Left != null) node = node.Left;
            return node;
        }
    }

    public class BinaryTreeNodeWithParent<T> where T : IComparable<T>
    {
        public BinaryTreeNodeWithParent(T data) { Data = data; }
        public T Data { get; set; }
        public BinaryTreeNodeWithParent<T> Left { get; set; }
        public BinaryTreeNodeWithParent<T> Right { get; set; }
        public BinaryTreeNodeWithParent<T> Parent { get; set; }
    }
}
