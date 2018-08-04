using System;
using System.Collections.Generic;

namespace PracticeQuestionsSharp.DataStructures
{
    //Generic implementation of an AVL Tree.
    public class AVLTree<T> where T : IComparable<T>
    {
        public bool Find(T data)
        {
            var node = root;

            while (node != null)
            {
                int compResult = data.CompareTo(node.Data);
                if (compResult == 0) return true;

                if (compResult < 0)
                {
                    if (node.Left == null) return false;
                    node = node.Left;
                }
                else if (compResult > 0)
                {
                    if (node.Right == null) return false;
                    node = node.Right;
                }
            }

            return false;
        }

        public AVLTree<T> Insert(T data)
        {
            if (data == null) return null;
            if (root == null) { root = new AVLTreeNode<T>(data); }
            else Insert(data, root, root);
            return this;
        }

        private void Insert(T data, AVLTreeNode<T> origin, AVLTreeNode<T> parent)
        {
            int comparisonResult = data.CompareTo(origin.Data);
            if (comparisonResult == 0)
                throw new InvalidOperationException("No duplicate data allowed in AVL Tree.");

            if (comparisonResult < 0)
            {
                if (origin.Left == null) origin.Left = new AVLTreeNode<T>(data);
                else Insert(data, origin.Left, origin);
            }
            else
            {
                if (origin.Right == null) origin.Right = new AVLTreeNode<T>(data);
                else Insert(data, origin.Right, origin);
            }

            Rebalance(data, origin, parent);
        }

        //Insert rebalance (find where data would go and rebalance)
        private void Rebalance(T data, AVLTreeNode<T> origin, AVLTreeNode<T> parent)
        {
            //Update height before checking for balance
            origin.CalculateHeight();

            //Balance > 0 == Left-heavy. Balance < 0 == Right-heavy
            int nodeBalance = origin.Balance();
            //Right rotate
            if (nodeBalance > 1 && data.CompareTo(origin.Left.Data) < 0)
            {
                if (root.Equals(origin)) root = RightRotate(root);
                else if (parent.Left != null && parent.Left.Equals(origin)) parent.Left = RightRotate(origin);
                else parent.Right = RightRotate(origin);
                return;
            }
            //Left rotate
            if (nodeBalance < -1 && data.CompareTo(origin.Right.Data) > 0)
            {
                if (root.Equals(origin)) root = LeftRotate(root);
                else if (parent.Left != null && parent.Left.Equals(origin)) parent.Left = LeftRotate(origin);
                else parent.Right = LeftRotate(origin);
                return;
            }
            //Left-right rotate
            if (nodeBalance > 1 && data.CompareTo(origin.Left.Data) > 0)
            {
                origin.Left = LeftRotate(origin.Left);

                if (root.Equals(origin)) root = RightRotate(root);
                else if (parent.Left != null && parent.Left.Equals(origin)) parent.Left = RightRotate(origin);
                else parent.Right = RightRotate(origin);
                return;
            }
            //Right-left rotate
            if (nodeBalance < -1 && data.CompareTo(origin.Right.Data) < 0)
            {
                origin.Right = RightRotate(origin.Right);

                if (root.Equals(origin)) root = LeftRotate(root);
                else if (parent.Left != null && parent.Left.Equals(origin)) parent.Left = LeftRotate(origin);
                else parent.Right = LeftRotate(origin);
            }
        }

        public void Remove(T data)
        {
            Remove(data, root, root);
        }

