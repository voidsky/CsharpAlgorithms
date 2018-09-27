using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Node<T> : INode<T>
    {
        public T Item { get; set; }
        public Node<T> Next { get; set; }
    }
}
