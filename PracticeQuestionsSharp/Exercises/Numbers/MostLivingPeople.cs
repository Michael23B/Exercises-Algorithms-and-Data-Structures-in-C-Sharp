using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeQuestionsSharp.Exercises.Numbers
{
    public static class MostLivingPeople
    {
        //Given a list of people with their birth and death years, compute the year with most people alive.
        //Where int[n][0] = birth year & int[n][1] = death year
        public static int GetYearWithMostLivingPeople(int[][] birthAndDeathYears)
        {
            List<int> birthYears = new List<int>();
            List<int> deathYears = new List<int>();
            int maxYear = -1;
            int maxPeople = -1;
            int aliveCount = 0;

            foreach (int[] bd in birthAndDeathYears)
            {
                /*
                 Return Value The zero-based index of item in the sorted List<T>, if item is found; 
                 otherwise, a negative number that is the bitwise complement of the index of the next
                 element that is larger than item or, if there is no larger element, the bitwise complement of Count.
                 */
                int birthIndex = birthYears.BinarySearch(bd[0]);
                int deathIndex = deathYears.BinarySearch(bd[1]);

                if (birthIndex < 0) birthIndex = ~birthIndex;
                if (deathIndex < 0) deathIndex = ~deathIndex;

                birthYears.Insert(birthIndex, bd[0]);
                deathYears.Insert(deathIndex, bd[1]);
            }

            //Loop through birth and death years (now sorted) and increment/decrement keeping track of the max
            int i = 0, j = 0;
            while (i < birthYears.Count)
            {
                if (birthYears[i] < deathYears[j])
                {
                    aliveCount++;

                    if (aliveCount > maxPeople)
                    {
                        maxYear = birthYears[i];
                        maxPeople = aliveCount;
                    }

                    i++;
                }
                else if (birthYears[i] == deathYears[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    aliveCount--;
                    j++;
                }
            }

            Console.WriteLine($"Max year - {maxYear}, Max people - {maxPeople}");

            return maxYear;
        }
    }
}
