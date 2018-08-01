using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PracticeQuestionsSharp.Exercises.Strings
{
    public static class IntToWords
    {
        public static string ConvertToWords(this int i)
        {
            if (i == 0) return "zero";

            List<int> digits = i.GetDigits();
            StringBuilder result = new StringBuilder();
            WordLists wordLists = new WordLists();

            //Iterate through each group of three digits, and perform GetWordSubsection
            for (int j = 0; j < digits.Count; ++j)
            {
                int ones = digits[j];
                int tens = j + 1 < digits.Count ? digits[j + 1] : 0;
                int hundreds = j + 2 < digits.Count ? digits[j + 2] : 0;

                result.Insert(0, GetWordSubsection(ones, tens, hundreds, j, wordLists));

                j += 2;
            }

            //Check for negative and cleanup trailing commas/whitespace
            if (i < 0) result.Insert(0, "negative ");
            if (result[result.Length - 2] == ',') result.Remove(result.Length - 2, 1);

            return result.ToString().Trim();
        }

        private static string GetWordSubsection(int ones, int tens, int hundreds, int proceedingZeroes, WordLists wordLists)
        {
            if (ones > 9 || tens > 9 || hundreds > 9 || ones < 0 || tens < 0 || hundreds < 0)
                throw new SyntaxErrorException("Ones, tens and hundreds must be 0 or positive numbers below 10.");
            if (proceedingZeroes % 3 != 0)
                throw new SyntaxErrorException("Proceeding zeroes must be 0 or divisible by three");

            //If we have no ones, tens or hundreds, skip this group
            if (!(ones > 0 || tens > 0 || hundreds > 0)) return "";

            StringBuilder word = new StringBuilder();

            //Every 3 proceeding zeroes changes the suffix (thousand, million, etc.)
            if (proceedingZeroes > 0)
                word.Append(wordLists.HundredsStrings[proceedingZeroes / 3] + ", ");

            if (tens == 1)
            {
                //Deal with 10 through 19
                word.Insert(0, wordLists.TeensStrings[ones] + " ");
            }
            else
            {
                //Otherwise deal with 1-9 and 20-99
                if (ones != 0) word.Insert(0, wordLists.OnesStrings[ones] + " ");
                if (tens != 0) word.Insert(0, wordLists.TensStrings[tens] + " ");
            }

            //Hundreds is the same as 1-9, followed by " hundred and..."
            //If there is no tens or ones, it is just number + " hundred"
            if (hundreds != 0) word.Insert(0, wordLists.OnesStrings[hundreds] + " " + wordLists.HundredsStrings[0] + (tens > 0 || ones > 0 ? " and " : " "));

            return word.ToString();
        }

        private static List<int> GetDigits(this int i)
        {
            i = Math.Abs(i);
            List<int> digits = new List<int>();

            while (i > 0)
            {
                digits.Add(i % 10);
                i /= 10;
            }

            return digits;
        }

        //We use this class so we don't have to initialize the arrays every time we call GetWordSubsection() or pass in 4 arrays
        private class WordLists
        {
            //We pad the arrays to make the code using them cleaner
            public WordLists()
            {
                OnesStrings = new[] { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
                TeensStrings = new[] { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                TensStrings = new[] { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
                HundredsStrings = new[] { "hundred", "thousand", "million", "billion", "trillion" };
            }

            public string[] OnesStrings { get; }
            public string[] TeensStrings { get; }
            public string[] TensStrings { get; }
            public string[] HundredsStrings { get; }
        }
    }
}
