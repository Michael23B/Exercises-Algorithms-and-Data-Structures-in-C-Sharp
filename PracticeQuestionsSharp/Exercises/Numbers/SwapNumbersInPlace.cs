namespace PracticeQuestionsSharp.Exercises.Numbers
{
    //Write a function to swap a number in place
    public static class SwapNumbersInPlace
    {
        public static void SwapNumbers(int[] arr, int a, int b)
        {
            arr[a] += arr[b];
            arr[b] = arr[a] - arr[b];
            arr[a] -= arr[b];
        }
    }
}
