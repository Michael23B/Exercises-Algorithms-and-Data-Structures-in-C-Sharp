namespace PracticeQuestionsSharp.Exercises.Bits
{
    //Write a function to determine the number of bits you would need to flip to convert int A to int B.
    public static class ConvertIntToInt
    {
        public static int CountFlipsToConvertTo(this int a, int b)
        {
            int difference = a ^ b;
            int result = 0;

            //Count the ones in difference to see how many changes are needed
            while (difference > 0)
            {
                if ((difference & 1) == 1) result++;
                difference >>= 1;
            }

            return result;
        }
    }
}
