using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace PracticeQuestionsSharp.DataStructures
{
    class LinkedList<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }

        public LinkedList(T data)
        {
            Head = new Node<T>(data);
            Tail = Head;
        }

        public Node<T> Add(T data)
        {
            Node<T> n = Head;
            Node<T> newNode = new Node<T>(data);

            if (n == null)
            {
                n = newNode;
                Head = n;
                Tail = n;
                return n;
            }

            while (n.Next != null)
                n = n.Next;

            n.Next = newNode;
            newNode.Prev = n;
            Tail = newNode;

            return newNode;
        }

        //TODO: Add(Node<T> node) because I already have addbefore and addafter that take a node

        public void Remove(T data)
        {
            Node<T> n = Find(data);
            if (n != null) RemoveNode(n);
        }

        public void RemoveNode(Node<T> node)
        {
            Node<T> n = Head;

            while (n != null && n != node)
                n = n.Next;

            if (n == null) return;

            if (n.Next == null)
            {
                if (n.Prev == null)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    Tail = n.Prev;
                    Tail.Next = null;
                }
            }
            else
            {
                if (n.Prev != null)
                {
                    n.Prev.Next = n.Next;
                    n.Next.Prev = n.Prev;
                }
                else
                {
                    Head = n.Next;
                    Head.Prev = null;
                }
            }

            n = null;
        }

        //We don't use [] because we don't have array access performance
        public Node<T> At(int index)
        {
            Node<T> n = Head;
            int count = 0;

            while (count != index && n?.Next != null)
            {
                count++;
                n = n.Next;
            }

            return (count < index) ? null : n;
        }

        public Node<T> AddBefore(T data, int index)
        {
            if (Head == null) return Add(data);

            Node<T> n = At(index) ?? Tail;
            Node<T> newNode = new Node<T>(data);

            newNode.Next = n;
            if (n.Prev != null)
            {
                newNode.Prev = n.Prev;
                newNode.Prev.Next = newNode;
            }
            else
            {
                Head = newNode;
            }
            n.Prev = newNode;

            return newNode;
        }

        //Adding before a node from another list is unnexpected behaviour. 
        //But it's a convenient method and I don't want to have to check if the list contains the node (too slow).
        public Node<T> AddBefore(T data, Node<T> node)
        {
            if (node == null) return null;

            Node<T> newNode = new Node<T>(data);

            newNode.Next = node;
            if (node.Prev != null)
            {
                newNode.Prev = node.Prev;
                newNode.Prev.Next = newNode;
            }
            else
            {
                Head = newNode;
            }
            node.Prev = newNode;

            return newNode;
        }

        public Node<T> AddAfter(T data, int index)
        {
            if (Head == null) return Add(data);

            Node<T> n = At(index) ?? Tail;
            Node<T> newNode = new Node<T>(data);

            newNode.Prev = n;
            if (n.Next != null)
            {
                newNode.Next = n.Next;
                newNode.Next.Prev = newNode;
            }
            else
            {
                Tail = newNode;
            }
            n.Next = newNode;

            return newNode;
        }

        //Adding after a node from another list is unnexpected behaviour. 
        public Node<T> AddAfter(T data, Node<T> node)
        {
            if (node == null) return null;

            Node<T> newNode = new Node<T>(data);

            newNode.Prev = node;
            if (node.Next != null)
            {
                newNode.Next = node.Next;
                newNode.Next.Prev = newNode;
            }
            else
            {
                Tail = newNode;
            }
            node.Next = newNode;

            return newNode;
        }

        public Node<T> Find(T data)
        {
            Node<T> n = Head;

            while (n != null)
            {
                if (n.Data.Equals(data))
                    return n;
                n = n.Next;
            }

            return null;
        }

        public IList<Node<T>> FindAll(Func<T, bool> predicate = null)
        {
            predicate = predicate ?? (T => true);

            Node<T> n = Head;
            IList<Node<T>> results = new List<Node<T>>();

            while (n != null)
            {
                if (predicate(n.Data))
                    results.Add(n);
                n = n.Next;
            }

            return results;
        }

        public int Count(Func<T, bool> predicate = null)
        {
            predicate = predicate ?? (T => true);

            int count = 0;
            Node<T> n = Head;

            while (n != null)
            {
                if (predicate(n.Data)) count++;
                n = n.Next;
            }

            return count;
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
        }
        
        public void Print(bool reverse = false)
        {
            Node<T> n = reverse ? Tail : Head;
            while (n != null)
            {
                if (n == Head) Console.WriteLine(n.Data + " (head)");
                else if (n == Tail) Console.WriteLine(n.Data + " (tail)");
                else Console.WriteLine(n.Data);
                n = reverse ? n.Prev : n.Next;
            }
        }
    }

    class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Prev { get; set; }

        public Node(T data = default(T))
        {
            Data = data;
        }
    }
}