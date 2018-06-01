using System;
using System.Collections;
using System.Collections.Generic;
/*
Doubly-linked list implementation

Some methods allow passing nodes directly either for convenience or to decrease run time
(deleting a node in the middle of the list is O(1) because of this (assuming you have a reference to it)).
However passing a node from another list will result in weird behaviour so probably don't do it.

Count() takes O(N) because we can't keep track of the number when a user could change the Prev or Next of any
element manually.
*/
namespace PracticeQuestionsSharp.DataStructures
{
    public class LinkedList<T> : IEnumerable<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }

        public LinkedList()
        {
            Head = null;
            Tail = null;
        }

        public LinkedList(T data)
        {
            Head = new Node<T>(data);
            Tail = Head;
        }

        public Node<T> Add(T data)
        {
            Node<T> n = Tail;
            Node<T> newNode = new Node<T>(data);

            if (n == null)
            {
                n = newNode;
                Head = n;
                Tail = n;
                return n;
            }

            n.Next = newNode;
            newNode.Prev = n;
            Tail = newNode;

            return newNode;
        }

        public bool Remove(T data)
        {
            Node<T> n = Find(data);
            return RemoveNode(n);
        }

        public bool RemoveNode(Node<T> node)
        {
            if (node == null) return false;

            if (node.Next == null)
            {
                if (node.Prev == null)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    Tail = node.Prev;
                    Tail.Next = null;
                }
            }
            else
            {
                if (node.Prev != null)
                {
                    node.Prev.Next = node.Next;
                    node.Next.Prev = node.Prev;
                }
                else
                {
                    Head = node.Next;
                    Head.Prev = null;
                }
            }

            return true;
        }

        //We don't use [] because we don't have array access performance
        public Node<T> At(int index)
        {
            Node<T> n = Head;
            int count = 0;

            if (n == null) return null;

            while (count != index && n.Next != null)
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

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> n = Head;
            while (n != null)
            {
                yield return n.Data;
                n = n.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Node<T>
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