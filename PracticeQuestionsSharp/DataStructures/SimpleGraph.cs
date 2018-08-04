using System;
using System.Collections.Generic;

namespace PracticeQuestionsSharp.DataStructures
{
    //Simple graph implementation for use in some exercises. Has links to nodes and thats about it.
    public class SimpleGraph<T>
    {
        public SimpleGraph()
        {
            Nodes = new List<GraphNode<T>>();
        }

        public SimpleGraph<T> Add(T data)
        {
            GraphNode<T> newNode = new GraphNode<T>(data);

            if (Nodes.Count == 0) Root = newNode;

            Nodes.Add(newNode);

            return this;
        }

        public SimpleGraph<T> Link(GraphNode<T> origin, GraphNode<T> neighbor)
        {
            origin.Neighbors.Add(neighbor);
            return this;
        }

        public SimpleGraph<T> Link(T originData, T neighborData)
        {
            GraphNode<T> originNode = Nodes.Find(x => x.Data.Equals(originData));
            GraphNode<T> neighborNode = Nodes.Find(x => x.Data.Equals(neighborData));

            if (neighborNode.Origin != null) throw new InvalidOperationException
                ($"Can't add link! Node {neighborNode.Data} already has origin {neighborNode.Origin.Data}.");

            neighborNode.Origin = originNode;
            originNode.Neighbors.Add(neighborNode);
            return this;
        }

        public List<GraphNode<T>> Nodes { get; }
        public GraphNode<T> Root { get; set; }
    }

    public class GraphNode<T>
    {
        public GraphNode(T data = default(T))
        {
            Data = data;
            Neighbors = new List<GraphNode<T>>();
            Origin = null;
        }

        public T Data { get; set; }
        public List<GraphNode<T>> Neighbors { get; }
        public GraphNode<T> Origin { get; set; }
    }
}