using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Algorithms;

namespace FindNSmallest
{
    public class NSmallestUsingBST
    {
        public  Algorithms.BST<int,int> numbers;

        public void Randomize(long n)
        {
            numbers = new Algorithms.BST<int, int>();
            Random rand = new Random();
            for (int x = 1; x <= n; x++)
            {
                int r = rand.Next();
                numbers.Put(r, r);
            }
        }

        public void SetNumbers(List<int> lst)
        {
            numbers = new Algorithms.BST<int, int>();
            foreach (var i in lst)
            {
                  numbers.Put(i,i);
            }
        }

        public List<int> FindSmallest(int n)
        {
            List<int> result = numbers.GetNSmallestKeys(n);
            return result;
        }
    }
}
