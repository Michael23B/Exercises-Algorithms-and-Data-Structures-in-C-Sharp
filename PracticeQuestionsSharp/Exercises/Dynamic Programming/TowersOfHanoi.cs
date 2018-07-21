using PracticeQuestionsSharp.DataStructures;
using System;

namespace PracticeQuestionsSharp.Exercises.Dynamic_Programming
{
    public static class TowersOfHanoi
    {
        public static void TowersOfHanoiRecursive(int height)
        {
            var s1 = new Stack<int>();
            var s2 = new Stack<int>();
            var s3 = new Stack<int>();

            for (int i = 1; i <= height; ++i) s1.Push(i);

            ShiftDiscs(height, s1, s2, s3);

            Console.WriteLine("--Source--");
            s1.Print();
            Console.WriteLine("--Spare--");
            s2.Print();
            Console.WriteLine("--Target--");
            s3.Print();
        }

        private static void ShiftDiscs(int n, Stack<int> source, Stack<int> spare, Stack<int> target)
        {
            if (n == 0) return;

            ShiftDiscs(n - 1, source, target, spare);

            PlaceDiscOnTarget(source, target);

            ShiftDiscs(n - 1, spare, source, target);
        }

        private static void PlaceDiscOnTarget(Stack<int> source, Stack<int> target)
        {
            target.Push(source.Pop());
        }
    }
}
