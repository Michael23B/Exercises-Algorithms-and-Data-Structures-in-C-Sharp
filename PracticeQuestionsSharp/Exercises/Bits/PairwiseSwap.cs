namespace PracticeQuestionsSharp.Exercises.Bits
{
    //Swap the even and odd bits in an integer using as few instructions as possible
    public static class PairwiseSwap
    {
        public static int SwapBits(this int i)
        {
            //0xA = 1010 in binary, meaning we have 1s in the even bits
            int mask = 0xAAAAAAA;

            int even = i & mask;
            int odd = i & ~mask;

            return even >> 1 | odd << 1;
        }
    }
}
