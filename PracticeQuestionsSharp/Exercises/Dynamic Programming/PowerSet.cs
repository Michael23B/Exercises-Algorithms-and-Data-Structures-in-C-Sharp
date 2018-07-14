using System;
using System.Collections.Generic;

namespace PracticeQuestionsSharp.Exercises.Dynamic_Programming
{
    //The power set of any set S is the set of all subsets of S, including the empty set and S itself.
    public static class PowerSet
    {
        public static List<T[]> GetPowerSet<T>(T[] set)
        {
            List<T[]> powerSet = new List<T[]>((int)Math.Pow(2, set.Length)); //Power sets have 2^n elements 
            powerSet.Add(new T[0]);

            powerSet = AddSets(powerSet, set);

            return powerSet;
        }

        private static List<T[]> AddSets<T>(List<T[]> powerSet, T[] set)
        {
            if (set.Length == 0) return powerSet;

            List<T[]> newSubSets = new List<T[]>(powerSet.Count * 2);
            foreach (T[] subSet in powerSet)
            {
                //New subset is this subset + the current element
                T[] newSubSet = new T[subSet.Length + 1];
                subSet.CopyTo(newSubSet, 0);
                newSubSet[newSubSet.Length - 1] = set[0];
                newSubSets.Add(newSubSet);
            }

            powerSet.AddRange(newSubSets);

            //Shift set left, then recurse
            T[] newSet = new T[set.Length - 1];
            Array.Copy(set, 1, newSet, 0, set.Length - 1);

            return AddSets(powerSet, newSet);
        }
    }
}
