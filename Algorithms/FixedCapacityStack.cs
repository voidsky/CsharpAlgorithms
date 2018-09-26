using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class FixedCapacityStack<T> : IStack<T>
    {
        private T[] StackItems;
        private int StackPointer;

        public FixedCapacityStack(int capacity)
        {
            this.StackItems = new T[capacity];
            this.StackPointer = 0;
        }

        public void Push(T item)
        {
            this.StackItems[StackPointer++] = item;
        }

        public T Pop()
        {
            return this.StackItems[--this.StackPointer];
        }

        public bool IsEmpty()
        {
            return this.StackPointer == 0;
        }

        public int Size()
        {
            return this.StackPointer;
        }
    }
}
