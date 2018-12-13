using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    /*Insertion sort uses ~N^2/4 compares and ~N^2/4 exchanges
     to sort a randomly ordered array of length N with distinct keys,
     on the average. The worst case is ~N^2/2 compares and ~N^2/2 exchanges 
     and the best case is N- 1 compares and 0 exchanges. */
    public static class Insertion<T> where T : IComparable
    {
        public static void Sort(T[] a)
        {
            int N = a.Length;
            for (int i = 0; i < N; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (a[j].CompareTo(a[j - 1]) == -1)
                    {
                        var tmp = a[j - 1];
                        a[j - 1] = a[j];
                        a[j] = tmp;
                    }
                }
            }
        }

        /* Not effective at all to get N smallest because you must parse all
             the array first.*/
        public static List<T> FindSmallest(T[] a, int n)
        {
            Sort(a);

            List<T> result = new List<T>();

            for (int i = 0; i < n; i++)
            {
                result.Add(a[i]);
            }

            return result;
        }
    }
}
