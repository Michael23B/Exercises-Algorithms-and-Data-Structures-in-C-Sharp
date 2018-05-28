using PracticeQuestionsSharp.Helper;

namespace PracticeQuestionsSharp.Exercises.Strings
{
    public static class PalindromePermutation
    {
        //Determine whether a string is a permutation of a palindrom
        public static bool IsPalindromePermutation(string s)
        {
            int singleCharCount = 0;
            s = s.SortString().ToLower();

            for (int i = 0; i < s.Length; ++i)
            {
                if (i + 1 >= s.Length) break;

                if (s[i] == s[i + 1]) i++;    //we can ignore the next character because it has a pair
                else
                {
                    singleCharCount++;
                    if (singleCharCount > 0 && s.Length % 2 == 0) return false; //cannot have unpaired character in an even length palindrome
                    if (singleCharCount > 1 && s.Length % 2 == 1) return false; //odd length palindromes have a single unpaired character
                }
            }

            return true;
        }
    }
}