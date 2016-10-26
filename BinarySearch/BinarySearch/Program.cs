using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {

            // creates array of ints
            int[] array = { 8, 9, 20, 34, 5, 59, 1, 100, 93, 49, 7, 77 };

            int searchNum = 0;

            // sorts array
            Array.Sort(array);

            Console.WriteLine("Which number would you like to search for?");
            bool result = Int32.TryParse(Console.ReadLine(), out searchNum);

            while (!result)
            {
                Console.WriteLine("Please enter a valid number:");
                result = Int32.TryParse(Console.ReadLine(), out searchNum);
            }

            int answer = BinarySearchRecur(array, searchNum);


            if (answer > 0)
            {
                Console.WriteLine("Found the number!");
            }
            else
            {
                Console.WriteLine("Number not found.");
            }

            Console.ReadLine();
        }


        public static int BinarySearch(int[] input, int searchNum)
        {
            int min = 0;
            int max = input.Length - 1;
            int mid = 0;


            while (min <= max) // if min cannot go above max, if it does then the number doesnt exist
            {
                mid = (min + max) / 2; // finds the middle of array

                if (searchNum > input[mid])
                    min = mid + 1; // if the number is greater than the middle then it resets the 
                                   // minimum to be one greater than the middle
                else
                    max = mid + 1; // the other option is that it is less than the middle, then it
                                   // resets the maximum to be one greater than the middle
                if (searchNum == input[mid])
                    return mid; // if it finds the number it returns that number
            }

            return -1; // if it doesn't find the number it returns -1

        }

        public static int BinarySearchRecur(int[] input, int searchNum)
        {
            int min = 0;
            int max = input.Length - 1;
            int mid = (min + max) / 2;
            int j = 0;
            int midPoint = input[mid];

            if ((input.Length) <= 1 && (searchNum != midPoint)) // if the array is of size one and 
                return -1;                                      // the midpoint is not the number then it obviously is not
                                                                // in the array.

            // if the number is less than the midpoint then it will split the array in half and create a new one
            // and then recursively apply this function to that new array.
            if (searchNum < midPoint)
            {
                int[] array = new int[mid]; // this creates an array of size mid
                for (int i = 0; i < mid; i++) // this loads the array with half of the input
                {
                    array[j] = input[i];
                    j++;
                }
                return BinarySearchRecur(array, searchNum);
            }

            // if the number is greater than the midpoint then it will split the array in half and create a new one
            // and then recursively apply this function to that new array.
            if (searchNum > midPoint)
            {
                int[] array = new int[max - mid];
                for (int i = mid + 1; i <= max; i++)
                {
                    array[j] = input[i];
                    j++;
                }
                return BinarySearchRecur(array, searchNum);
            }

            // if the number we are looking for is the midpoint then we are done and
            // it returns that number
            if (searchNum == midPoint)
                return midPoint;


            return -1; // if the number cannot be found it returns -1
        }
    }
}
