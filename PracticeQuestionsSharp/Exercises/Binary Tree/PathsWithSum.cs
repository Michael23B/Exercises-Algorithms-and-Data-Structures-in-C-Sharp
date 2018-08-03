using System.Collections.Generic;
using System.Linq;
using NodePath = System.Collections.Generic.List<PracticeQuestionsSharp.Exercises.Binary_Tree.BinaryTreeNodeWithParent<int>>;

namespace PracticeQuestionsSharp.Exercises.Binary_Tree
{
    //Given a binary tree, find all paths (from a node to a leaf) that sum to a given number.
    public static class PathsWithSum
    {
        public static List<NodePath> FindPathsWithSum(this BinaryTreeNodeWithParent<int> root, int sum)
        {
            var paths = new List<NodePath>();
            var leaves = new NodePath();
            GetLeaves(root, ref leaves);
            
            foreach (var leaf in leaves) paths.AddRange(GetPathsWithSum(leaf, sum));

            paths.ForEach(x => x.Reverse());

            return paths.Count != 0 ? paths : null;
        }

        //Adds all leaves of a binary tree to a given list
        private static void GetLeaves(BinaryTreeNodeWithParent<int> origin, ref NodePath leaves)
        {
            if (origin == null) return;
            if (origin.Left == null && origin.Right == null)
            {
                leaves.Add(origin);
                return;
            }
            GetLeaves(origin.Left, ref leaves);
            GetLeaves(origin.Right, ref leaves);
        }

        //Travel upwards from leaf node and return any path that adds to the sum
        //We don't stop when we reach the sum since there may be negative values
        private static List<NodePath> GetPathsWithSum(BinaryTreeNodeWithParent<int> node, int sum)
        {
            NodePath currPath = new NodePath();
            int currSum = 0;
            List<NodePath> pathsWithSum = new List<NodePath>();

            while (node != null)
            {
                currSum += node.Data;
                currPath.Add(node);
                if (currSum == sum) pathsWithSum.Add(currPath.ToList()); //ToList to make a copy
                node = node.Parent;
            }

            return pathsWithSum;
        }
    }
}
