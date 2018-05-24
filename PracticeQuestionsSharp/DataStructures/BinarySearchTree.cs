using System;

namespace PracticeQuestionsSharp.DataStructures
{
    public class BinarySearchTree<T> where T : IComparable
    {
        public BinarySearchTree<T> Insert(T data)
        {
            if (data == null) return null;
            if (root == null) { root = new BinaryTreeNode<T>(data); }
            else Insert(data, root);
            return this;
        }

        private void Insert(T data, BinaryTreeNode<T> origin)
        {
            int comparisonResult = data.CompareTo(origin.Data);
            if (comparisonResult == 0)
                throw new InvalidOperationException("No duplicate data allowed in BST.");

            if (comparisonResult < 0)
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

        public void Remove(T data)
        {
            Remove(data, root);
        }

        private BinaryTreeNode<T> Remove(T data, BinaryTreeNode<T> origin)
        {
            if (origin == null || data == null) return null;
            int comparisonResult = data.CompareTo(origin.Data);

            if (comparisonResult < 0)
            {
                origin.Left = Remove(data, origin.Left);
                return origin;
            }

            if (comparisonResult > 0)
            {
                origin.Right = Remove(data, origin.Right);
                return origin;
            }

            if (comparisonResult == 0)
            {
                if (origin.Left != null && origin.Right != null)
                {
                    var minimum = Minimum(origin.Right);

                    origin.Data = minimum;
                    origin.Right = Remove(minimum, origin.Right);
                    return origin;
                }
                if (origin.Left == null) return origin.Right;
                if (origin.Right == null) return origin.Left;

            }

            return null;
        }

        T Minimum(BinaryTreeNode<T> origin)
        {
            while (origin.Left != null) origin = origin.Left;
            return origin.Data;
        }

        public T TraverseToIndex(int index)
        {
            BinaryTreeNode<T> n = root;
            var stack = new Stack<T>();

            Traversal(root, stack);

            return stack.Pop();
        }

        private void Traversal(BinaryTreeNode<T> origin, Stack<T> stack)
        {
            if (RAI <= RAT) return; //reached the random target, stop searching
            if (origin.Left != null) Traversal(origin.Left, stack);
            if (RAI == RAT)
            {
                stack.Push(origin.Data);
                RAI--;
            }
            if (origin.Left != null) Traversal(origin.Left, stack);
        }

        public void PrintAll()
        {
            Print(root);
        }

        private void Print(BinaryTreeNode<T> origin) //In order traversal
        {
            if (origin.Left != null) Print(origin.Left);

            Console.WriteLine(origin.Data);

            if (origin.Right != null) Print(origin.Right);
        }

        //Random access exercise
        public int RAI { get; set; } //Random Access Index (begins as the count of this tree)
        public int RAT { get; set; } //Random Access Target (the random target to stop at during traversal)

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
