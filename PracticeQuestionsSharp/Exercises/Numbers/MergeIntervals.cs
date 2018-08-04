using System.Collections.Generic;
using System.Linq;

//Given a collection of intervals, merge all overlapping intervals
// eg. [[1,4],[4,5]] -> [[1,5]].
namespace PracticeQuestionsSharp.Exercises.Numbers
{
    public class Interval
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }

    public static class MergeIntervals
    {
        public static IList<Interval> MergeOverlappingIntervals(this IList<Interval> intervals)
        {
            List<Interval> sorted = intervals.OrderBy(x => x.Min).ToList();

            for (int i = 0; i < sorted.Count - 1; ++i)
            {
                if (sorted[i].Max >= sorted[i + 1].Min)
                {
                    sorted[i].Max = sorted[i + 1].Max;
                    sorted.RemoveAt(i + 1);
                }
            }

            return sorted;
        }
    }
}
