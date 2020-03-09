using System;

namespace GenericList
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    public class List<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public List()
        {
            tail = head = null;
        }

        public Node<T> Head
        {
            get => head;
        }

        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }

        public void ForEach(Action<T> f)
        {
            Node<T> currentNode = head;
            while (currentNode != tail)
            {
                f(currentNode.Data);
                currentNode = currentNode.Next;
            }
            f(currentNode.Data);
        }
    }
}
