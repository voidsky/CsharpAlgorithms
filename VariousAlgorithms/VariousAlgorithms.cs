using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariousAlgorithms
{
    public static class VariousAlgorithms
    {
        // Havin amount of money A, how many different ways 
        // we can change it using coinTypes ? 
        // Structure and Interpolation of computer programs, p41
        // This generates a tree recursive process.
        public static int CountChange(int a, int[] coinTypes)
        {
            return CountChange(a, coinTypes, 0);
        }
        public static int CountChange(int a, int[] coinTypes, int coinIndex = 0)
        {
            if (a == 0) return 1;
            if (a < 0) return 0;
            if (coinIndex == coinTypes.Length) return 0;

            return CountChange(a - coinTypes[coinIndex], coinTypes, coinIndex) +
                CountChange(a, coinTypes, ++coinIndex);
        }

        // Calculate pascal triangle value on y row, x column using
        // only recursion.
        public static int PascalsTriagle(int y, int x)
        {
            if (x == 1 || x == y) return 1;
            return PascalsTriagle(x-1, y-1) + PascalsTriagle(x, y-1);
        }


    }
}
