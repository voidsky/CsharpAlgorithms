using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /* Queue is FIFO type of container. */
    /* This is Queue implemented using linked lists. */
    public class Queue<T> : IQueue<T>, IEnumerable<T>
    {
        private Node<T> First;
        private Node<T> Last;

        private int NumberOfItems;

        public bool IsEmpty()
        {
            return NumberOfItems == 0;
        }

        public T Dequeue()
        {
            T item = First.Item;
            First = First.Next;
            NumberOfItems--;
            return item;
        }

        public void Enqueue(T item)
        {
            Node<T> oldLast = Last;
            Last = new Node<T>();
            Last.Item = item;
            if (oldLast != null ) oldLast.Next = Last;
            if (First == null) First = Last;
            NumberOfItems++;
        }

        public int Size()
        {
            return NumberOfItems;
        }

        public IEnumerator<T> GetEnumerator()
        {
            INode<T> currentNode = First;
            while (currentNode != null) {
                yield return currentNode.Item;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
