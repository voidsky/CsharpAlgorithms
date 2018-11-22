using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
    
namespace Sort
{
    [TestFixture]
    public class SelectionTest
    {
        [TestCase(1, new[] { 1 })]
        [TestCase(2, new[] { 1, 2 })]
        [TestCase(6, new[] { 1, 2, 3, 4, 5, 7 })]
        public void TestNSmallestKeys(int minCount, int[] expect)
        {
            int[] a = new[] { 5, 8, 1, 10, 7, 3, 4, 2 };
            List<int> smallest = Selection<int>.FindSmallest(a,minCount);
            Assert.That(smallest, Is.EquivalentTo(expect.ToList()));
        }
    }
}
