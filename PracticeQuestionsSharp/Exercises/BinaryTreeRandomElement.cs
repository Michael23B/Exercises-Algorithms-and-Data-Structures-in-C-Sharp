using System;
using PracticeQuestionsSharp.DataStructures;

namespace PracticeQuestionsSharp.Exercises
{
    //Create a Binary Tree class from scratch with Insert, Remove and Find methods.
    //In addition, add a GetRandom() method that returns a random node. All nodes should be equally likely to be chosen.

    public class BinaryTreeRandomElement<T> where T : IComparable
    {
        public BinaryTreeRandomElement<T> Insert(T data)
        {
            if (data == null) return null;
            if (root == null) { root = new BinaryTreeNode<T>(data); }
            else Insert(data, root);
            Count++;
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
            if (Remove(data, root) != null) Count--;
            if (root == null) Count = 0;
        }

        private BinaryTreeNode<T> Remove(T data, BinaryTreeNode<T> origin)
        {
            if (origin == null || data == null) return null;
            int comparisonResult = data.CompareTo(origin.Data);

            if (comparisonResult < 0)
            {
                if (origin.Left == null) throw new InvalidOperationException($"Couldn't find {data} to remove!");
                origin.Left = Remove(data, origin.Left);
                return origin;
            }

            if (comparisonResult > 0)
            {
                if (origin.Right == null) throw new InvalidOperationException($"Couldn't find {data} to remove!");
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

        public bool Find(T data)
        {
            BinaryTreeNode<T> curr = root;

            while (curr != null)
            {
                int comparisonResult = data.CompareTo(curr.Data);

                if (comparisonResult < 0) curr = curr.Left;
                else if (comparisonResult > 0) curr = curr.Right;
                else if (comparisonResult == 0) return true;
            }

            return false;
        }

        T Minimum(BinaryTreeNode<T> origin)
        {
            while (origin.Left != null) origin = origin.Left;
            return origin.Data;
        }

        public T GetRandom()
        {
            return TraverseToIndex(r.Next(0, Count));
        }

        public T TraverseToIndex(int index)
        {
            BinaryTreeNode<T> n = root;
            var stack = new Stack<T>();
            RandTarget = index;
            RandIndex = -1;

            Traversal(root, stack);

            return stack.Pop();
        }

        private void Traversal(BinaryTreeNode<T> origin, Stack<T> stack)
        {
            if (RandIndex == RandTarget) return; //reached the random target, stop searching
            if (origin.Left != null) Traversal(origin.Left, stack);

            if (RandIndex == RandTarget) return;
            stack.Push(origin.Data);
            RandIndex++;

            if (RandIndex == RandTarget) return;
            if (origin.Right != null) Traversal(origin.Right, stack);
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

        public int RandIndex { get; set; }
        public int RandTarget { get; set; }
        private readonly Random r = new Random();

        public int Count { get; set; }
        public bool IsEmpty => root == null;
        private BinaryTreeNode<T> root;
    }
}
