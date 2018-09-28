using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Algorithms
{
	[TestFixture]
    public class BagTest
    {
		[Test]
		public void TestAddAndItterate()
        {
            Bag<int> bag = new Bag<int>();
            Assert.AreEqual(true, bag.IsEmpty());
            bag.Add(6);
            Assert.AreEqual(1, bag.Size());
            bag.Add(7);
            Assert.AreEqual(2, bag.Size());
            bag.Add(8);
            Assert.AreEqual(3, bag.Size());

            int shouldBe = 8;
            foreach (int i in bag)
            {
                Assert.AreEqual(shouldBe, i);
                shouldBe--;
            }

        }
    }
}
