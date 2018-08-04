using System;
using System.Linq;

namespace PracticeQuestionsSharp.Helper
{
    //A couple of extension methods I've used throughout the project.
    public static class ExtensionMethods
    {
        public static string SortString(this string s)
        {
            char[] chars = s.ToArray();
            Array.Sort(chars);
            return new string(chars);
        }

        //Overflows after 10
        public static int Factorial(int n)
        {
            if (n < 0) return -1;
            if (n == 0 || n == 1) return 1;

            return n * Factorial(n - 1);
        }
    }
}