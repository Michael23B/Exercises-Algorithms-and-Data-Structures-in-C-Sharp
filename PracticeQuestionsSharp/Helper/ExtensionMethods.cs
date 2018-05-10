using System;
using System.Linq;

namespace PracticeQuestionsSharp.Helper
{
    public static class ExtensionMethods
    {
        public static string SortString(this string s)
        {
            char[] chars = s.ToArray();
            Array.Sort(chars);
            return new string(chars);
        }
    }
}