using System;

namespace PracticeQuestionsSharp.DataStructures
{
    public class AVLTree<T> where T : IComparable
    {
        public AVLTree<T> Insert(T data)
        {
            if (data == null) return null;
            if (root == null) { root = new AVLTreeNode<T>(data); }
            else Insert(data, root);
            return this;
        }

        private void Insert(T data, AVLTreeNode<T> origin)
        {
            int comparisonResult = data.CompareTo(origin.Data);
            if (comparisonResult == 0)
                throw new InvalidOperationException("No duplicate data allowed in BST.");

            if (comparisonResult < 0)
            {
                if (origin.Left == null) origin.Left = new AVLTreeNode<T>(data);
                else Insert(data, origin.Left);
            }
            else
            {
                if (origin.Right == null) origin.Right = new AVLTreeNode<T>(data);
                else Insert(data, origin.Right);
            }
        }

        public void Remove(T data)
        {
            Remove(data, root);
        }

        private AVLTreeNode<T> Remove(T data, AVLTreeNode<T> origin)
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

        T Minimum(AVLTreeNode<T> origin)
        {
            while (origin.Left != null) origin = origin.Left;
            return origin.Data;
        }

        private AVLTreeNode<T> RightRotate(AVLTreeNode<T> y)
        {
            AVLTreeNode<T> x = y.Left;
            AVLTreeNode<T> z = x.Right;

            x.Right = y;
            y.Left = z;

            y.Height = y.Left.Height > y.Right.Height ? y.Left.Height : y.Right.Height;
            x.Height = x.Left.Height > x.Right.Height ? x.Left.Height : x.Right.Height;
            //New height is 1 plus child max
            y.Height++;
            x.Height++;

            return x;
        }

        public void PrintAll()
        {
            Print(root);
        }

        private void Print(AVLTreeNode<T> origin) //In order traversal
        {
            if (origin.Left != null) Print(origin.Left);

            Console.WriteLine(origin.Data);

            if (origin.Right != null) Print(origin.Right);
        }

        public bool IsEmpty => root == null;
        private AVLTreeNode<T> root;
    }

    class AVLTreeNode<T>
    {
        public AVLTreeNode(T data) { Data = data; }
        public T Data { get; set; }
        public int Height { get; set; }
        public AVLTreeNode<T> Left { get; set; }
        public AVLTreeNode<T> Right { get; set; }
    }
}
