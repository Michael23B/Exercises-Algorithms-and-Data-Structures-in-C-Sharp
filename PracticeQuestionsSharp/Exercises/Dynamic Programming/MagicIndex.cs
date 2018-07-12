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
    }

    //Follow up. What if the values are not distinct?
}
