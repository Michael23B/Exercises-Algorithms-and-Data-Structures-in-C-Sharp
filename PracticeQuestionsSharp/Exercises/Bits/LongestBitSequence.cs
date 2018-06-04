namespace PracticeQuestionsSharp.Exercises.Bits
{
    //Given an int, you can flip exactly one bit from 0 to 1.
    //Find the longest sequence of 1s you could create
    public static class LongestBitSequence
    {
        public static int LongestSequence(this int number)
        {
            int curr = 0;
            int prev = 0;
            int longest = 1;
            bool foundZero = false;

            while (number > 0)
            {
                if ((number & 1) == 1) curr++;
                else
                {
                    //Found a zero, set prev to zero if next bit is zero
                    prev = number >> 1 == 0 ? 0 : curr;
                    curr = 0;
                    foundZero = true;
                }

                int total = prev + curr + 1;
                longest = longest > total ? longest : total;

                number >>= 1;
            }

            if (!foundZero) //Number is all ones, return the current count
            {
                return curr < 1 ? 1 : curr;
            }

            return longest;
        }
    }
}
