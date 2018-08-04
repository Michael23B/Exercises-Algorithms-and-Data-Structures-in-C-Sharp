using System;
using System.Diagnostics;

namespace PracticeQuestionsSharp.Helper
{
    public static class Profiler
    {
        public static T Execute<T>(Func<T> method)
        {
            return method();
        }

        //Accepts a function and logs the execution time.
        // Usage: Profiler.ProfileAndExecute(() => yourMethod(args), repeat?, name?);
        public static T ProfileAndExecute<T>(Func<T> method, int repeat = 1, string name = "")
        {
            T result = default(T);
            long avg, total;

            Console.WriteLine($"Starting method({name})...");
            Stopwatch watch = Stopwatch.StartNew();

            for (int i = 0; i < repeat; ++i)
                result = method();

            watch.Stop();
            total = watch.ElapsedMilliseconds;
            avg = total / repeat;

            Console.WriteLine($"Result: {result}");
            Console.WriteLine($"Total of {total} milliseconds elapsed.");
            Console.WriteLine($"Average of {avg} milliseconds elapsed. (Run {repeat} times).\n");

            return result;
        }
        //TODO: allow void return type
    }
}