using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeQuestionsSharp.DataStructures;
using PracticeQuestionsSharp.Exercises;

namespace UnitTests
{
    class DummyClass
    {
        public DummyClass()
        {
            dummyData = "data";
        }

        public string DummyMethod()
        {
            return "method";
        }

        public string dummyData;
    }

    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void CreateNewList()
        {
            //Arrange
            LinkedList<int> list = new LinkedList<int>();

            //Act

            //Assert
            Assert.IsNotNull(list);
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
        }

        [TestMethod]
        public void ListCanBeCreatedWithValueTypes()
        {
            //Arrange
            LinkedList<int> intList = new LinkedList<int>(3);
            LinkedList<string> stringList = new LinkedList<string>("Test123");
            LinkedList<char> charList = new LinkedList<char>('c');
            LinkedList<double> doubleList = new LinkedList<double>(25d);

            //Act

            //Assert
            Assert.AreEqual(3, intList.Head.Data);
            Assert.AreEqual("Test123", stringList.Head.Data);
            Assert.AreEqual('c', charList.Head.Data);
            Assert.AreEqual(25d, doubleList.Head.Data);
        }

        [TestMethod]
        public void ListCanBeCreatedWithReferenceTypes()
        {
            //Arrange
            DummyClass dummy = new DummyClass();
            LinkedList<int> intList = new LinkedList<int>(5);

            LinkedList<DummyClass> dummyList = new LinkedList<DummyClass>(dummy);
            LinkedList<LinkedList<int>> linkedListList = new LinkedList<LinkedList<int>>(intList);

            //Act

            //Assert
            Assert.AreEqual("data", dummyList.Head.Data.dummyData);
            Assert.AreEqual("method", dummyList.Head.Data.DummyMethod());
            Assert.AreEqual(5, linkedListList.Head.Data.Head.Data);
        }

        [TestMethod]
        public void ListCountWithOneOrZeroItems()
        {
            //Arrange
            LinkedList<int> list1Item = new LinkedList<int>(1);
            LinkedList<int> list0Items = new LinkedList<int>();

            //Act

            //Assert
            Assert.AreEqual(1, list1Item.Count());
            Assert.AreEqual(0, list0Items.Count());
        }

        [TestMethod]
        public void ListCountWithPredicate()
        {
            //Arrange
            LinkedList<int> list = new LinkedList<int>(1);

            //Act
            list.Add(3);
            list.Add(5);
            list.Add(8);
            list.Add(12);

            //Assert
            Assert.AreEqual(2, list.Count(x => x % 2 == 0));
            Assert.AreEqual(3, list.Count(x => x % 2 == 1));
            Assert.AreEqual(2, list.Count(x => x < 5));
        }

        [TestMethod]
        public void AddNewNodeWithData()
        {
            //Arrange
            LinkedList<int> list = new LinkedList<int>();

            //Act
            list.Add(1);
            list.Add(2);
            list.Add(3);

            //Assert
            Assert.AreEqual(1, list.Head.Data);
            Assert.AreEqual(2, list.Head.Next.Data);
            Assert.AreEqual(3, list.Tail.Data);
            Assert.AreEqual(3, list.Count());
        }

        [TestMethod]
        public void AddLotsOfNewNodesByData()
        {
            //Arrange
            LinkedList<int> list = new LinkedList<int>();

            //Act
            for (int i = 0; i < 1000000; ++i) list.Add(i);

            //Assert
            Assert.AreEqual(0, list.Head.Data);
            Assert.AreEqual(1, list.Head.Next.Data);
            Assert.AreEqual(999999, list.Tail.Data);
            Assert.AreEqual(999998, list.Tail.Prev.Data);
            Assert.AreEqual(1000000, list.Count());
        }

        [TestMethod]
        public void AddNewNodeBeforeWithDataByIndex()
        {
            //Arrange
            LinkedList<int> list = new LinkedList<int>();

            //Act
            list.Add(1);
            list.AddBefore(2, 0);
            list.AddBefore(3, 1);

            //Assert
            Assert.AreEqual(2, list.Head.Data);
            Assert.AreEqual(3, list.Head.Next.Data);
            Assert.AreEqual(1, list.Tail.Data);
            Assert.AreEqual(3, list.Count());
        }

        [TestMethod]
        public void AddNewNodeBeforeWithDataByNode()
        {
            //Arrange
            LinkedList<int> list = new LinkedList<int>();

            //Act
            Node<int> node1 = list.Add(1);
            Node<int> node2 = list.AddBefore(2, node1);
            list.AddBefore(3, node2);

            //Assert
            Assert.AreEqual(3, list.Head.Data);
            Assert.AreEqual(2, list.Head.Next.Data);
            Assert.AreEqual(1, list.Tail.Data);
            Assert.AreEqual(3, list.Count());
        }

