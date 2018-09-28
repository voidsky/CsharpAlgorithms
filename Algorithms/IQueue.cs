using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    interface IQueue<T>
    {
        void Enqueue(T item);
        T Dequeue();
        int Size();
        bool IsEmpty();
    }
}
