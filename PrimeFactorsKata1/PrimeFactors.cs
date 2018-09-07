using System;
using System.Collections.Generic;

namespace PrimeFactorsKata1
{
    public class PrimeFactors
    {
        public static List<int> GenerateUsingRecursion(int number)
        {
            List<int> factors = new List<int>();
            for (int divisor = 2; divisor <= number; divisor++)
                if (number % divisor == 0)
                {
                    factors.Add( divisor );
                    factors.AddRange(GenerateUsingRecursion(number / divisor));
                    return factors;
                }
            return factors;
        }

        public static List<int> GenerateUsingItteration(int number)
        {
            List<int> factors = new List<int>();
            int num = number;
            for (int divisor = 2; divisor <= num; divisor++)
                while ( num % divisor == 0 )
                {
                    factors.Add(divisor);
                    num /= divisor;
                }
            return factors;
        }
    }
}