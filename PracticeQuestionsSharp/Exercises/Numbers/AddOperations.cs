using System;

namespace PracticeQuestionsSharp.Exercises.Numbers
{
    //Write methods for multiply, subtract and divide (*,-,/) using only the add (+) operator
    public static class AddOperations
    {
        public static int Multiply(this int a, int b)
        {
            if (a < 0 && b < 0)
            {
                a = ChangeSign(a);
                b = ChangeSign(b);
            }

            int small = a;
            int large = b;
            int result = 0;
            if (b < a)
            {
                small = b;
                large = a;
            }

            //We increment by small instead of large because it may be a negative value
            for (int i = 0; i < large; ++i)
            {
                result += small;
            }

            return result;
        }

        public static int Subtract(this int a, int b)
        {
            return a + ChangeSign(b);
        }

        public static int Divide(this int a, int b)
        {
            throw new NotImplementedException();
        }

        //Assuming we can't use -(number) but we can use -1.
        //this broken
        private static int ChangeSign(this int a)
        {
            int result = 0;
            int sign = -1;
            if (a < 0) sign = 1;

            while (a != 0)
            {
                result += sign;
                a += sign;
            }

            return result + result;
        }
    }
}
