using System;

namespace PracticeQuestionsSharp.Exercises.Dynamic_Programming
{
    //A magic index in a given array A[0...n-1] is defined to be an index such that
    // A[i] == i. Given a sorted array of distinct integers, write a method to find
    // a magic index, if one exists, in array A.
    public static class MagicIndex
    {
        //Brute force with small optimization
        public static int FindMagicIndex(int[] arr)
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                if (arr[i] == i) return i;
                if (arr[i] > i) i = arr[i];
            }

            return -1;
        }

        public static int FindMagicIndexBinarySearch(int[] arr)
        {
            int max = arr.Length - 1;
            int min = 0;

            while (min <= max)
            {
                int mid = min + (max - min) / 2;
                int comparison = mid.CompareTo(arr[mid]);

                switch (comparison)
                {
                    case 1:
                        min = mid + 1;
                        break;
                    case -1:
                        max = mid - 1;
                        break;
                    case 0:
                        return mid;
                }
            }

            return -1;
        }

        //Follow up. What if the values are not distinct?
        public static int FindNonDistinctMagicIndexBinarySearch(int[] arr)
        {
            return CheckArrSubSection(arr, 0, arr.Length - 1);
        }

        //Since numbers are not distinct we have to check both sides, we can only exclude numbers
        // whose index is lower/higher than the next min/max since it's ordered.
        private static int CheckArrSubSection(int[] arr, int min, int max)
        {
            if (min > max) return -1;

            int mid = min + (max - min) / 2;
            if (mid.CompareTo(arr[mid]) == 0) return mid;

            int leftResult = CheckArrSubSection(arr, min, Math.Min(mid - 1, arr[mid]));
            if (leftResult != -1) return leftResult;

            int rightResult = CheckArrSubSection(arr, Math.Max(mid + 1, arr[mid]), max);
            if (rightResult != -1) return rightResult;

            return -1;
        }
    }
}
