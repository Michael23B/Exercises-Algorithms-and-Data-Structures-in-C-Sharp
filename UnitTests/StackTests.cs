using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeQuestionsSharp.DataStructures;

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
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

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
            stack.Push(3);

            //Act

            //Assert
            Assert.AreEqual(3, stack.Peek());
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
    }
}
