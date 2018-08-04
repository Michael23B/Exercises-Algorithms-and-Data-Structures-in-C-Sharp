using System;

namespace PracticeQuestionsSharp.Exercises.Bits
{
    //Given two 32-bit numbers, N and M, and two bit positions, i and j, insert M into N
    // starting at bit j and ending at bit i. You may assume there is enough bits for M to fit.
    public static class Insertion
    {
        public static UInt32 InsertBitInto(this UInt32 M, UInt32 N, int i, int j)
        {
            //Create a mask to zero out all bits from j to i.
            UInt32 mask = 1;

            for (int k = 1; k < j; ++k)
            {
                mask = mask << 1;
                if (k < j - i) mask += 1;
            }

            N = N & ~mask;

            //Insert M into N now that we have an empty section
            mask = M << i;
            N = N | mask;

            return N;
        }
    }
}
