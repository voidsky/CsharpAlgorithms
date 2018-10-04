using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BigNumber
{
    [TestFixture]
    public class BigNumberTest
    {
        [TestCase("32",2,"16",0)]
        [TestCase("0", 2, "0", 0)]
        [TestCase("100", 2, "50", 0)]
        [TestCase("5", 2, "2", 1)]
        public void TestLongDivision(string dividend, int divisor, string result, int rem)
        {
            BigNumber b = new BigNumber(dividend);
            Algorithms.Queue<int> stack = b.DivBy(divisor, out int reminder);

            StringBuilder str = new StringBuilder();
            foreach (int i in stack)
            {
                str.Append(i);
            }
            Assert.AreEqual(result, str.ToString());
            Assert.AreEqual(rem,reminder);

        }
    }
}
