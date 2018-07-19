using System.Collections.Generic;

namespace PracticeQuestionsSharp.Exercises.Dynamic_Programming
{
    public static class StringPermutations
    {
        //Compute all permutations of a string of unique characters
        public static List<string> DistinctStringPermutations(this string str)
        {
            //Helper.ExtensionMethods.Factorial(str.Length). Could set capacity to this but factorial overflows very quickly so its not that useful.
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
                newPermutations.Add(str[0] + s);
                //Add our character after each character in this permutation to create the new permutation
                for (int i = 0; i < s.Length; ++i)
                {
                    if (i == s.Length - 1) newPermutations.Add(s.Substring(0, i + 1) + str[0]);
                    else newPermutations.Add(s.Substring(0, i + 1) + str[0] + s.Substring(i + 1));
                }
            }

            permutations = newPermutations;
            string newStr = str.Substring(1);

            return AddPermutations(permutations, newStr);
        }

        //Compute all permutations of a string of characters that are not unique. The result must have no duplicates.
        public static List<string> NonDistinctStringPermutations(this string str)
        {
            var duplicateCount = new Dictionary<char, int>();
            List<string> permutations = new List<string>();
            permutations.Add("");

            return AddPermutations2(permutations, str, duplicateCount);
        }

        private static List<string> AddPermutations2(List<string> permutations, string str, Dictionary<char, int> duplicateCount)
        {
            if (str.Length == 0) return permutations;

            List<string> newPermutations = new List<string>();

            //Add this letter to the duplicate count map
            if (duplicateCount.ContainsKey(str[0])) duplicateCount[str[0]]++;
            else duplicateCount.Add(str[0], 1);

            foreach (string s in permutations)
            {
                newPermutations.Add(str[0] + s);
                //Add our character after each character in this permutation to create the new permutation
                for (int i = 0; i < s.Length; ++i)
                {
                    if (s[i] == str[0]) //check against dupe count
                    {
                        i += duplicateCount[str[0]];
                        duplicateCount[str[0]]++;
                        continue;
                    }
                    
                    if (i == s.Length - 1) newPermutations.Add(s.Substring(0, i + 1) + str[0]);
                    else newPermutations.Add(s.Substring(0, i + 1) + str[0] + s.Substring(i + 1));
                }
            }

            permutations = newPermutations;
            string newStr = str.Substring(1);

            return AddPermutations2(permutations, newStr, duplicateCount);
        }
    }
}
