using System;
using System.Text;

namespace PracticeQuestionsSharp.Exercises.Bits
{
    //Given a real number between 0 and 1 that is passed in as a double, 
    //print the binary representation. If it cannot be represented in 32 characters, print "ERROR."
    public static class BinaryToString
    {
        public static string DoubleToBinaryString(this double d)
        {
            StringBuilder sb = new StringBuilder();
            double rounded = Math.Floor(d);

            //Keep multiplying by ten until we have a whole number
            while (d - rounded != 0)
            {
                d *= 10;
                rounded = Math.Floor(d);
            }

            //Convert to binary
            double place = Math.Pow(2, 32);
            while (place >= 1)
            {
                if (d >= place)
                {
                    sb.Append(1);
                    d -= place;
                }
                else
                {
                    if (sb.Length > 0) sb.Append(0);
                }

                place /= 2;
            }

            //Remainder, couldn't fit into 32 characters
            if (d > 0) return "ERROR.";

            return sb.ToString();
        }
    }
}
