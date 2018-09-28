using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Algorithms
{
	[TestFixture]
    public class ResizingArrayStackTest
    {
		[Test]
		public void TestPushAndPop()
        {
            ResizingArrayStack<int> stack = new ResizingArrayStack<int>();
            Assert.AreEqual(true, stack.IsEmpty());
            stack.Push(6);
            Assert.AreEqual(1, stack.Size());
            stack.Push(7);
            Assert.AreEqual(2, stack.Size());
            stack.Push(8);
            Assert.AreEqual(3, stack.Size());

            int shouldBe = 8;
            foreach (int item in stack)
            {
                Assert.AreEqual(shouldBe, item);
                shouldBe--;
            }

            stack.Pop();
            Assert.AreEqual(2, stack.Size());
            stack.Pop();
            Assert.AreEqual(1, stack.Size());
            stack.Pop();
            Assert.AreEqual(0, stack.Size());
        }
    }
}
