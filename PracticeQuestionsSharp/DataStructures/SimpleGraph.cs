using System.Collections.Generic;

namespace PracticeQuestionsSharp.DataStructures
{
    public class SimpleGraph<T>
    {
        public SimpleGraph()
        {
            Nodes = new List<GraphNode<T>>();
        }

        public SimpleGraph<T> Add(T data, IList<GraphNode<T>> children = null)
        {
            GraphNode<T> newNode = new GraphNode<T>(data);
            if (children != null) foreach (var n in children) newNode.Neighbors.Add(n);

            Nodes.Add(newNode);

            return this;
        }

        public SimpleGraph<T> Link(GraphNode<T> parent, GraphNode<T> neighbor)
        {
            parent.Neighbors.Add(neighbor);
            return this;
        }

        public List<GraphNode<T>> Nodes { get; }
    }

    public class GraphNode<T>
    {
        public GraphNode(T data = default(T))
        {
            Data = data;
            Neighbors = new List<GraphNode<T>>();
        }

        public T Data { get; }
        public List<GraphNode<T>> Neighbors { get; }
    }
}