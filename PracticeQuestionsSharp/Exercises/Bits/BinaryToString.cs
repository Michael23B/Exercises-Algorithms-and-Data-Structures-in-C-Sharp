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
            StringBuilder sb = new StringBuilder().Append("0.");

            //Convert to binary
            double fraction = 0.5;
            //Arbitrary limit since we may not reach zero in floating point representation
            while (d >= 0.00001 && sb.Length <= 32)
            {
                if (d >= fraction)
                {
                    sb.Append(1);
                    d -= fraction;
                }
                else
                {
                    sb.Append(0);
                }

                fraction /= 2;
            }

            //Remainder, couldn't fit into 32 characters
            if (d >= 0.00001) return "ERROR.";

            return sb.ToString();
        }
    }
}
