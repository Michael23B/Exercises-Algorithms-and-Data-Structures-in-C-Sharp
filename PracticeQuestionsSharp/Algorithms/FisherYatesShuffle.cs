using System;
using System.Collections.Generic;

namespace PracticeQuestionsSharp.Algorithms
{
    /*
     -- To shuffle an array a of n elements (indices 0..n-1):
        for i from n−1 downto 1 do
            j ← random integer such that 0 ≤ j ≤ i
            exchange a[j] and a[i]
     https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
     */
    public static class FisherYatesShuffle
    {
        public static IList<T> Shuffle<T>(this IList<T> arr)
        {
            var rand = new Random();
            int rIndex;
            T temp;

            for (int i = arr.Count - 1; i > 0; --i)
            {
                rIndex = rand.Next(0, i + 1); //max is exclusive

                temp = arr[rIndex];
                arr[rIndex] = arr[i];
                arr[i] = temp;
            }

            return arr;
        }
    }
}
