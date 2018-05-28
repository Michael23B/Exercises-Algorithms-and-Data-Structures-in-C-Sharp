using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticeQuestionsSharp.Exercises.Numbers
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

        //Sieve of Eratosthenes
        public static List<int> PrimesToN3(int n)
        {
            //Initialize an array of n + 1. All numbers from 2 up are assumed prime.
            bool[] primes = new bool[n+1];
            for (int i = 2; i <= n; ++i) primes[i] = true;

            for (int i = 2; i <= n; ++i)
            {
                int j = i;
                int k = j;
                j += k;
                while (j <= n)
                {
                    primes[j] = false;
                    j += k;
                }
            }

            List<int> result = new List<int>();
            for (int i = 2; i <= n; ++i)
                if (primes[i])
                    result.Add(i);

            return result;
        }
    }
}