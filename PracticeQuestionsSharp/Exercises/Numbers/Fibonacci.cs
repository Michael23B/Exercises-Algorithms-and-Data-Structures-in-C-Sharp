namespace PracticeQuestionsSharp.Exercises.Numbers
{
    //Return the n-th Fibonacci number.
    public static class Fibonacci
    {
        //Recursive
        public static int Fibonacci1(int n)
        {
            if (n < 2) return n;
            return Fibonacci1(n - 1) + Fibonacci1(n - 2);
        }

        //Memoized
        public static int Fibonacci2(int n)
        {
            int[] fib = new int[n + 1];
            fib[0] = 0;
            fib[1] = 1;

            for (int i = 2; i <= n; ++i)
            {
                fib[i] = fib[i - 1] + fib[i - 2];
            }

            return fib[n];
        }
    }
}