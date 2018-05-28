using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeQuestionsSharp.DataStructures;

namespace UnitTests
{
    [TestClass]
    public class AVLTreeTests
    {
        [TestMethod]
        public void CanCreateNewTree()
        {
            //Arange
            var treeVal = new AVLTree<int>();
            var treeRef = new AVLTree<DummyComparableClass>();

            //Act


            //Assert
            Assert.IsNotNull(treeVal);
            Assert.IsNotNull(treeRef);
        }

        [TestMethod]
        public void CanInsert()
        {
            //Arange
            var tree = new AVLTree<int>();

            //Act
            tree.Insert(3);

            //Assert
            Assert.AreEqual(true, tree.Find(3));
            Assert.AreEqual(false, tree.IsEmpty);
        }

        [TestMethod]
        public void FindReturnsCorrectly()
        {
            //Arange
            var tree = new AVLTree<int>();

            //Act
            tree.Insert(3).Insert(5).Insert(10);

            //Assert
            Assert.AreEqual(true, tree.Find(3));
            Assert.AreEqual(true, tree.Find(5));
            Assert.AreEqual(true, tree.Find(10));
            Assert.AreEqual(false, tree.Find(4));
            Assert.AreEqual(false, tree.Find(100));
            Assert.AreEqual(false, tree.Find(-1));
            Assert.AreEqual(false, tree.IsEmpty);
        }

        [TestMethod]
        public void CanRemoveCorrectItem()
        {
            //Arange
            var tree = new AVLTree<int>();

            //Act
            tree.Insert(3).Insert(5).Insert(10).Insert(0);
            tree.Remove(5);
            tree.Remove(10);

            //Assert
            Assert.IsFalse(tree.Find(5));
            Assert.IsTrue(tree.Find(3));
            Assert.IsFalse(tree.Find(10));
            Assert.IsTrue(tree.Find(0));
        }

        [TestMethod]
        public void TreeIsCorrectlyOrdered()
        {
            //Arange
            var tree = new AVLTree<int>();
            List<int> orderedList;
            int prev;

            //Act
            tree.Insert(3).Insert(5).Insert(10).Insert(-3).Insert(20)
                .Insert(120).Insert(13).Insert(55).Insert(6).Insert(105);

            orderedList = tree.GetOrderedList();

            //Assert
            prev = orderedList[0];
            foreach (int i in orderedList)
            {
                Assert.IsTrue(prev <= i);
                prev = i;
            }
        }

        [TestMethod]
        public void TreeIsCorrectlyOrderedAfterRemoval()
        {
            //Arange
            var tree = new AVLTree<int>();
            List<int> orderedList;
            int prev;

            //Act
            tree.Insert(3).Insert(5).Insert(10).Insert(-3).Insert(20)
                .Insert(120).Insert(13).Insert(55).Insert(6).Insert(105);

            tree.Remove(13);
            tree.Remove(105);
            tree.Remove(-3);
            tree.Remove(20);

            orderedList = tree.GetOrderedList();

            //Assert
            prev = orderedList[0];
            foreach (int i in orderedList)
            {
                Assert.IsTrue(prev <= i);
                prev = i;
            }
        }
    }
}
