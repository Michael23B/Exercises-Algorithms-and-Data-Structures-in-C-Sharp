using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeQuestionsSharp.DataStructures;
using PracticeQuestionsSharp.Exercises.Stack;

namespace UnitTests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void CanCreateNewStackValueType()
        {
            //Arrange
            Stack<int> stack = new Stack<int>();

            //Act
            
            //Assert
            Assert.IsNotNull(stack);
        }

        [TestMethod]
        public void CanCreateNewStackReferenceType()
        {
            //Arrange
            Stack<DummyClass> stack = new Stack<DummyClass>();

            //Act

            //Assert
            Assert.IsNotNull(stack);
        }

        [TestMethod]
        public void PushOntoStackCorrectlyAddsItem()
        {
            //Arrange
            Stack<int> stackValueType = new Stack<int>();
            Stack<DummyClass> stackReferenceType = new Stack<DummyClass>();

            //Act
            stackValueType.Push(3);
            stackReferenceType.Push(new DummyClass());

            //Assert
            Assert.AreEqual(3, stackValueType.Peek());
            Assert.AreEqual("method", stackReferenceType.Peek().DummyMethod());
        }

        [TestMethod]
        public void PopFromStackCorrectlyRemovesItem()
        {
            //Arrange
            Stack<int> stack = new Stack<int>();
            stack.Push(3).Push(4).Push(5);

            //Act
            int stackPop1 = stack.Pop();
            int stackPop2 = stack.Pop();

            //Assert
            Assert.AreEqual(5, stackPop1);
            Assert.AreEqual(4, stackPop2);
            Assert.AreEqual(3, stack.Peek());
        }

        [TestMethod]
        public void PopFromEmptyStackThrowsException()
        {
            //Arrange
            Stack<int> stack = new Stack<int>();

            //Act

            //Assert
            Assert.ThrowsException<InvalidOperationException>(() => stack.Pop());
        }

        [TestMethod]
        public void PeekReturnsCorrectItem()
        {
            //Arrange
            Stack<int> stack = new Stack<int>();
            stack.Push(3).Push(2);

            //Act

            //Assert
            Assert.AreEqual(2, stack.Peek());
        }

        [TestMethod]
        public void EmptyIsCorrect()
        {
            //Arrange
            Stack<int> stack = new Stack<int>();
            stack.Push(3);

            //Act
            bool notEmpty = stack.IsEmpty;
            stack.Pop();
            bool empty = stack.IsEmpty;

            //Assert
            Assert.AreEqual(false, notEmpty);
            Assert.AreEqual(true, empty);
        }

        [TestMethod]
        public void ClearEmptiesStack()
        {
            //Arrange
            Stack<int> stack = new Stack<int>();
            stack.Push(3).Push(2);

            //Act
            stack.Clear();

            //Assert
            Assert.AreEqual(true, stack.IsEmpty);
        }

        [TestMethod]
        public void CountIsCorrect()
        {
            //Arrange
            Stack<int> stack = new Stack<int>();
            stack.Push(3).Push(2);

            //Act
            int stackCount2 = stack.Count;
            int stackCount3 = stack.Push(1).Count;
            stack.Clear();

            //Assert
            Assert.AreEqual(2, stackCount2);
            Assert.AreEqual(3, stackCount3);
            Assert.AreEqual(0, stack.Count);
        }
    }

    [TestClass]
    public class StackExtensionTests
    {
        [TestMethod]
        public void CanSortInts()
        {
            //Arrange
            Stack<int> stackToSort = new Stack<int>();
            for (int i = 150; i >= 0; --i)
            {
                stackToSort.Push(i);
            }

            //Act
            stackToSort.Sort();

            //Assert
            int prev = stackToSort.Pop();

            while (!stackToSort.IsEmpty)
            {
                Assert.IsTrue(prev.CompareTo(stackToSort.Peek()) < 1);
                prev = stackToSort.Pop();
            }
        }

        [TestMethod]
        public void CanSortStrings()
        {
            //Arrange
            Stack<string> stackToSort = new Stack<string>();
            for (int i = 150; i >= 0; --i)
            {
                stackToSort.Push(i.ToString());
            }

            //Act
            stackToSort.Sort();

            //Assert
            string prev = stackToSort.Pop();

            while (!stackToSort.IsEmpty)
            {
                Assert.IsTrue(prev.CompareTo(stackToSort.Peek()) < 1);
                prev = stackToSort.Pop();
            }
        }
    }
}
