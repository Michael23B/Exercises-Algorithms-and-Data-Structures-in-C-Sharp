using System;
using System.Collections.Generic;
using PracticeQuestionsSharp.Algorithms;

namespace PracticeQuestionsSharp.Exercises.Numbers
{
    //Given two arrays of integers, find the smallest difference between any two elements, one from each array.
    public static class SmallestDifference
    {
        public static int FindSmallestDif(IList<int> arr1, IList<int> arr2)
        {
            var a = arr1.MergeSort();
            var b = arr2.MergeSort();

            int i = 0;
            int j = 0;
            int minDif = int.MaxValue;

            while (i < a.Count || j < b.Count)
            {
                if (i >= a.Count)
                {
                    minDif = Math.Min(Math.Abs(a[a.Count - 1] - b[j]), minDif);
                    j++;
                }
                else if (j >= b.Count)
                {
                    minDif = Math.Min(Math.Abs(a[i] - b[b.Count - 1]), minDif);
                    i++;
                }
                else
                {
                    minDif = Math.Min(Math.Abs(a[i] - b[j]), minDif);

                    if (a[i] < b[j]) i++;
                    else j++;
                }
            }

            return minDif;
        }
    }
}