        private AVLTreeNode<T> Remove(T data, AVLTreeNode<T> origin, AVLTreeNode<T> parent)
        {
            if (origin == null || data == null) return null;
            int comparisonResult = data.CompareTo(origin.Data);

            if (comparisonResult < 0)
            {
                origin.Left = Remove(data, origin.Left, parent);
                Rebalance(origin, parent);
                return origin;
            }

            if (comparisonResult > 0)
            {
                origin.Right = Remove(data, origin.Right, parent);
                Rebalance(origin, parent);
                return origin;
            }

            if (comparisonResult == 0)
            {
                if (origin.Left != null && origin.Right != null)
                {
                    var minimum = Minimum(origin.Right);

                    origin.Data = minimum;
                    origin.Right = Remove(minimum, origin.Right, parent);
                    Rebalance(origin, parent);
                    return origin;
                }

                if (origin == root && origin.Left == null && origin.Right == null) return root = null;
                if (origin.Left == null) return origin.Right;
                if (origin.Right == null) return origin.Left;

            }

            return null;
        }

        //Removal rebalance (find heavier side and rebalance)
        private void Rebalance(AVLTreeNode<T> origin, AVLTreeNode<T> parent)
        {
            //Update height before checking for balance
            origin.CalculateHeight();

            //Balance > 0 == Left-heavy. Balance < 0 == Right-heavy
            int nodeBalance = origin.Balance();

            if (nodeBalance > 1 && origin.Left.Balance() >= 0)
            {
                if (root.Equals(origin)) root = RightRotate(root);
                else if (parent.Left != null && parent.Left.Equals(origin)) parent.Left = RightRotate(origin);
                else parent.Right = RightRotate(origin);
                return;
            }
            if (nodeBalance < -1 && origin.Right.Balance() <= 0)
            {
                if (root.Equals(origin)) root = LeftRotate(root);
                else if (parent.Left != null && parent.Left.Equals(origin)) parent.Left = LeftRotate(origin);
                else parent.Right = LeftRotate(origin);
                return;
            }
            if (nodeBalance > 1 && origin.Left.Balance() < 0)
            {
                origin.Left = LeftRotate(origin.Left);

                if (root.Equals(origin)) root = RightRotate(root);
                else if (parent.Left != null && parent.Left.Equals(origin)) parent.Left = RightRotate(origin);
                else parent.Right = RightRotate(origin);
                return;
            }
            if (nodeBalance < -1 && origin.Right.Balance() > 0)
            {
                origin.Right = RightRotate(origin.Right);

                if (root.Equals(origin)) root = LeftRotate(root);
                else if (parent.Left != null && parent.Left.Equals(origin)) parent.Left = LeftRotate(origin);
                else parent.Right = LeftRotate(origin);
            }
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

        #region Printing methods
        public void PrintAll(bool levelOrder = false)
        {
            if (IsEmpty) return; 
            if (levelOrder) PrintLevelOrder(root);
            else Print(root);
        }

        private void Print(AVLTreeNode<T> origin) //In order traversal
        {
            if (origin.Left != null) Print(origin.Left);

            Console.WriteLine($"{origin.Data}, ({origin.Height})");

            if (origin.Right != null) Print(origin.Right);
        }

        private void PrintLevelOrder(AVLTreeNode<T> origin) //Level order traversal
        {
            var printQueue = new PriorityQueue<string>();

            PrintLevel(origin, 0, printQueue);

            while (!printQueue.IsEmpty)
            {
                Console.WriteLine(printQueue.Dequeue());
            }
        }

        private void PrintLevel(AVLTreeNode<T> origin, int level, PriorityQueue<string> printQueue)
        {
            printQueue.Enqueue($"{origin.Data} ({level})", level);

            if (origin.Left != null) PrintLevel(origin.Left, level + 1, printQueue);
            if (origin.Right != null) PrintLevel(origin.Right, level + 1, printQueue);
        }
        #endregion

        #region Traversal
        public List<T> GetOrderedList()
        {
            List<T> orderedList = new List<T>();

            InOrderTraversal(root, ref orderedList);

            return orderedList;
        }

        private void InOrderTraversal(AVLTreeNode<T> origin, ref List<T> orderedList)
        {
            if (origin == null) return;

            InOrderTraversal(origin.Left, ref orderedList);
            orderedList.Add(origin.Data);
            InOrderTraversal(origin.Right, ref orderedList);
        }
        #endregion

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
            if (Left == null) return 0 - Right.Height;
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
