using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Algorithms
{
	[TestFixture]
    public class QueueTest
    {
		[Test]
		public void TestEnqueueDequeue()
        {
            Queue<int> queue = new Queue<int>();
            Assert.AreEqual(true, queue.IsEmpty());
            queue.Enqueue(6);
            Assert.AreEqual(1, queue.Size());
            queue.Enqueue(7);
            Assert.AreEqual(2, queue.Size());
            queue.Enqueue(8);
            Assert.AreEqual(3, queue.Size());

            int shouldBe = 6;
            foreach (int i in queue)
            {
                Assert.AreEqual(shouldBe, i);
                shouldBe++;
            }

            int item;
            item = queue.Dequeue();
            Assert.AreEqual(2, queue.Size());
            Assert.AreEqual(6, item);

            item = queue.Dequeue();
            Assert.AreEqual(1, queue.Size());
            Assert.AreEqual(7, item);

            item = queue.Dequeue();
            Assert.AreEqual(0, queue.Size());
            Assert.AreEqual(8, item);
        }
    }
}