        [TestMethod]
        public void AddNewNodeAfterWithDataByIndex()
        {
            //Arrange
            LinkedList<int> list = new LinkedList<int>();

            //Act
            list.Add(1);
            list.AddAfter(2, 0);
            list.AddAfter(3, 0);

            //Assert
            Assert.AreEqual(1, list.Head.Data);
            Assert.AreEqual(3, list.Head.Next.Data);
            Assert.AreEqual(2, list.Tail.Data);
            Assert.AreEqual(3, list.Count());
        }

        [TestMethod]
        public void AddNewNodeAfterWithDataByNode()
        {
            //Arrange
            LinkedList<int> list = new LinkedList<int>();

            //Act
            Node<int> node1 = list.Add(1);
            Node<int> node2 = list.AddAfter(2, node1);
            list.AddAfter(3, node2);

            //Assert
            Assert.AreEqual(1, list.Head.Data);
            Assert.AreEqual(2, list.Head.Next.Data);
            Assert.AreEqual(3, list.Tail.Data);
            Assert.AreEqual(3, list.Count());
        }

        [TestMethod]
        public void AddingWithNullNodes()
        {
            //Arrange
            LinkedList<int> list = new LinkedList<int>();

            //Act
            list.Add(1);
            list.AddAfter(2, null);
            list.AddBefore(3, null);

            //Assert
            Assert.AreEqual(1, list.Head.Data);
            Assert.AreEqual(1, list.Tail.Data);
            Assert.AreEqual(1, list.Count());
        }

        [TestMethod]
        public void RemoveNodeByData()
        {
            //Arrange
            LinkedList<int> list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            //Act
            list.Remove(2);

            //Assert
            Assert.AreEqual(1, list.Head.Data);
            Assert.AreEqual(3, list.Tail.Data);
            Assert.AreEqual(3, list.Head.Next.Data);
            Assert.AreEqual(1, list.Tail.Prev.Data);
            Assert.AreEqual(2, list.Count());
        }

        [TestMethod]
        public void RemoveNodeByNode()
        {
            //Arrange
            LinkedList<int> list = new LinkedList<int>();
            list.Add(1);
            Node<int> nodeToRemove = list.Add(2);
            list.Add(3);

            //Act
            list.RemoveNode(nodeToRemove);

            //Assert
            Assert.AreEqual(1, list.Head.Data);
            Assert.AreEqual(3, list.Tail.Data);
            Assert.AreEqual(3, list.Head.Next.Data);
            Assert.AreEqual(1, list.Tail.Prev.Data);
            Assert.AreEqual(2, list.Count());
        }

        [TestMethod]
        public void RemoveNodeByDataUntilNull()
        {
            //Arrange
            LinkedList<int> list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            //Act
            list.Remove(1);
            list.Remove(2);
            list.Remove(3);

            //Assert
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
            Assert.AreEqual(0, list.Count());
        }

        [TestMethod]
        public void RemoveNodeByNodeUntilNull()
        {
            //Arrange
            LinkedList<int> list = new LinkedList<int>();
            Node<int> nodeToRemove1 = list.Add(1);
            Node<int> nodeToRemove2 = list.Add(2);
            Node<int> nodeToRemove3 = list.Add(3);

            //Act
            list.RemoveNode(nodeToRemove1);
            list.RemoveNode(nodeToRemove2);
            list.RemoveNode(nodeToRemove3);

            //Assert
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
            Assert.AreEqual(0, list.Count());
        }

        [TestMethod]
        public void RemoveFromEmptyListDoesntCrash()
        {
            //Arrange
            LinkedList<int> list = new LinkedList<int>();

            //Act
            list.Remove(0);
            list.RemoveNode(new Node<int>());

            //Assert
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
            Assert.AreEqual(0, list.Count());
        }

        [TestMethod]
        public void NodeAtIndexReturnsCorrectNode()
        {
            //Arrange
            LinkedList<int> list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            //Act
            Node<int> nodeAt0 = list.At(0);
            Node<int> nodeAt1 = list.At(1);
            Node<int> nodeAt2 = list.At(2);

            //Assert
            Assert.AreEqual(1, nodeAt0.Data);
            Assert.AreEqual(2, nodeAt1.Data);
            Assert.AreEqual(3, nodeAt2.Data);
            Assert.AreEqual(nodeAt0, nodeAt1.Prev);
            Assert.AreEqual(nodeAt2, nodeAt1.Next);
            Assert.IsNull(nodeAt0.Prev);
            Assert.IsNull(nodeAt2.Next);
        }

