using System;
using System.Collections.Generic;

namespace PrimeFactorsKata1
{
    public class PrimeFactors
    {
        public static List<int> Generate(int number)
        {
            List<int> factors = new List<int>();
            if (number == 1) return factors;

            int x = 2;
            while ( x <= number)
            {
                if (number % x == 0)
                {
                    factors.Add(x);
                    number = number / x;
                    x = 2;
                } else
                {
                    x++;
                }
            }

            return factors;
        }
    }
}