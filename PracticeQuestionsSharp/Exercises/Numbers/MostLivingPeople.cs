using System;
using System.Collections.Generic;

namespace PracticeQuestionsSharp.Exercises.Numbers
{
    public static class MostLivingPeople
    {
        //Given a list of people with their birth and death years, compute the year with most people alive.
        // Where int[n][0] = birth year & int[n][1] = death year
        public static int GetYearWithMostLivingPeople(int[][] birthAndDeathYears)
        {
            List<int> birthYears = new List<int>();
            List<int> deathYears = new List<int>();
            int maxYear = -1;
            int maxPeople = -1;
            int aliveCount = 0;

            //Iterate through birth and death years, inserting them into lists in order
            foreach (int[] bd in birthAndDeathYears)
            {
                int birthIndex = birthYears.BinarySearch(bd[0]);
                int deathIndex = deathYears.BinarySearch(bd[1]);

                if (birthIndex < 0) birthIndex = ~birthIndex;
                if (deathIndex < 0) deathIndex = ~deathIndex;

                birthYears.Insert(birthIndex, bd[0]);
                deathYears.Insert(deathIndex, bd[1]);
                //If binary search doesn't find the element, it returns the bitwise complement of index of the next element that is larger
                //That's pretty neat
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
                else //birthYears[i] > deathYears[i]
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
