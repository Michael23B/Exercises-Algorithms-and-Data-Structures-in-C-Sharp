using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PracticeQuestionsSharp
{
    class Profiler
    {
        public static T Execute<T>(Func<T> method)
        {
            return method();
        }

        //Accepts a function and logs the execution time
        public static T ProfileAndExecute<T>(Func<T> method)
        {
            Stopwatch watch = Stopwatch.StartNew();

            Console.WriteLine("Starting method...");

            var result = method();

            Console.WriteLine("Result: " + result);

            Console.WriteLine(watch.ElapsedMilliseconds + " milliseconds elapsed.");
            watch.Stop();

            return result;
        }
    }

    //Given an array of n distinct numbers, find all pairs that have a difference of k
    class Kdif
    {
        //Brute force solution
        public static int FindKDifferencePairs1(int[] arr, int k)
        {
            int count = 0;

            for (int i = 0; i < arr.Length - 1; ++i)
            {
                for (int j = i + 1; j < arr.Length; ++j)
                {
                    if (Math.Abs(arr[i] - arr[j]) == k) count++;
                }
            }

            return count;
        }

        //Hash solution
        public static int FindKDifferencePairs2(int[] arr, int k)
        {
            int count = 0;
            Dictionary<int, int> dict = new Dictionary<int, int>();

            foreach (int i in arr)
                dict.Add(i, i);

            foreach (int i in arr)
                if (dict.ContainsKey(i + k))
                    count++;

            return count;
        }
    }

    //Print all primes to n
    class Prime
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

            foreach (int i in primes) Console.Write(i + " ");
            Console.WriteLine("");
            return primes;
        }

        //Memoize
        //If you maintain the list of primes you can also refine the first algo to divide only with primes until the square root of the number.
        public static List<int> PrimesToN2(int n)
        {
            bool primeFlag = true;
            List<int> primes = new List<int>();
            primes.Add(2);

            for (int i = 3; i < n; ++i)
            {
                foreach (int prime in primes)
                {
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

            foreach (int i in primes) Console.Write(i + " ");
            Console.WriteLine("");
            return primes;
        }
    }

    class Program
    {
        public static void Main()
        {
            //K difference
            /*
            int[] array = new int[10000];
            for (int i = 0; i < array.Length; ++i) array[i] = i;

            Profiler.ProfileAndExecute(() => Kdif.FindKDifferencePairs1(array, 10));
            Profiler.ProfileAndExecute(() => Kdif.FindKDifferencePairs2(array, 10));
            */

            //Primes
            Profiler.ProfileAndExecute(() => Prime.PrimesToN1(20000));
            Profiler.ProfileAndExecute(() => Prime.PrimesToN2(20000));
        }
    }
}
/*
//1. Print all prime numbers up to 100
void PrintPrimeNumbers(int n)
{
bool primeFlag = true;

    for (int i = 1; i <= n; ++i)
{
    primeFlag = true;
    for (int j = 2; j < i; ++j)
    {
        if (i % j == 0)
        {
            primeFlag = false;
            break;
        }
    }
    if (primeFlag) std::cout << i << " is prime.\n";
    else primeFlag = true;
}
}

//2. Reverse a string in place
std::string Reverse(std::string& text)
{
char temp = '\0';

    for (int i = 0; i < text.size(); ++i)
{
    if (i >= text.size() - (i + 1)) break;
    temp = text[i];
    text[i] = text[text.size() - (i + 1)];
    text[text.size() - (i + 1)] = temp;
}
return text;
}

//3. FizzBuzz
void FizzBuzz(int n)
{
for (int i = 1; i <= n; ++i)
{
if (i % 15 == 0) std::cout << "FizzBuzz";
else if (i % 3 == 0) std::cout << "Fizz";
else if (i % 5 == 0) std::cout << "Buzz";
else if (i % 3 != 0 && i % 5 != 0) std::cout << i;

if (i != n) std::cout << ',';
}
}

//4. Fibonacci
//Trivial
int Fibonacci(int n)
{
if (n < 2) return 1;
else return Fibonacci(n - 1) + Fibonacci(n - 2);
}
//Memoized
std::vector<int> Fibonacci2(int n, std::vector<int>& fib)
{
fib = std::vector<int>(n);
for (int i = 0; i < n; ++i)
{
if (i < 2) fib[i] = 1;
else fib[i] = fib[i - 1] + fib[i - 2];
}
return fib;
}
*/