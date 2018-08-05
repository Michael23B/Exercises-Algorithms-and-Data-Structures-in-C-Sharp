using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeQuestionsSharp.DataStructures;

namespace UnitTests
{
    //Unit tests for queue.
    [TestClass]
    public class QueueTests
    {
        [TestMethod]
        public void CanCreateNewQueueValueType()
        {
            Queue<int> queue = new Queue<int>();

            Assert.IsNotNull(queue);
        }

        [TestMethod]
        public void CanCreateNewQueueReferenceType()
        {
            Queue<DummyClass> queue = new Queue<DummyClass>();

            Assert.IsNotNull(queue);
        }

        [TestMethod]
        public void EnqueueCorrectlyAddsItem()
        {
            Queue<int> queueValueType = new Queue<int>();
            Queue<DummyClass> queueReferenceType = new Queue<DummyClass>();

            queueValueType.Enqueue(3);
            queueReferenceType.Enqueue(new DummyClass());

            Assert.AreEqual(3, queueValueType.Peek());
            Assert.AreEqual("method", queueReferenceType.Peek().DummyMethod());
        }

        [TestMethod]
        public void DequeueCorrectlyRemovesItem()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(3).Enqueue(4).Enqueue(5);

            int dequeued1 = queue.Dequeue();
            int dequeued2 = queue.Dequeue();

            Assert.AreEqual(3, dequeued1);
            Assert.AreEqual(4, dequeued2);
            Assert.AreEqual(5, queue.Peek());
        }

        [TestMethod]
        public void DequeueFromEmptyQueueThrowsException()
        {
            Queue<int> queue = new Queue<int>();

            Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue());
        }

        [TestMethod]
        public void PeekReturnsCorrectItem()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(3).Enqueue(2);

            Assert.AreEqual(3, queue.Peek());
        }

        [TestMethod]
        public void EmptyIsCorrect()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(3);

            bool notEmpty = queue.IsEmpty;
            queue.Dequeue();
            bool empty = queue.IsEmpty;

            Assert.AreEqual(false, notEmpty);
            Assert.AreEqual(true, empty);
        }

        [TestMethod]
        public void ClearEmptiesQueue()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(3).Enqueue(2);

            queue.Clear();

            Assert.AreEqual(true, queue.IsEmpty);
        }

        [TestMethod]
        public void CountIsCorrect()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(3).Enqueue(2);

            int queueCount2 = queue.Count;
            int queueCount3 = queue.Enqueue(1).Count;
            queue.Clear();

            Assert.AreEqual(2, queueCount2);
            Assert.AreEqual(3, queueCount3);
            Assert.AreEqual(0, queue.Count);
        }
    }
}
