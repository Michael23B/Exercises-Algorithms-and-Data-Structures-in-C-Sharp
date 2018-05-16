using System.Collections.Generic;
using PracticeQuestionsSharp.DataStructures;

namespace PracticeQuestionsSharp.Algorithms
{
    //Iterative depth-first search with my stack implementation
    public static class DepthFirstSearch
    {
        public static GraphNode<T> DFS<T>(this SimpleGraph<T> graph, GraphNode<T> target)
        {
            if (graph == null || graph.Nodes.Count == 0) return null;

            var hash = new HashSet<GraphNode<T>>();
            var stack = new DataStructures.Stack<GraphNode<T>>();
            stack.Push(graph.Nodes[0]);

            while (!stack.IsEmpty)
            {
                GraphNode<T> curr = stack.Pop();

                if (hash.Contains(target)) continue;

                if (curr == target) return curr;

                hash.Add(curr);
                foreach (GraphNode<T> neighbor in curr.Neighbors) stack.Push(neighbor);
            }

            return null;
        }
    }
}
