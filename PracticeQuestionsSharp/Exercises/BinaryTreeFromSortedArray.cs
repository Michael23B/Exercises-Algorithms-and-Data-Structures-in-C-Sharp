using System.Linq;

namespace PracticeQuestionsSharp.Exercises
{
    public static class BinaryTreeFromSortedArray
    {
        //Creates a binary tree and returns the root from a sorted array
        public static BinaryTreeNodeWithParent<int> GenerateIntegerTree(int[] sortedArray)
        {
            return AddChildren(null, sortedArray);
        }

        private static BinaryTreeNodeWithParent<int> AddChildren(BinaryTreeNodeWithParent<int> parent, int[] sortedArray)
        {
            if (sortedArray.Length == 0) return null;

            var newNode = new BinaryTreeNodeWithParent<int>(sortedArray[sortedArray.Length / 2]);
            newNode.Parent = parent;

            newNode.Left = AddChildren(newNode, sortedArray.Take(sortedArray.Length / 2).ToArray());
            newNode.Right = AddChildren(newNode, sortedArray.Skip(sortedArray.Length / 2 + 1).ToArray());

            return newNode;
        }
    }
}