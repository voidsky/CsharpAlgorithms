using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariousAlgorithms
{
    [TestFixture]
    public class VariousAlgorithmsTest
    {
        [Test]
        [TestCase(10, new int[] { 1 }, 1)]
        [TestCase(10, new int[] { 5 }, 1)]
        [TestCase(5, new int[] { 5 }, 1)]
        [TestCase(10,new int[] { 5,1}, 3)]
        [TestCase(100, new int[] { 50, 25, 10, 5, 1 }, 292)]
        public void CountChangeTest(int amount, int[] coinTypes, int expected)
        {
            int result = VariousAlgorithms.CountChange(amount, coinTypes);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(1, 1, 1)]
        [TestCase(2, 1, 1)]
        [TestCase(2, 2, 1)]
        [TestCase(3, 1, 1)]
        [TestCase(3, 2, 2)]
        [TestCase(3, 3, 1)]
        [TestCase(4, 1, 1)]
        [TestCase(4, 2, 3)]
        [TestCase(4, 3, 3)]
        [TestCase(4, 4, 1)]
        [TestCase(8, 5, 35)]
        public void PascalTriangleTest(int x, int y, int expected)
        {
            int result = VariousAlgorithms.PascalsTriagle(x ,y);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
