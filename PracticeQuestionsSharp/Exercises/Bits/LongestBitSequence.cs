using System.Collections.Generic;

namespace PracticeQuestionsSharp.Exercises.Bits
{
    //Given an int, you can flip exactly one bit from 0 to 1.
    //Find the longest sequence of 1s you could create
    public static class LongestBitSequence
    {
        public static int LongestSequence(this int number)
        {
            List<int> sequenceList = new List<int>();
            int curr = 0;
            int longest = 1;

            while (number > 0)
            {
                if ((number & 1) == 1) curr++;
                else
                {
                    sequenceList.Add(curr);
                    curr = 0;
                }

                number >>= 1;
            }

            if (curr > 0) sequenceList.Add(curr);

            for (int i = 1; i < sequenceList.Count; ++i)
            {
                int length = sequenceList[i] + sequenceList[i - 1] + 1;
                if (length > longest) longest = length;
            }

            return longest;
        }
    }
}
