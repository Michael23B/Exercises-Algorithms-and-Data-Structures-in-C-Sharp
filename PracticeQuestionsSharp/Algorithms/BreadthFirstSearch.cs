using System.Collections.Generic;
using PracticeQuestionsSharp.DataStructures;

namespace PracticeQuestionsSharp.Algorithms
{
    public static class BreadthFirstSearch
    {
        //Iterative depth-first search that returns the node with the target data.
        public static GraphNode<T> BFS<T>(this SimpleGraph<T> graph, T target)
        {
            if (graph == null || graph.Nodes.Count == 0) return null;

            var visited = new HashSet<GraphNode<T>>();
            var queue = new DataStructures.Queue<GraphNode<T>>();
            queue.Enqueue(graph.Root);

            while (!queue.IsEmpty)
            {
                GraphNode<T> curr = queue.Dequeue();

                if (visited.Contains(curr)) continue;

                if (curr.Data.Equals(target)) return curr;

                visited.Add(curr);
                foreach (GraphNode<T> neighbor in curr.Neighbors) queue.Enqueue(neighbor);
            }

            return null;
        }

        //Iterative depth-first search that returns the path to the target
        public static List<GraphNode<T>> BFSPathTo<T>(this SimpleGraph<T> graph, T target)
        {
            if (graph == null || graph.Nodes.Count == 0) return null;

            var visited = new HashSet<GraphNode<T>>();
            var queue = new DataStructures.Queue<GraphNode<T>>();
            queue.Enqueue(graph.Root);
            GraphNode<T> curr = null;
            var path = new List<GraphNode<T>>();

            while (!queue.IsEmpty)
            {
                curr = queue.Dequeue();

                if (visited.Contains(curr)) continue;

                if (curr.Data.Equals(target)) break;

                visited.Add(curr);
                foreach (GraphNode<T> neighbor in curr.Neighbors) queue.Enqueue(neighbor);
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
