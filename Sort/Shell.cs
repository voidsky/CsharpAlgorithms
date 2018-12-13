using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public static class Shell<T> where T : IComparable
    {
        public static void Sort(T[] a)
        {
            int N = a.Length;
            int h = 1;

            while (h < N / 3) h = 3 * h + 1;

            while (h >= 1)
            {
                for (int i = h; i < N; i++)
                    for (int j = i; j >= h; j -= h)
                        if (a[j].CompareTo(a[j - h]) == -1)
                        {
                            var tmp = a[j - h];
                            a[j - h] = a[j];
                            a[j] = tmp;
                        }
                h = h / 3;
            }
        }

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
