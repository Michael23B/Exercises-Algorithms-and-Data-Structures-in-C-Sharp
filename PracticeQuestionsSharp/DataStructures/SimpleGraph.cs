using System.Collections.Generic;

namespace PracticeQuestionsSharp.DataStructures
{
    class SimpleGraph<T>
    {
        public SimpleGraph()
        {
            Nodes = new List<GraphNode<T>>();
        }

        public SimpleGraph<T> Add(T data, IList<GraphNode<T>> children = null)
        {
            GraphNode<T> newNode = new GraphNode<T>(data);
            if (children != null) foreach (var n in children) newNode.Children.Add(n);

            Nodes.Add(newNode);

            return this;
        }

        public List<GraphNode<T>> Nodes { get; }
    }

    public class GraphNode<T>
    {
        public GraphNode(T data = default(T))
        {
            Data = data;
            Children = new List<GraphNode<T>>();
        }

        public T Data { get; }
        public List<GraphNode<T>> Children { get; }
    }
}
