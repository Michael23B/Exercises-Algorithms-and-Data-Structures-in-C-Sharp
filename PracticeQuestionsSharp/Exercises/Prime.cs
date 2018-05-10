using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticeQuestionsSharp.Exercises
{
    //Print all primes to n
    public static class Prime
    {
        //Brute force
        public static List<int> PrimesToN1(int n)
        {
            bool primeFlag = true;
            List<int> primes = new List<int>();

            for (int i = 1; i < n; ++i)
            {
                for (int j = 2; j < Math.Sqrt(i); ++j)
                {
                    if (i % j == 0)
                    {
                        primeFlag = false;
                        break;
                    }
                }

                if (primeFlag) primes.Add(i);
                else primeFlag = true;
            }

            return primes;
        }

        //Memoize
        //Only divide by the previous prime numbers.
        //The runtime difference between this and the standard function isnt obvious until very large numbers
        public static List<int> PrimesToN2(int n)
        {
            bool primeFlag = true;
            List<int> primes = new List<int>();
            primes.Add(2);

            for (int i = 3; i < n; ++i)
            {
                foreach (int prime in primes)
                {
                    if (prime > Math.Sqrt(i)) break;
                    if (i % prime == 0)
                    {
                        primeFlag = false;
                        break;
                    }
                }

                if (primeFlag) primes.Add(i);
                else primeFlag = true;
            }

            primes.Prepend(1);

            return primes;
        }
    }
}