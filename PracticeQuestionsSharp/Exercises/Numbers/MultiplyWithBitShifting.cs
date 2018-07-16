namespace PracticeQuestionsSharp.Exercises.Numbers
{
    //Perform multiplication using only bit shift operations, addition and subtraction
    public static class MultiplyWithBitShifting
    {
        //TODO: currently doesn't work with negative numbers
        public static int Multiply(int a, int b)
        {
            if (a == 0 || b == 0) return 0;

            int larger = a;
            int smaller = b;
            int sum = 0;
            int place = 0;

            if (a < b)
            {
                larger = b;
                smaller = a;
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

            return sum;
        }
    }
}
