using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsMasterConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //DONE TODO: Follow the steps provided in the comments under each region.
            //Make the console formatted to display each section well
            //Utlilize the method stubs at the bottom for the methods you must create ⬇⬇⬇

            #region Arrays
            Console.Clear();
            Console.WriteLine("Array Exercises");
            Console.WriteLine();

            //DONE TODO: Create an integer Array of size 50
            var intArray = new int[50];

            //DONE TODO: Create a method to populate the number array with 50 random numbers that are between 0 and 50
            Populater(intArray);

            //DONE TODO: Print the first number of the array
            Console.WriteLine($"First element = {intArray[0]}");

            //DONE TODO: Print the last number of the array            
            Console.WriteLine($"Last element = {intArray[intArray.Length-1]}");
            Console.WriteLine("-------------------");

            Console.WriteLine("All Numbers Original");
            //UNCOMMENT this method to print out your numbers from arrays or lists
            NumberPrinter(intArray,true);
            Console.WriteLine("-------------------");

            //DONE TODO: Reverse the contents of the array and then print the array out to the console.
            //Try for 2 different ways
            /*  1) First way, using a BUILT-IN method => Hint: Array._____(); 
                2) Second way, Create a CUSTOM method (scroll to bottom of page to find ⬇⬇⬇)
            */

            Console.WriteLine("All Numbers Reversed:");
            Array.Reverse(intArray);
            NumberPrinter(intArray,true);
            Console.WriteLine("-------------------");

            Console.WriteLine("All Numbers Reversed Back (Custom)");
            ReverseArray(intArray);
            NumberPrinter(intArray, true);
            Console.WriteLine("-------------------");

            //DONE TODO: Create a method that will set numbers that are a multiple of 3 to zero then print to the console all numbers
            Console.WriteLine("Multiple of three = 0: ");
            ThreeKiller(intArray);
            NumberPrinter(intArray,true);
            Console.WriteLine("-------------------");

            //DONE TODO: Sort the array in order now
            /*      Hint: Array.____()      */
            Console.WriteLine("Sorted numbers:");
            Array.Sort(intArray);
            NumberPrinter(intArray,true);
            Console.WriteLine("-------------------");
 
            Console.WriteLine("\n************End Arrays*************** \n");
            Console.WriteLine("Press <ENTER> to continue...");
            Console.ReadLine();
            #endregion

            #region Lists
            Console.Clear();
            Console.WriteLine("************Start Lists**************");

            /*   Set Up   */
            //DONE TODO: Create an integer List
            var lstNumbers = new List<int>();

            //DONE TODO: Print the capacity of the list to the console
            Console.WriteLine($"The capacity of my list is presently: {lstNumbers.Capacity}");

            //DONE TODO: Populate the List with 50 random numbers between 0 and 50 you will need a method for this            
            Populater(lstNumbers);

            //DONE TODO: Print the new capacity
            Console.WriteLine($"After populating w/ 50 numbers, the capacity of my list is: {lstNumbers.Capacity}");
            Console.WriteLine("---------------------");

            Console.WriteLine("All Numbers:");
            NumberPrinter(lstNumbers,true);
            Console.WriteLine("---------------------");

            //TODO: Create a method that prints if a user number is present in the list
            //Remember: What if the user types "abc" accident your app should handle that!
            string userInput = "";
            while (int.TryParse(userInput,out int newNum) == false)
            {
                Console.WriteLine("What number will you search for in the number list?");
                userInput = Console.ReadLine();
            }
            NumberChecker(lstNumbers, int.Parse(userInput));
            Console.WriteLine("-------------------");

            //TODO: Create a method that will remove all odd numbers from the list then print results
            Console.WriteLine("Evens Only!!");
            OddKiller(lstNumbers);
            NumberPrinter(lstNumbers,true); 
            Console.WriteLine("------------------");

            //TODO: Sort the list then print results
            Console.WriteLine("Sorted Evens!!");
            lstNumbers.Sort();
            NumberPrinter(lstNumbers,true);
            Console.WriteLine("------------------");

            //TODO: Convert the list to an array and store that into a variable
            Console.WriteLine("Array copy of the remaining numbers:");
            int[] arrayVersion = lstNumbers.ToArray();
            NumberPrinter(arrayVersion,true);
            Console.WriteLine("------------------");

            //TODO: Clear the list
            lstNumbers.Clear();

            #endregion
        }

        private static void ThreeKiller(int[] numbers)
        {
            for (int i=0; i<numbers.Length; ++i)
                if (numbers[i]%3==0)
                    numbers[i] = 0;
        }

        private static void OddKiller(List<int> numberList)
        {
            numberList.RemoveAll(number => number%2 != 0);
        }

        private static void NumberChecker(List<int> numberList, int searchNumber)
        {
            if (numberList.Contains(searchNumber))
                Console.WriteLine("Successfully found that!");
            else
                Console.WriteLine("Entry not found.");
        }

        private static void Populater(List<int> numberList)
        {
            Random rng = new Random();
            for (int i = 0; i < 50; i++)
                numberList.Add(rng.Next(50));
        }

        private static void Populater(int[] numbers)
        {
            Random rng = new Random();
            for (int i=0; i<numbers.Length; i++)
                numbers[i] = rng.Next(numbers.Length);
        }        

        private static void ReverseArray(int[] array)
        {
            var tmpArray = (int[])array.Clone();
            for (int i=0; i<array.Length; ++i)
                array[i] = tmpArray[tmpArray.Length - 1 - i];
        }

        /// <summary>
        /// Generic print method will iterate over any collection that implements IEnumerable<T>
        /// </summary>
        /// <typeparam name="T"> Must conform to IEnumerable</typeparam>
        /// <param name="collection"></param>
        private static void NumberPrinter<T>(T collection) where T : IEnumerable<int>
        {
            //STAY OUT DO NOT MODIFY!!
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

        private static void NumberPrinter<T>(T collection, bool setFormat) where T : IEnumerable<int>
        {
            if (setFormat == true)
            {
                string outLine = "{";
                foreach (var item in collection)
                    outLine += item.ToString() + ",";
                outLine += "}";
                outLine = outLine.Replace(",}", "}");
                Console.WriteLine(outLine);
            }
            else
            {
                foreach (var item in collection)
                    Console.WriteLine(item);
            }
        }

    }
}
