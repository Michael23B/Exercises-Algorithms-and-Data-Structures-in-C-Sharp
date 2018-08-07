using System.Collections.Generic;

namespace PracticeQuestionsSharp.Exercises.Dynamic_Programming
{
    public static class DivingBoard
    {
        //You are building a diving board by placing a bunch of planks of wood end-to-end.
        // Using exactly k planks of sizes shorter or longer generate all possible diving board lengths.

        //Recursive solution
        public static List<int> GetPossibleLengths(int shorter, int longer, int k)
        {
            var result = new List<int> {0};

            result = AddPermutations(shorter, longer, k, result);

            return result;
        }

        //Every recurse we add a shorter or longer plank until we reach k length. Ignore duplicate length boards.
        public static List<int> AddPermutations(int shorter, int longer, int k, List<int> currPermutations)
        {
            if (k == 0) return currPermutations;

            List<int> newPermutations = new List<int>();

            foreach (int p in currPermutations)
            {
                if (!newPermutations.Contains(p + shorter)) newPermutations.Add(p + shorter);
                if (!newPermutations.Contains(p + longer)) newPermutations.Add(p + longer);
            }

            return AddPermutations(shorter, longer, k - 1, newPermutations);
        }

        //Iterative solution
        //Recognize that each possible board length is some number of short planks and some long.
        // So we get each permutation (ignoring order) of short and long planks
        public static List<int> GetPossibleLengths2(int shorter, int longer, int k)
        {
            var result = new List<int>();

            if (shorter == longer || shorter == 0 || longer == 0)
            {
                result.Add(longer * k);
                return result;
            }

            for (int i = 0; i <= k; ++i)
            {
                int newLength = (shorter * i) + longer * (k - i);
                result.Add(newLength);
            }

            return result;
        }
    }
}
