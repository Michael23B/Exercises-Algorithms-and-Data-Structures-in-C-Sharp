using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeQuestionsSharp.DataStructures;

namespace UnitTests
{
    [TestClass]
    public class QueueTests
    {
        [TestMethod]
        public void CanCreateNewQueueValueType()
        {
            //Arrange
            Queue<int> queue = new Queue<int>();

            //Act
            
            //Assert
            Assert.IsNotNull(queue);
        }

        [TestMethod]
        public void CanCreateNewQueueReferenceType()
        {
            //Arrange
            Queue<DummyClass> queue = new Queue<DummyClass>();

            //Act

            //Assert
            Assert.IsNotNull(queue);
        }

        [TestMethod]
        public void EnqueueCorrectlyAddsItem()
        {
            //Arrange
            Queue<int> queueValueType = new Queue<int>();
            Queue<DummyClass> queueReferenceType = new Queue<DummyClass>();

            //Act
            queueValueType.Enqueue(3);
            queueReferenceType.Enqueue(new DummyClass());

            //Assert
            Assert.AreEqual(3, queueValueType.Peek());
            Assert.AreEqual("method", queueReferenceType.Peek().DummyMethod());
        }

        [TestMethod]
        public void DequeueCorrectlyRemovesItem()
        {
            //Arrange
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(3).Enqueue(4).Enqueue(5);

            //Act
            int dequeued1 = queue.Dequeue();
            int dequeued2 = queue.Dequeue();

            //Assert
            Assert.AreEqual(3, dequeued1);
            Assert.AreEqual(4, dequeued2);
            Assert.AreEqual(5, queue.Peek());
        }

        [TestMethod]
        public void DequeueFromEmptyQueueThrowsException()
        {
            //Arrange
            Queue<int> queue = new Queue<int>();

            //Act

            //Assert
            Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue());
        }

        [TestMethod]
        public void PeekReturnsCorrectItem()
        {
            //Arrange
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(3).Enqueue(2);

            //Act

            //Assert
            Assert.AreEqual(3, queue.Peek());
        }

        [TestMethod]
        public void EmptyIsCorrect()
        {
            //Arrange
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(3);

            //Act
            bool notEmpty = queue.IsEmpty;
            queue.Dequeue();
            bool empty = queue.IsEmpty;

            //Assert
            Assert.AreEqual(false, notEmpty);
            Assert.AreEqual(true, empty);
        }

        [TestMethod]
        public void ClearEmptiesQueue()
        {
            //Arrange
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(3).Enqueue(2);

            //Act
            queue.Clear();

            //Assert
            Assert.AreEqual(true, queue.IsEmpty);
        }

        [TestMethod]
        public void CountIsCorrect()
        {
            //Arrange
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(3).Enqueue(2);

            //Act
            int queueCount2 = queue.Count;
            int queueCount3 = queue.Enqueue(1).Count;
            queue.Clear();

            //Assert
            Assert.AreEqual(2, queueCount2);
            Assert.AreEqual(3, queueCount3);
            Assert.AreEqual(0, queue.Count);
        }
    }
}
