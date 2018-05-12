using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeQuestionsSharp.DataStructures;

namespace UnitTests
{
    class DummyClass
    {
        public DummyClass() { dummyData = "data"; }
        public string DummyMethod() { return "method"; }

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
        public void AddNewNodeWithLotsOfData()
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
    }
}
