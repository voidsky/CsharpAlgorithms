using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class BstNode<Key,Value>
    {
        public Key key;
        public Value value;
        public BstNode<Key, Value> left, right;
        public int N;

        public BstNode(Key key, Value val, int n)
        {
            this.key = key;
            this.value = val;
            this.N = n;
        }
    }
}
