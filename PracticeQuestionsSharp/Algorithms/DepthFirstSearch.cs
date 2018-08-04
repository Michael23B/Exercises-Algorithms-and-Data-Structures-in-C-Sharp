using System.Collections.Generic;
using PracticeQuestionsSharp.DataStructures;

namespace PracticeQuestionsSharp.Algorithms
{
    public static class DepthFirstSearch
    {
        //Iterative depth-first search that returns the node with the target data.
        public static GraphNode<T> DFS<T>(this SimpleGraph<T> graph, T target)
        {
            if (graph == null || graph.Nodes.Count == 0) return null;

            var visited = new HashSet<GraphNode<T>>();
            var stack = new DataStructures.Stack<GraphNode<T>>();
            stack.Push(graph.Root);

            while (!stack.IsEmpty)
            {
                GraphNode<T> curr = stack.Pop();

                if (visited.Contains(curr)) continue;

                if (curr.Data.Equals(target)) return curr;

                visited.Add(curr);
                foreach (GraphNode<T> neighbor in curr.Neighbors) stack.Push(neighbor);
            }

            return null;
        }

        //Iterative depth-first search that returns the path to the target
        public static List<GraphNode<T>> DFSPathTo<T>(this SimpleGraph<T> graph, T target)
        {
            if (graph == null || graph.Nodes.Count == 0) return null;

            var visited = new HashSet<GraphNode<T>>();
            var stack = new DataStructures.Stack<GraphNode<T>>();
            stack.Push(graph.Root);
            GraphNode<T> curr = null;
            var path = new List<GraphNode<T>>();

            while (!stack.IsEmpty)
            {
                curr = stack.Pop();

                if (visited.Contains(curr)) continue;

                if (curr.Data.Equals(target)) break;

                visited.Add(curr);
                foreach (GraphNode<T> neighbor in curr.Neighbors) stack.Push(neighbor);
            }

            if (!curr.Data.Equals(target)) return null;

            while (curr.Origin != null && !curr.Equals(graph.Root))
            {
                path.Add(curr);
                curr = curr.Origin;
            }
            path.Add(curr);
            path.Reverse();

            return path;
        }
    }
}
