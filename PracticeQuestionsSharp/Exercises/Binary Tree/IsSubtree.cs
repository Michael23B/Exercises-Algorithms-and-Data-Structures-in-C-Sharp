using System;
using PracticeQuestionsSharp.DataStructures;

namespace PracticeQuestionsSharp.Exercises.Binary_Tree
{
    //Find whether a binary tree is a subtree of another binary tree.
    //This implementation defines subtree as sharing the same data for each node
    //and the same children for each node (including null children)
    public static class IsSubtree
    {
        public static bool IsSubtreeOf<T>(this BinaryTreeNodeWithParent<T> subtreeRoot, BinaryTreeNodeWithParent<T> treeRoot) where T : IComparable<T>
        {
            if (subtreeRoot == null || treeRoot == null) return false;

            BinaryTreeNodeWithParent<T> currNode;
            var queue = new Queue<BinaryTreeNodeWithParent<T>>();
            queue.Enqueue(treeRoot);

            //Iterate through each node and compare it to the first node of the subtree. If they match,
            //compare for each child in the subtree.
            while (!queue.IsEmpty)
            {
                currNode = queue.Dequeue();

                if (currNode.Data.CompareTo(subtreeRoot.Data) == 0)
                {
                    if (CompareNodes(subtreeRoot, currNode)) return true;
                }

                if (currNode.Left != null) queue.Enqueue(currNode.Left);
                if (currNode.Right != null) queue.Enqueue(currNode.Right);
            }

            return false;
        }

        private static bool CompareNodes<T>(BinaryTreeNodeWithParent<T> subtree, BinaryTreeNodeWithParent<T> tree) where T : IComparable<T>
        {
            //Check if we are finished...
            if (subtree == null && tree == null) return true;

            //otherwise compare children
            bool left;
            if (subtree.Left == null && tree.Left == null) left = true;
            else if (subtree.Left == null || tree.Left == null) left = false;
            else left = subtree.Left.Data.CompareTo(tree.Left.Data) == 0;

            bool right;
            if (subtree.Right == null && tree.Right == null) right = true;
            else if (subtree.Right == null || tree.Right == null) right = false;
            else right = subtree.Right.Data.CompareTo(tree.Right.Data) == 0;

            //If both children are null or equal, check their children.
            if (left && right)
            {
                return CompareNodes(subtree.Left, tree.Left) && CompareNodes(subtree.Right, tree.Right);
            }

            return false;
        }
    }
}
