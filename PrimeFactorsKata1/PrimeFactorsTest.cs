using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace PrimeFactorsKata1
{
    [TestFixture]
    public class PrimeFactorsTest
    {
        [Test]
        [TestCase(1, new int[] { })]
        [TestCase(2, new int[] { 2 })]
        [TestCase(3, new int[] { 3 })]
        [TestCase(4, new int[] { 2,2 })]
        [TestCase(5, new int[] { 5 })]
        [TestCase(6, new int[] { 2, 3 })]
        [TestCase(7, new int[] { 7 })]
        [TestCase(8, new int[] { 2, 2, 2 })]
        [TestCase(9, new int[] { 3, 3 })]
        [TestCase(10, new int[] { 2, 5 })]
        [TestCase(12, new int[] { 2, 2, 3 })]
        [TestCase(128, new int[] { 2, 2, 2, 2, 2, 2, 2 })]
        public void TestWithItterationReturnsResult(int number, int[] expected)
        {
            List<int> result = PrimeFactors.GenerateUsingItteration( number );
            Assert.That(result, Is.EqualTo( expected ));
        }

        [Test]
        [TestCase(1, new int[] { })]
        [TestCase(2, new int[] { 2 })]
        [TestCase(3, new int[] { 3 })]
        [TestCase(4, new int[] { 2, 2 })]
        [TestCase(5, new int[] { 5 })]
        [TestCase(6, new int[] { 2, 3 })]
        [TestCase(7, new int[] { 7 })]
        [TestCase(8, new int[] { 2, 2, 2 })]
        [TestCase(9, new int[] { 3, 3 })]
        [TestCase(10, new int[] { 2, 5 })]
        [TestCase(12, new int[] { 2, 2, 3 })]
        [TestCase(128, new int[] { 2, 2, 2, 2, 2, 2, 2 })]
        public void TestWithrecursionReturnsResult(int number, int[] expected)
        {
            List<int> result = PrimeFactors.GenerateUsingRecursion(number);
            Assert.That(result, Is.EqualTo(expected));
        }

    }
}
