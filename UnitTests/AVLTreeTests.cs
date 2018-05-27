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
    }
}
