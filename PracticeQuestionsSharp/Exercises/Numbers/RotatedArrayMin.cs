namespace PracticeQuestionsSharp.Exercises.Numbers
{
    //Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand. Find the minimum value.
    public static class RotatedArrayMin
    {
        public static int MinimumInRotatedSortedArray(int[] arr)
        {
            if (arr == null || arr.Length == 0) return int.MaxValue;

            int min = 0;
            int max = arr.Length - 1;
            int mid;

            while (min <= max)
            {
                if (arr[min] < arr[max]) return arr[min];

                mid = min + (max - min) / 2;

                if (arr[min] <= arr[mid]) min = mid + 1;
                else max = mid;
            }

            return arr[min];
        }
    }
}
