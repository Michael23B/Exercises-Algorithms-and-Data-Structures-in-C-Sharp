using System;
using System.Collections.Generic;
using Path = System.Collections.Generic.List<int>;

namespace PracticeQuestionsSharp.Exercises.Dynamic_Programming
{
    //A child is running up a staircase with n steps and can hop either 1, 2 or 3 steps at a time.
    //Count how many possible ways the child could run up the steps.

    //Recursive - No memoization
    public static class StaircaseSteps
    {
        public static int StepPermutations(int n)
        {
            List<Path> paths = new List<Path>();
            ClimbSteps(n, 1, 0, new Path(), paths);
            ClimbSteps(n, 2, 0, new Path(), paths);
            ClimbSteps(n, 3, 0, new Path(), paths);

            return paths.Count;
        }

        private static void ClimbSteps(int n, int stepSize, int currStepsTaken, Path currPath, List<Path> paths)
        {
            currStepsTaken += stepSize;
            currPath.Add(stepSize);

            if (currStepsTaken > n) return;
            if (currStepsTaken == n)
            {
                paths.Add(currPath);
                return;
            }

            if (currStepsTaken < n)
            {
                ClimbSteps(n, 1, currStepsTaken, new Path(currPath), paths);
                ClimbSteps(n, 2, currStepsTaken, new Path(currPath), paths);
                ClimbSteps(n, 3, currStepsTaken, new Path(currPath), paths);
            }
        }

        //Recursive memoized
        public static int StepPermutationsMemoized(int n)
        {
            int[] memoized = new int[n];
            Array.Fill(memoized, -1);
            return ClimbStepsMemoized(n, 1, memoized) +
                   ClimbStepsMemoized(n, 2, memoized) +
                   ClimbStepsMemoized(n, 3, memoized);
        }

        private static int ClimbStepsMemoized(int n, int stepSize, int[] memoized)
        {
            n -= stepSize;
            if (n < 0) return 0; //Path is not valid
            if (n == 0) return 1; //Path is valid

            if (memoized[n] != -1) return memoized[n];

            return memoized[n] = ClimbStepsMemoized(n, 1, memoized) +
                                 ClimbStepsMemoized(n, 2, memoized) + 
                                 ClimbStepsMemoized(n, 3, memoized);
        }
    }
}
