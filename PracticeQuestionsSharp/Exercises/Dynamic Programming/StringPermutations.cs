using System.Collections.Generic;

namespace PracticeQuestionsSharp.Exercises.Dynamic_Programming
{
    public static class StringPermutations
    {
        //Compute all permutations of a string of unique characters
        public static List<string> DistinctStringPermutations(this string str)
        {
            List<string> permutations = new List<string>();
            permutations.Add("");

            return AddPermutations(permutations, str);
        }

        private static List<string> AddPermutations(List<string> permutations, string str)
        {
            if (str.Length == 0) return permutations;

            List<string> newPermutations = new List<string>();

            foreach (string s in permutations)
            {
                if (s.Length > 0) newPermutations.Add(str[0].ToString() + s[0]);
                else newPermutations.Add(str[0].ToString());
                //Add our character after each character in this permutation to create the new permutation
                for (int i = 0; i < s.Length; ++i)
                {
                    if (i == s.Length - 1) newPermutations.Add(s.Substring(0, i + 1) + str[0]);
                    else newPermutations.Add(s.Substring(0, i + 1) + str[0] + s.Substring(i + 1));
                }
            }

            permutations.AddRange(newPermutations);
            string newStr = str.Substring(1);

            return AddPermutations(permutations, newStr);
        }
    }
}
