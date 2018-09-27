using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public interface INode<T>
    {
        T Item { get; set; }
        Node<T> Next { get; set; }
    }
}
