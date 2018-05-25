using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeQuestionsSharp.DataStructures;

namespace UnitTests
{
    [TestClass]
    public class HeapTests
    {
        [TestMethod]
        public void CanCreateNewHeapValueType()
        {
            //Arrange
            MinHeap<int> heap = new MinHeap<int>();

            //Act
            
            //Assert
            Assert.IsNotNull(heap);
        }

        [TestMethod]
        public void CanCreateNewHeapReferenceType()
        {
            //Arrange
            var heap = new MinHeap<DummyComparableClass>();

            //Act

            //Assert
            Assert.IsNotNull(heap);
        }

        [TestMethod]
        public void InsertCorrectlyAddsItem()
        {
            //Arrange
            MinHeap<int> heap = new MinHeap<int>();

            //Act
            heap.Insert(3);

            //Assert
            Assert.AreEqual(3, heap.Peek());
        }

        [TestMethod]
        public void InsertCorrectlyAddsItems()
        {
            //Arrange
            MinHeap<int> heap = new MinHeap<int>();

            //Act
            heap.Insert(3).Insert(4).Insert(2);

            //Assert
            using (var heapEnumerator = heap.GetEnumerator())
            {
                heapEnumerator.MoveNext();
                Assert.AreEqual(2, heapEnumerator.Current);
                heapEnumerator.MoveNext();
                Assert.AreEqual(4, heapEnumerator.Current);
                heapEnumerator.MoveNext();
                Assert.AreEqual(3, heapEnumerator.Current);
            }
        }

        [TestMethod]
        public void ExtractFromEmptyHeapCorrectlyThrowsException()
        {
            //Arrange
            MinHeap<int> heap = new MinHeap<int>();

            //Act

            //Assert
            Assert.ThrowsException<InvalidOperationException>(() => heap.ExtractMin());
        }

        [TestMethod]
        public void PeekReturnsCorrectItem()
        {
            //Arrange
            MinHeap<int> heap = new MinHeap<int>();
            MinHeap<int> heap2 = new MinHeap<int>();

            //Act
            heap.Insert(3);
            heap2.Insert(3).Insert(1);

            //Assert
            Assert.AreEqual(3, heap.Peek());
            Assert.AreEqual(1, heap2.Peek());
        }

        [TestMethod]
        public void PeekOnEmptyHeapThrowsException()
        {
            //Arrange
            MinHeap<int> heap = new MinHeap<int>();

            //Act

            //Assert
            Assert.ThrowsException<InvalidOperationException>(() => heap.Peek());
        }
    }
}
