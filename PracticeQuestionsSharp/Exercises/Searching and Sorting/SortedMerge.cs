namespace PracticeQuestionsSharp.Exercises.Searching_and_Sorting
{
    //Given two sorted arrays (A and B) where A has enough space at the end to fit B, merge array B into array A
    public static class SortedMerge
    {
        //Using nullable ints so we can represent array buffer as null elements
        //Enough space here means just enough, not more.
        public static void MergeSortedArrays(this int?[] a, int?[] b)
        {
            int aIndex = a.Length - 1;
            while (aIndex >= 0)
            {
                if (a[aIndex] != null) break;
                aIndex--;
            } 
            int bIndex = b.Length - 1;
            int newIndex = a.Length - 1;

            //Compare a to b from largest element to smallest, inserting the larger at the end of a
            while (bIndex >= 0)
            {
                if (a[aIndex] >= b[bIndex])
                {
                    a[newIndex] = a[aIndex];
                    aIndex--;
                }
                else
                {
                    a[newIndex] = b[bIndex];
                    bIndex--;
                }

                newIndex--;
            }
        }
    }
}
