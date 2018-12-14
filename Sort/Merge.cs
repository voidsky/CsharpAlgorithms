using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public static class Merge<T> where T : IComparable
    {
        private static T[] aux;

        /* Merge a[lo..mid] with a[mid+1..hi] */
        /* used to merge sorted arrays in merge sort */
        private static void MergeArrays(T[] a, int lo, int mid, int hi)
        {
            int i = lo, j = mid + 1;

            for (int k = lo; k <= hi; k++) //Copy a[lo..hi] to aux[lo..hi]
                aux[k] = a[k];

            for (int k = lo; k <= hi; k++) //merge back to a[lo..hi] 
            {
                if (i > mid) a[k] = aux[j++];                                   // left half exhausted - take from right
                else if (j > hi) a[k] = aux[i++];                               // right side exhausted - take from left
                else if (aux[j].CompareTo(aux[i]) == -1) a[k] = aux[j++];       // left > right - take from right
                else a[k] = aux[i++];                                           // take from left    
            }
        }

        public static void Sort(T[] a)
        {
            aux = new T[a.Length];
            Sort( a, 0, a.Length -1 );

        }

        private static void Sort(T[] a, int lo, int hi)
        { // Sort a[lo..hi]
            if (hi <= lo) return;
            int mid = lo + (hi - lo) / 2;
            Sort(a, lo, mid);                   // Sort left half.
            Sort(a, mid+1, hi);                 // Sort right half.
            MergeArrays(a, lo, mid, hi);        // Merge results.
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
