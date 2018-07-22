using System.Collections.Generic;

namespace PracticeQuestionsSharp.Exercises.Dynamic_Programming
{
    //Return all valid permutations of n pairs of parentheses
    public static class ParenthesesPermutations
    {
        public static List<string> ParenthesesPermutationsFor(int n)
        {
            List<string> permutations = new List<string>();
            GetPermutations(permutations, "", n, 0, 0);

            return permutations;
        }

        private static void GetPermutations(List<string> permutations, string currPermutation, int n, int leftParens, int rightParens)
        {
            if (leftParens > n || rightParens > leftParens) return;

            if (currPermutation.Length == n * 2)
            {
                permutations.Add(currPermutation);
                return;
            }

            GetPermutations(permutations, currPermutation + ')', n, leftParens, rightParens + 1);
            GetPermutations(permutations, currPermutation + '(', n, leftParens + 1, rightParens);
        }
    }
}