        [TestMethod]
        public void FindByDataReturnsCorrectNode()
        {
            //Arrange
            LinkedList<int> list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            //Act
            Node<int> nodeFind0 = list.Find(0);
            Node<int> nodeFind1 = list.Find(1);
            Node<int> nodeFind2 = list.Find(2);
            Node<int> nodeFind3 = list.Find(3);

            //Assert
            Assert.AreEqual(1, nodeFind1.Data);
            Assert.AreEqual(2, nodeFind2.Data);
            Assert.AreEqual(3, nodeFind3.Data);
            Assert.AreEqual(nodeFind1, nodeFind2.Prev);
            Assert.AreEqual(nodeFind3, nodeFind2.Next);
            Assert.IsNull(nodeFind1.Prev);
            Assert.IsNull(nodeFind3.Next);
            Assert.IsNull(nodeFind0);
        }

        [TestMethod]
        public void FindAllReturnsCorrectNodes()
        {
            //Arrange
            LinkedList<int> list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            //Act
            var resultsGreaterThanOne = list.FindAll(x => x > 1);
            var resultsEqual1 = list.FindAll(x => x == 1);
            var resultsLessThanZero = list.FindAll(x => x < 0);
            var resultsAll = list.FindAll();

            //Assert
            Assert.AreEqual(2, resultsGreaterThanOne[0].Data);
            Assert.AreEqual(3, resultsGreaterThanOne[1].Data);
            Assert.AreEqual(2, resultsGreaterThanOne.Count);
            Assert.AreEqual(1, resultsEqual1[0].Data);
            Assert.AreEqual(1, resultsEqual1.Count);
            Assert.AreEqual(3, resultsAll.Count);
            Assert.AreEqual(0, resultsLessThanZero.Count);
        }

        [TestMethod]
        public void ClearList()
        {
            //Arrange
            LinkedList<int> list = new LinkedList<int>();
            list.Add(1);
            list.AddBefore(2, 0);
            list.AddAfter(3, 1);

            //Act
            list.Clear();

            //Assert
            Assert.AreEqual(0, list.Count());
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
        }

        [TestMethod]
        public void NestedAddingToList()
        {
            //Arrange
            LinkedList<int> list = new LinkedList<int>();

            //Act
            list.Add(1);
            list.Add(2);
            list.AddBefore(3, list.AddBefore(4, list.AddAfter(5, list.Find(2))));

            //Assert
            Assert.AreEqual(5, list.Count());
            Assert.AreEqual(1, list.Head.Data);
            Assert.AreEqual(2, list.Head.Next.Data);
            Assert.AreEqual(3, list.Head.Next.Next.Data);
            Assert.AreEqual(4, list.Head.Next.Next.Next.Data);
            Assert.AreEqual(5, list.Head.Next.Next.Next.Next.Data);
            Assert.AreEqual(list.Tail, list.Head.Next.Next.Next.Next);
        }
    }

    [TestClass]
    public class LinkedListExtensionTests
    {
        [TestMethod]
        public void LinkedListSumsCorrectly()
        {
            //Arrange
            LinkedList<int> listLeft = new LinkedList<int>();
            LinkedList<int> listRight = new LinkedList<int>();
            listLeft.Add(8);
            listLeft.Add(5);
            listLeft.Add(6);
            listRight.Add(1);
            listRight.Add(7);
            listRight.Add(4);

            //Act
            var summedLists = LinkedListsSum.SumLists(listLeft, listRight);

            //Assert
            //658 + 471 = 1129
            Assert.AreEqual(4, summedLists.Count());
            Assert.AreEqual(9, summedLists.Head.Data);
            Assert.AreEqual(2, summedLists.Head.Next.Data);
            Assert.AreEqual(1, summedLists.Head.Next.Next.Data);
            Assert.AreEqual(1, summedLists.Head.Next.Next.Next.Data);
        }

        [TestMethod]
        public void LinkedListRemoveDuplicatesCorrectly()
        {
            //Arrange
            LinkedList<int> list = new LinkedList<int>();
            list.Add(1);
            list.Add(1);
            list.Add(3);
            list.Add(5);
            list.Add(8);
            list.Add(4);
            list.Add(3);
            list.Add(5);

            //Act
            list.RemoveDuplicates();

            //Assert
            Assert.AreEqual(5, list.Count());
            Assert.AreEqual(1, list.Head.Data);
            Assert.AreEqual(3, list.Head.Next.Data);
            Assert.AreEqual(5, list.Head.Next.Next.Data);
            Assert.AreEqual(8, list.Head.Next.Next.Next.Data);
            Assert.AreEqual(4, list.Head.Next.Next.Next.Next.Data);
        }

        [TestMethod]
        public void DetectLoop()
        {
            //Arrange
            LinkedList<int> circularList = new LinkedList<int>(1);
            circularList.Add(2);
            circularList.Add(3);
            circularList.Add(4);
            circularList.Add(5);

            circularList.Tail.Next = circularList.Tail.Prev.Prev;

            //Act
            Node<int> loopingNode = circularList.DetectLoop();

            //Assert
            Assert.AreEqual(5, loopingNode.Data);
        }
    }
}