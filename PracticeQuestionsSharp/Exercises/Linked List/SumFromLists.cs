using PracticeQuestionsSharp.DataStructures;

namespace PracticeQuestionsSharp.Exercises.Linked_List
{
    public static class SumFromLists
    {
        //Two numbers represented by linked lists where each node contains a single digit. 
        //The digits are stored in reverse order.
        //eg. 7 1 6 + 5 9 2 = 617 + 295 -> 2 1 9 (912)
        public static LinkedList<int> SumLists(LinkedList<int> left, LinkedList<int> right)
        {
            LinkedList<int> result = new LinkedList<int>();
            Node<int> nodeL = left.Head;
            Node<int> nodeR = right.Head;

            int place = 1;
            int number = 0;

            while (nodeL != null || nodeR != null)
            {
                number += nodeL?.Data * place ?? 0;
                number += nodeR?.Data * place ?? 0;

                place *= 10;

                nodeL = nodeL?.Next;
                nodeR = nodeR?.Next;
            }

            while (number > 0)
            {
                result.Add(number % 10);
                number /= 10;
            }

            return result;
        }
    }
}
