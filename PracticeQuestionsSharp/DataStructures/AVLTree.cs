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

            //Update height recursively
            origin.CalculateHeight();

            //Test for and repair imbalance
            int nodeBalance = origin.Balance();

            if (nodeBalance > 1 && data.CompareTo(origin.Left.Data) < 0) RightRotate(origin);
            if (nodeBalance < -1 && data.CompareTo(origin.Right.Data) > 0) LeftRotate(origin);
            if (nodeBalance > 1 && data.CompareTo(origin.Left.Data) > 0)
            {
                origin.Left = LeftRotate(origin.Left);
                RightRotate(origin);
            }
            if (nodeBalance < -1 && data.CompareTo(origin.Right.Data) < 0)
            {
                origin.Right = RightRotate(origin.Right);
                LeftRotate(origin);
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
            AVLTreeNode<T> temp = x.Right;

            x.Right = y;
            y.Left = temp;

            y.CalculateHeight();
            x.CalculateHeight();

            return x;
        }

        private AVLTreeNode<T> LeftRotate(AVLTreeNode<T> x)
        {
            AVLTreeNode<T> y = x.Right;
            AVLTreeNode<T> temp = y.Left;
 
            y.Left = x;
            x.Right = temp;

            x.CalculateHeight();
            y.CalculateHeight();

            return y;
        }

        public void PrintAll()
        {
            Print(root);
        }

        private void Print(AVLTreeNode<T> origin) //In order traversal
        {
            if (origin.Left != null) Print(origin.Left);

            Console.WriteLine($"{origin.Data}, ({origin.Height})");

            if (origin.Right != null) Print(origin.Right);
        }

        public bool IsEmpty => root == null;
        private AVLTreeNode<T> root;
    }

    class AVLTreeNode<T>
    {
        public AVLTreeNode(T data) {
            Data = data;
            Height = 1;
        }
        public T Data { get; set; }
        public int Height { get; set; }
        public AVLTreeNode<T> Left { get; set; }
        public AVLTreeNode<T> Right { get; set; }

        public int Balance()
        {
            if (Left == null && Right == null) return 0;
            if (Left == null) return Right.Height;
            if (Right == null) return Left.Height;
            return Left.Height - Right.Height;
        }

        public int CalculateHeight()
        {
            if (Left == null && Right == null) return Height = 1;
            if (Left == null) return Height = Right.Height + 1;
            if (Right == null) return Height = Left.Height + 1;
            return Height = Left.Height > Right.Height ? Left.Height + 1 : Right.Height + 1;
        }
    }
}
