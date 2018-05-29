using System.Collections.Generic;

namespace PracticeQuestionsSharp.Exercises.Strings
{
    //Implement atoi which converts a string to an integer.
    public static class StringToInt
    {
        public static int Atoi(string str)
        {
            List<int> digits = new List<int>();
            bool sign = true; //true for positive and false for negative numbers
            int i = 0;
            int place = 1;
            int result = 0;

            str = str.TrimStart(' ');

            if (str[0] == '-')
            {
                sign = false;
                i = 1; //skip the first character since it isn't a number
            }
            else if (str[0] == '+') i = 1;

            for (; i < str.Length; ++i)
            {
                if (char.IsNumber(str[i]))
                {
                    digits.Add((int)char.GetNumericValue(str[i]));
                }
                else break;
            }

            for (int j = digits.Count - 1; j >= 0; --j)
            {
                result += digits[j] * place;
                if (result < 0) return int.MinValue; //integer overflow
                place *= 10;
            }

            return sign ? result : -result;
        }
    }
}
