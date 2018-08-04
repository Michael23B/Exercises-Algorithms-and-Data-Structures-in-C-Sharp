namespace PracticeQuestionsSharp.Exercises.Strings
{
    public static class PatternMatching
    {
        //Knuth-Morris-Pratt pattern matching algorithm.
        public static int KMPFindIndexOf(this string text, string pattern)
        {
            int[] pmt = GeneratePartialMatchTable(pattern);

            int matches = 0;

            for (int i = 1; i < text.Length; ++i)
            {
                //Partial-match found
                while (matches > 0 && text[i] != pattern[matches])
                {
                    //Move back through the Partial-match table
                    matches = pmt[matches - 1];
                }

                if (text[i] == pattern[matches])
                {
                    //Character matched, increment and check if we are done
                    matches++;
                    if (matches == pattern.Length) return i - (matches - 1);
                }
            }

            return -1;
        }

        private static int[] GeneratePartialMatchTable(string pattern)
        {
            int[] pmt = new int[pattern.Length];
            pmt[0] = 0;

            for (int i = 1; i < pattern.Length; ++i)
            {
                //Start from the previous match count
                int j = pmt[i - 1];

                //Find the previous match count that this substring also matches
                while (j > 0 && pattern[i] != pattern[j]) j = pmt[j - 1];

                //Check if the first character matches this character
                if (pattern[i] == pattern[j]) ++j;

                pmt[i] = j;
            }

            return pmt;
        }
    }
}
