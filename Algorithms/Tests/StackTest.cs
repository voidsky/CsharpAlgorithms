using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Algorithms
{
	[TestFixture]
    public class StackTest
    {
		[Test]
		public void TestPushAndPop()
        {
            Stack<int> stack = new Stack<int>();
            Assert.AreEqual(true, stack.IsEmpty());
            stack.Push(6);
            Assert.AreEqual(1, stack.Size());
            stack.Push(7);
            Assert.AreEqual(2, stack.Size());
            stack.Push(8);
            Assert.AreEqual(3, stack.Size());

            int shouldBe = 8;
            foreach (int i in stack)
            {
                Assert.AreEqual(shouldBe, i);
                shouldBe--;
            }

            int item;
            item = stack.Pop();
            Assert.AreEqual(2, stack.Size());
            Assert.AreEqual(8, item);

            item = stack.Pop();
            Assert.AreEqual(1, stack.Size());
            Assert.AreEqual(7, item);

            item = stack.Pop();
            Assert.AreEqual(0, stack.Size());
            Assert.AreEqual(6, item);

        }
    }
}
