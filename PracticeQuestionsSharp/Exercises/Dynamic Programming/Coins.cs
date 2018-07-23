using System.Collections.Generic;

namespace PracticeQuestionsSharp.Exercises.Dynamic_Programming
{
    //Given an infinite number of coins in denominations: 25c, 10c, 5c and 1c, find all permutations of coins to represent n cents.
    public static class Coins
    {
        public static List<List<int>> RepresentNCents(int cents)
        {
            int[] coins = { 25, 10, 5, 1 };
            List<List<int>> permutations = new List<List<int>>();

            GetCoinPermutations(coins, permutations, new List<int>(),  0, cents);

            return permutations;
        }

        private static void GetCoinPermutations(int[] coins, List<List<int>> permutations, List<int> currPerm, int coinIndex, int cents)
        {
            if (cents == 0)
            {
                permutations.Add(currPerm);
                return;
            }
            if (coinIndex >= coins.Length) return;

            if (cents != coins.Length - 1) GetCoinPermutations(coins, permutations, new List<int>(currPerm), coinIndex + 1, cents);

            int c = coins[coinIndex];
            int total = 0;

            while (total < cents)
            {
                currPerm.Add(c);
                total += c;
                GetCoinPermutations(coins, permutations, new List<int>(currPerm), coinIndex + 1, cents - total);
            }
        }
    }
}
