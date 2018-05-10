using System;

namespace PracticeQuestionsSharp.DataStructures
{
    class LinkedList<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }
        //TODO: Count

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

        public void Remove(Node<T> node)
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

        //TODO: AddAfter()

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

        public void Clear()
        {
            Head = null;
            Tail = null;
        }
        
        public void Print()
        {
            Node<T> n = Head;
            while (n != null)
            {
                if (n == Head) Console.WriteLine(n.Data + " (head)");
                else if (n == Tail) Console.WriteLine(n.Data + " (tail)");
                else Console.WriteLine(n.Data);
                n = n.Next;
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