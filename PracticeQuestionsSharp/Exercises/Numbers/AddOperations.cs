namespace PracticeQuestionsSharp.Exercises.Numbers
{
    //Write methods for multiply, subtract and divide (*,-,/) using only the add (+) operator.
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
            return a + b.ChangeSign();
        }

        public static int Divide(this int a, int b)
        {
            int total = 0;
            int i = 0;
            int sign = 1;

            if (a < 0 && b < 0)
            {
                a = ChangeSign(a);
                b = ChangeSign(b);
            }
            else if (a < 0)
            {
                a = a.ChangeSign();
                sign = -1;
            }
            else if (b < 0)
            {
                b = b.ChangeSign();
                sign = -1;
            }

            while (total < a)
            {
                total += b;
                i += sign;
            }

            if (total > a) i += sign < 0 ?  1 : -1;

            return i;
        }

        //Assuming we can't use -(number) but we can use -1.
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

            return result;
        }
    }
}
