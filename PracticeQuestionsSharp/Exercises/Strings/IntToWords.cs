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

            for (int j = 0; j < digits.Count; ++j)
            {
                int ones = digits[j];
                int tens = j + 1 < digits.Count ? digits[j + 1] : 0;
                int hundreds = j + 2 < digits.Count ? digits[j + 2] : 0;

                result.Insert(0, GetWordSubsection(ones, tens, hundreds, j));

                j += 2;
            }

            if (i < 0) result.Insert(0, "negative ");

            return result.ToString();
        }

        private static string GetWordSubsection(int ones, int tens, int hundreds, int proceedingZeroes)
        {
            if (ones > 9 || tens > 9 || hundreds > 9 || ones < 0 || tens < 0 || hundreds < 0)
                throw new SyntaxErrorException("Ones, tens and hundreds must be 0 or positive numbers below 10.");
            if (proceedingZeroes % 3 != 0)
                throw new SyntaxErrorException("Proceeding zeroes must be 0 or divisible by three");

            //We pad the arrays to make the code using them cleaner
            //Initializing these for each function call is not ideal but we want to remain a static class and its getting called at most 4 times so I believe it's fine
            string[] onesStrings = {"", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
            string[] teensStrings = {"ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"};
            string[] tensStrings = {"", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"};
            string[] hundredsStrings = {"hundred", "thousand", "million", "billion", "trillion"};

            StringBuilder word = new StringBuilder();

            if (proceedingZeroes > 0 && (ones > 0 || tens > 0 || hundreds > 0)) word.Append(hundredsStrings[proceedingZeroes / 3] + ", ");

            if (tens == 1)
            {
                word.Insert(0, teensStrings[ones] + " ");
            }
            else
            {
                if (ones != 0) word.Insert(0, onesStrings[ones] + " ");
                if (tens != 0) word.Insert(0, tensStrings[tens] + " ");
            }

            if (hundreds != 0) word.Insert(0, onesStrings[hundreds] + " " + hundredsStrings[0] + (tens > 0 || ones > 0 ? " and " : " "));

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
    }
}
