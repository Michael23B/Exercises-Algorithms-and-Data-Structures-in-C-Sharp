using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeQuestionsSharp.DataStructures;

namespace UnitTests
{
    //Unit tests for heap.
    [TestClass]
    public class HeapTests
    {
        [TestMethod]
        public void CanCreateNewHeapValueType()
        {
            MinHeap<int> heap = new MinHeap<int>();

            Assert.IsNotNull(heap);
        }

        [TestMethod]
        public void CanCreateNewHeapReferenceType()
        {
            var heap = new MinHeap<DummyComparableClass>();

            Assert.IsNotNull(heap);
        }

        [TestMethod]
        public void InsertCorrectlyAddsItem()
        {
            MinHeap<int> heap = new MinHeap<int>();

            heap.Insert(3).Insert(5);

            Assert.AreEqual(3, heap.Peek());
        }

        [TestMethod]
        public void InsertCorrectlyAddsItems()
        {
            MinHeap<int> heap = new MinHeap<int>();

            heap.Insert(3).Insert(4).Insert(2);

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
            MinHeap<int> heap = new MinHeap<int>();

            Assert.ThrowsException<InvalidOperationException>(() => heap.ExtractMin());
        }

        [TestMethod]
        public void ExtractFromHeapReturnsCorrectItem()
        {
            MinHeap<int> heap = new MinHeap<int>();

            heap.Insert(5).Insert(10).Insert(0).Insert(20);

            Assert.AreEqual(0, heap.ExtractMin());
            Assert.AreEqual(5, heap.ExtractMin());
            Assert.AreEqual(10, heap.ExtractMin());
            Assert.AreEqual(20, heap.ExtractMin());
        }

        [TestMethod]
        public void PeekReturnsCorrectItem()
        {
            MinHeap<int> heap = new MinHeap<int>();
            MinHeap<int> heap2 = new MinHeap<int>();

            heap.Insert(3);
            heap2.Insert(3).Insert(1);

            Assert.AreEqual(3, heap.Peek());
            Assert.AreEqual(1, heap2.Peek());
        }

        [TestMethod]
        public void PeekOnEmptyHeapThrowsException()
        {
            MinHeap<int> heap = new MinHeap<int>();

            Assert.ThrowsException<InvalidOperationException>(() => heap.Peek());
        }
    }
}
