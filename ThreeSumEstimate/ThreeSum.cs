using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeSumEstimate
{
    public class ThreeSum
    {
        public static int count(int[] a)
        {
            int N = a.Length;
            int cnt = 0;
            for (int i = 0; i < N; i++)
                for (int j = i+1; i < N; i++)
                    for (int k = j + 1; k < N; k++)
                        if (a[i] + a[j] + a[k] == 0)
                            cnt++;
            return cnt;
        }
    }
}
