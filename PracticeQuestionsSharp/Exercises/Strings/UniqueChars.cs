using System.Collections.Generic;
using PracticeQuestionsSharp.Helper;

namespace PracticeQuestionsSharp.Exercises.Strings
{
    //Check if a string is made of distinct characters.
    public static class UniqueChars
    {
        public static bool IsUnique(string s)
        {
            Dictionary<char, char> dict = new Dictionary<char, char>();

            foreach (char c in s)
            {
                if (!dict.TryAdd(c, c)) return false;
            }

            return true;
        }

        //Using no data structures
        public static bool IsUnique2(string s)
        {
            s = s.SortString();

            for (int i = 0; i < s.Length - 1; ++i)
            {
                if (s[i] == s[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}