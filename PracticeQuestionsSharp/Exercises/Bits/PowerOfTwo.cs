
namespace PracticeQuestionsSharp.Exercises.Bits
{
    //The code checks if n is a power of two since powers of two are represented as a 1 followed only by 0s.
    // Taking 1 away removes the first 1 and changes all the 0s to 1s meaning the & matches no digits and results in 0.
    // Since n == 0 also returns true but isn't a power of 2 we need to check for n != 0 first.
    public static class PowerOfTwo
    {
        public static bool IsPowerOfTwo(this int n)
        {
            return n != 0 && (n & (n - 1)) == 0;
        }
    }
}
