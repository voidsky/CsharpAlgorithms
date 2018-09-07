using System;
using System.Collections.Generic;

namespace PrimeFactorsKata1
{
    public class PrimeFactors
    {
        public static List<int> GenerateUsingRecursion(int number)
        {
            List<int> factors = new List<int>();
            for (int x = 2; x <= number; x++)
            {
                if (number % x == 0)
                {
                    factors.Add(x);
                    factors.AddRange(GenerateUsingRecursion(number / x));
                    return factors;
                }
            }
            return factors;
        }

        public static List<int> GenerateUsingItteration(int number)
        {
            List<int> factors = new List<int>();
            int num = number;
            for (int x = 2; x <= num; x++)
            {
                while (num % x == 0)
                {
                    factors.Add(x);
                    num /= x;
                }
            }
            return factors;
        }
    }
}