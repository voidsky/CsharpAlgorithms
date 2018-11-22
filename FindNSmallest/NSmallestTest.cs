using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FindNSmallest
{
    [TestFixture]
    public class NSmallestTest
    {
        [TestCase(1, new[] {1})]
        [TestCase(2, new[] { 1,2 })]
        [TestCase(6, new[] { 1, 2,3,4,5,7 })]
        public void TestNSmallestKeys(int minCount, int[] expect)
        {
            int[] a = new[] {5,8,1,10,7,3,4,2};
            NSmallestUsingBST nsm = new NSmallestUsingBST();
            nsm.SetNumbers(a.ToList());            
            List<int> smallest = nsm.FindSmallest(minCount);
            Assert.That(smallest, Is.EquivalentTo(expect.ToList()));
        }

        [Test]
        public void TestNSmallestKeysRandom()
        {
            int numberToGet = 1000;
            int arraySize = 1000_000;

            Random rand = new Random();
            List<int> randomBytes = new List<int>();
            for (int i = 1; i <= arraySize; i++)
                randomBytes.Add(rand.Next());

            NSmallestUsingBST nsm = new NSmallestUsingBST();
            nsm.SetNumbers(randomBytes);
            List<int> smallest = nsm.FindSmallest(numberToGet);

            List<int> randomBytesSorted = new List<int>(randomBytes);
            randomBytesSorted.Sort();
            randomBytesSorted = randomBytesSorted.GetRange(0, numberToGet);

            Assert.That(smallest, Is.EquivalentTo(randomBytesSorted));
        }

    }
}
