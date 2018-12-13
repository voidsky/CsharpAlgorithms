using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public static class Insertion<T> where T:IComparable
    {
        public static void Sort(T[] a)
        {
            int N = a.Length;
            for (int i = 0; i < N; i++)
            {
                int min = i;
                for (int j = i; j>0; j--)
                {
                    if (a[j].CompareTo(a[j-i]) == -1)
                    {
                        var tmp = a[j-1];
                        a[j-1] = a[j];
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
