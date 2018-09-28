using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /* Bag is a type of container where removing items is not possible. */
    /* You can only add and itterate over items. */
    /* This is Bag implemented using linked lists. */
    public class Bag<T> : IBag<T>, IEnumerable<T>
    {
        private Node<T> First;
        private int NumberOfItems;

        public bool IsEmpty()
        {
            return NumberOfItems == 0;
        }

        public void Add(T item)
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
