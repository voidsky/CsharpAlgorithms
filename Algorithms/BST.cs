using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class BST<Key,Value> where Key : IComparable
    {
        private BstNode<Key, Value> root;

        public int Size()
        {
            return Size(root);
        }

        public int Size(BstNode<Key, Value> x)
        {
            if (x == null)
            {
                return 0;
            }
            else
            {
                return x.N;
            }
        }

        public Value Get(Key key)
        {
            return Get(root, key);
        }

        private Value Get(BstNode<Key, Value> x, Key key)
        {
            if (x == null) return default(Value);
            int cmp = key.CompareTo(x.key);
            if (cmp < 0)
            {
                return Get(x.left, key);
            }
            else if (cmp > 0)
            {
                return Get(x.right, key);
            }
            else
            {
                return x.value;
            }
        }

        public void Put(Key key, Value val)
        {
                root = Put(root, key, val);
        }

        private BstNode<Key,Value> Put(BstNode<Key, Value> x, Key key, Value val)
        {
            if (x == null) return new BstNode<Key, Value>(key, val, 1);
            int cmp = key.CompareTo(x.key);
            if (cmp < 0)
            {
                x.left = Put(x.left, key, val);
            }
            else if (cmp > 0)
            {
                x.right = Put(x.right, key, val);
            }
            else
            {
                x.value = val;
            }

            x.N = Size(x.left) + Size(x.right) + 1;
            return x;
        }

        public BstNode<Key, Value> Min()
        {
            return Min(root);
        }

        private BstNode<Key, Value> Min(BstNode<Key, Value> x)
        {
            if (x.left == null) return x;
            return Min(x.left);
        }

        public BstNode<Key, Value> Max()
        {
            return Max(root);
        }

        private BstNode<Key, Value> Max(BstNode<Key, Value> x)
        {
            if (x.right == null) return x;
            return Max(x.right);
        }

        public Key Floor(Key key)
        {
            BstNode<Key, Value> x = Floor(root, key);
            if (x == null) return default(Key);
            return x.key;
        }

        private BstNode<Key, Value> Floor(BstNode<Key, Value> x, Key key)
        {
            if (x == null) return null;
            int cmp = key.CompareTo(x.key);
            if (cmp == 0) return x;
            if (cmp < 0) return Floor(x.left, key);
            BstNode<Key, Value> t = Floor(x.right, key);
            if (t != null)
                return t;

            return x;
        }

        public Key Ceiling(Key key)
        {
            BstNode<Key, Value> x = Ceiling(root, key);
            if (x == null) return default(Key);
            return x.key;
        }

        private BstNode<Key, Value> Ceiling(BstNode<Key, Value> x, Key key)
        {
            if (x == null) return null;
            int cmp = key.CompareTo(x.key);
            if (cmp == 0) return x;
            if (cmp > 0) return Floor(x.right, key);
            BstNode<Key, Value> t = Floor(x.left, key);
            if (t != null)
                return t;
            
            return x;
        }

        public string Print()
        {
            StringBuilder sb = new StringBuilder();
            return Print(root, ref sb);
        }

        private string Print(BstNode<Key, Value> x, ref StringBuilder sb)
        {
            if (sb == null) sb = new StringBuilder();
            if (x == null) return "";
            Print(x.left, ref sb);
            sb.Append(x.key);
            Print(x.right, ref sb);
            return sb.ToString();
        }

        public List<Key> GetNSmallestKeys(int smallestCount)
        {
            List < Key > keys = new List<Key>();
            return GetNSmallestKeys(root, keys, smallestCount);
        }

        private List<Key> GetNSmallestKeys(BstNode<Key, Value> x, List<Key> keys, int smallestCount)
        {
            if (x == null) return keys;
            GetNSmallestKeys(x.left, keys, smallestCount);
            if (keys.Count >= smallestCount) return keys;
            keys.Add( x.key );
            GetNSmallestKeys(x.right, keys, smallestCount);
            return keys;
        }
    }
}
