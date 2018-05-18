using System;

namespace PracticeQuestionsSharp.DataStructures
{
    public class BinarySearchTree<T> where T : IComparable
    {
        public BinarySearchTree<T> Insert(T data)
        {
            if (root == null) { root = new BinaryTreeNode<T>(data); }
            else Insert(data, root);
            return this;
        }

        private void Insert(T data, BinaryTreeNode<T> origin)
        {
            if (data.CompareTo(origin.Data) < 0)
            {
                if (origin.Left == null) origin.Left = new BinaryTreeNode<T>(data);
                else Insert(data, origin.Left);
            }
            else
            {
                if (origin.Right == null) origin.Right = new BinaryTreeNode<T>(data);
                else Insert(data, origin.Right);
            }
        }

        public bool IsEmpty => root == null;
        private BinaryTreeNode<T> root;
    }

    class BinaryTreeNode<T>
    {
        public BinaryTreeNode(T data) { Data = data; }
        public T Data { get; set; }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }
    }
}
