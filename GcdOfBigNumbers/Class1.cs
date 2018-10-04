using System;

namespace GcdOfBigNumbers
{
    public class BigNumber
    {
        private string numerals;
        public BigNumber(string numerals)
        {
            this.numerals = numerals;
        }

        public bool IsEven()
        {
            return true;
        }

    }
    public class Dividor
    {
        public BigNumber Divide(BigNumber a, BigNumber b)
        {
            int d = 0;
            while (a.IsEven() && b.IsEven())
            {
                a = a.DivideByTwo();
                b = b.DivideByTwo();
                d++;

                while (!a.Equals(b))
                {
                    if (a.IsEven())
                    {
                        a = a.DivideByTwo();
                    } else if (b.IsEven())
                    {
                        b = b.DivideByTwo();
                    } else if (a.GreaterThan(b))
                    {
                        a = a.Minus(b);
                        a = a.DivideByTwo();
                    }
                    else
                    {
                        b = b.Minus(a);
                        b = b.DivideByTwo();
                    }
                }
            }

            var g = a;
            var gcd = g.MultiplyBy(2 ^ d);
            return gcd;
        }
    }
}
