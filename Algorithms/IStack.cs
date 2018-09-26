using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    interface IStack<T>
    {
        void Push(T item);
        T Pop();
        int Size();
        bool IsEmpty();
    }
}
