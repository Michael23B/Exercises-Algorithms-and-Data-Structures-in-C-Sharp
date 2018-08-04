using System;

namespace PracticeQuestionsSharp.Exercises.Numbers
{
    //Perform multiplication using only bit shift operations, addition and subtraction.
    public static class MultiplyWithBitShifting
    {
        public static int Multiply(int a, int b)
        {
            if (a == 0 || b == 0) return 0;

            int larger;
            int smaller;
            bool positive = true;
            int sum = 0;
            int place = 0;

            if (a < 0 && b < 0)
            {
                //Result is positive, get absolute values to work with
                a = Math.Abs(a);
                b = Math.Abs(b);
            }
            else if (a < 0 || b < 0)
            {
                //If one side is negative, the result is negative
                positive = false;
                a = Math.Abs(a);
                b = Math.Abs(b);
            }

            if (a < b)
            {
                larger = b;
                smaller = a;
            }
            else
            {
                larger = a;
                smaller = b;
            }

            while (smaller != 0)
            {
                if ((smaller & 1) == 1)
                {
                    sum += larger << place;
                }
                smaller >>= 1;
                place++;
            }

            return positive ? sum: -sum;
        }
    }
}
