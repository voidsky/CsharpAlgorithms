using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class ResizingArrayStack<T> : IStack<T>, IEnumerable<T>
    {
        private T[] Items = new T[1];
        private int Pointer;

        public void Push(T item)
        {
            if (Pointer == Items.Length) Resize(2 * Items.Length);
            Items[Pointer++] = item;
        }

        private void Resize(int size)
        {
            T[] resizedItems = new T[size];
            for (int index = 0; index < size / 2; index++)
            {
                resizedItems[index] = Items[index];
            }
            Items = resizedItems;
        }

        public T Pop()
        {
            T item = Items[--Pointer];
            Items[Pointer] = default(T);
            if (Pointer > 0 && Pointer == Items.Length / 4) Resize(Items.Length / 2);
            return item;
        }

        public bool IsEmpty()
        {
            return Pointer == 0;
        }

        public int Size()
        {
            return Pointer;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int index = 0; index < Pointer; index++)
            {
                yield return Items[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
