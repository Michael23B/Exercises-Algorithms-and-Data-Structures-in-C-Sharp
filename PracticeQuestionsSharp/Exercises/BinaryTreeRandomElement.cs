using System;
using PracticeQuestionsSharp.DataStructures;

namespace PracticeQuestionsSharp.Exercises
{
    public class BinaryTreeRandomElement<T> : BinarySearchTree<T> where T : IComparable
    {
        public new BinarySearchTree<T> Insert(T data)
        {
            Count++;
            return base.Insert(data);
        }

        public new void Remove(T data)
        {
            Count--;
            base.Remove(data);
        }

        public T GetRandom()
        {
            Random r = new Random();
            return TraverseToIndex(r.Next(Count + 1));
            //Remove here?
        }

        public int Count { get; set; }
    }
}
