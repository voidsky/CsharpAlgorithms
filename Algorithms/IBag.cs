using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    interface IBag<T>
    {
        void Add(T item);
        int Size();
        bool IsEmpty();
    }
}
