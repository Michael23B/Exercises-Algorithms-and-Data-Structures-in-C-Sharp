using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;
using NodePath = System.Collections.Generic.List<PracticeQuestionsSharp.Exercises.BinaryTreeNodeWithParent<int>>;

namespace PracticeQuestionsSharp.Exercises
{
    //Given a binary tree, find all paths (from a node to a leaf) that sum to a given number.
    //TODO: currently only checks paths from root, change to any node
    public static class BinaryTreePathsWithSum
    {
        public static List<NodePath> PathsWithSum(this BinaryTreeNodeWithParent<int> root, int sum)
        {
            var paths = new List<NodePath>();
            var leaves = new NodePath();
            GetLeaves(root, ref leaves);

            foreach (var leaf in leaves) paths.Add(GetPathToRoot(leaf));

            AddAllSubPaths(ref paths);

            paths.RemoveAll(x => x.Sum(y => y.Data) != sum);
            paths.ForEach(x => x.Reverse());

            return paths.Count != 0 ? paths : null;
        }

        //Foreach path in the referenced list, creates a new path for every node that it could start from
        //eg. 1->2->3->4 gives 2->3->4, 3->4, 4
        //TODO: I don't need to create a new list for every permutation, instead just check if the sum would be correct and then add it if so
        private static void AddAllSubPaths(ref List<NodePath> allPaths)
        {
            List<NodePath> allSubPaths = new List<NodePath>();

            foreach (var path in allPaths)
            {
                NodePath pathCopy = new NodePath();
                pathCopy.AddRange(path);

                while (pathCopy.Count > 0)
                {
                    NodePath newPath = new NodePath();
                    newPath.AddRange(pathCopy);
                    allSubPaths.Add(newPath);
                    pathCopy.RemoveAt(pathCopy.Count - 1);
                }
            }

            allPaths = allSubPaths;
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

        private static NodePath GetPathToRoot(BinaryTreeNodeWithParent<int> node)
        {
            NodePath path = new NodePath();
            while (node != null)
            {
                path.Add(node);
                node = node.Parent;
            }

            return path;
        }
    }
}
