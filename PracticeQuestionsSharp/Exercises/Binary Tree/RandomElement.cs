using System;
using PracticeQuestionsSharp.DataStructures;

namespace PracticeQuestionsSharp.Exercises.Binary_Tree
{
    //Create a Binary Tree class from scratch with Insert, Remove and Find methods.
    //In addition, add a GetRandom() method that returns a random node. All nodes should be equally likely to be chosen.

    public class RandomElement<T> where T : IComparable
    {
        public RandomElement<T> Insert(T data)
        {
            if (data == null) return null;
            if (root == null) { root = new BinaryTreeNodeWithSize<T>(data); }
            else Insert(data, root);
            Count++;
            return this;
        }

        private void Insert(T data, BinaryTreeNodeWithSize<T> origin)
        {
            int comparisonResult = data.CompareTo(origin.Data);
            if (comparisonResult == 0)
                throw new InvalidOperationException("No duplicate data allowed in BST.");

            if (comparisonResult < 0)
            {
                if (origin.Left == null) origin.Left = new BinaryTreeNodeWithSize<T>(data);
                else Insert(data, origin.Left);
            }
            else
            {
                if (origin.Right == null) origin.Right = new BinaryTreeNodeWithSize<T>(data);
                else Insert(data, origin.Right);
            }

            origin.UpdateSize();
        }

        public void Remove(T data)
        { 
            if ((root = Remove(data, root)) != null) Count--;
            if (root == null) Count = 0;
        }

        private BinaryTreeNodeWithSize<T> Remove(T data, BinaryTreeNodeWithSize<T> origin)
        {
            if (origin == null || data == null) return null;
            int comparisonResult = data.CompareTo(origin.Data);

            if (comparisonResult < 0)
            {
                if (origin.Left == null) throw new InvalidOperationException($"Couldn't find {data} to remove!");
                origin.Left = Remove(data, origin.Left);
                origin.UpdateSize();
                return origin;
            }

            if (comparisonResult > 0)
            {
                if (origin.Right == null) throw new InvalidOperationException($"Couldn't find {data} to remove!");
                origin.Right = Remove(data, origin.Right);
                origin.UpdateSize();
                return origin;
            }
            //Match found
            //If we have two children, replace my data with rights min, then remove starting from right
            if (origin.Left != null && origin.Right != null)
            {
                var minimum = Minimum(origin.Right);

                origin.Data = minimum;
                origin.Right = Remove(minimum, origin.Right);
                origin.UpdateSize();
                return origin;
            }
            
            if (origin.Left == null) return origin.Right;
            else return origin.Left;
        }

        public bool Find(T data)
        {
            BinaryTreeNodeWithSize<T> curr = root;

            while (curr != null)
            {
                int comparisonResult = data.CompareTo(curr.Data);

                if (comparisonResult < 0) curr = curr.Left;
                else if (comparisonResult > 0) curr = curr.Right;
                else if (comparisonResult == 0) return true;
            }

            return false;
        }

        T Minimum(BinaryTreeNodeWithSize<T> origin)
        {
            while (origin.Left != null) origin = origin.Left;
            return origin.Data;
        }

        //Gets a random number from 0 through Count - 1 and travels to that node (in-order)
        //Takes n time in the worst case where n = Count
        public T GetRandom()
        {
            return TraverseToIndex(r.Next(0, Count));
        }

        //Gets a random number by comparing sub-tree sizes to determine the probability
        //of choosing that node. Worst case takes time equal to the depth of the longest path.
        public T GetRandom2()
        {
            int rIndex = r.Next(1, Count + 1);
            BinaryTreeNodeWithSize<T> n = root;

            while (n != null)
            {
                if (n.Size == rIndex) return n.Data;

                if (n.Left != null && rIndex <= n.Left.Size) n = n.Left;
                else
                {
                    //Left side was not chosen, update our rIndex because we are no longer considering it
                    rIndex -= n.Left?.Size ?? 0;
                    n = n.Right;
                }
            }

            throw new InvalidOperationException("Tree empty!");
        }

        public T TraverseToIndex(int index)
        {
            BinaryTreeNodeWithSize<T> n = root;
            var stack = new Stack<T>();
            RandTarget = index;
            RandIndex = -1;

            Traversal(root, stack);

            return stack.Pop();
        }

        private void Traversal(BinaryTreeNodeWithSize<T> origin, Stack<T> stack)
        {
            if (RandIndex == RandTarget) return; //reached the random target, stop searching
            if (origin.Left != null) Traversal(origin.Left, stack);

            if (RandIndex == RandTarget) return;
            stack.Push(origin.Data);
            RandIndex++;

            if (RandIndex == RandTarget) return;
            if (origin.Right != null) Traversal(origin.Right, stack);
        }

        public int RandIndex { get; set; }
        public int RandTarget { get; set; }
        private readonly Random r = new Random();

        public int Count { get; set; }
        public bool IsEmpty => root == null;
        private BinaryTreeNodeWithSize<T> root;
    }

    class BinaryTreeNodeWithSize<T>
    {
        public BinaryTreeNodeWithSize(T data) { Data = data; Size = 1; }
        public T Data { get; set; }
        public BinaryTreeNodeWithSize<T> Left { get; set; }
        public BinaryTreeNodeWithSize<T> Right { get; set; }
        public int Size { get; set; }
        public void UpdateSize() => Size = (Right?.Size ?? 0) + (Left?.Size ?? 0) + 1;
    }
}