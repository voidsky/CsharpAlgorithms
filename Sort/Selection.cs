using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    /*  Selection sort uses N 2/2 compares and N exchanges to sort an array of length N. */
    public static class Selection<T> where T:IComparable
    {
        public static void Sort(T[] a)
        {
            int N = a.Length;
            for (int i = 0; i < N; i++)
            {
                int min = i;
                for (int j = i + 1; j<N; j++)
                {
                    if (a[j].CompareTo(a[min]) == -1)
                    {
                        var tmp = a[min];
                        a[min] = a[j];
                        a[j] = tmp;
                    }
                }
            }
        }

        public static List<T> FindSmallest(T[] a,int n)
        {
            int N = a.Length;
            List<T> result = new List<T>();

            for (int i = 0; i < n; i++)
            {
                int min = i;
                for (int j = i + 1; j < N; j++)
                {
                    if (a[j].CompareTo(a[min]) == -1)
                    {
                        var tmp = a[min];
                        a[min] = a[j];
                        a[j] = tmp;
                    }
                }
                result.Add(a[min]);
            }

            return result;
        }
    }
}
