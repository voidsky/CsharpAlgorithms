using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /* Stack implemented using linked lists */
    public class Stack<T> : IStack<T>, IEnumerable<T>
    {
        private Node<T> First;
        private int NumberOfItems;

        public bool IsEmpty()
        {
            return NumberOfItems == 0;
        }

        public T Pop()
        {
            T item = First.Item;
            First = First.Next;
            NumberOfItems--;
            return item;
        }

        public void Push(T item)
        {
            Node<T> oldFirst = First;
            First = new Node<T>();
            First.Item = item;
            First.Next = oldFirst;
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
