using System;
using System.Linq;

namespace Bisection
{
    class Program
    {
        public static int computerGuesses = 0;
        public static int Bisect(int searchValue, int[] inputArray)
        {
            computerGuesses++;
            if(inputArray.Length == 1)
            {
                return inputArray[0];
            }
            else
            {
                int mid = inputArray.Length / 2;
                if(inputArray.Length % 2 == 0)
                {
                    mid = (inputArray.Length / 2) - 1;
                }
                if(searchValue == inputArray[mid])
                {
                    return inputArray[mid];
                }
                else if (searchValue < inputArray[mid])
                {
                    int[] lowList = new int [mid];
                    for (int i = 0; i < lowList.Length; i++)
                    {
                        lowList[i] = inputArray[i];
                    }
                    return Bisect(searchValue, lowList);
                }
                else if (searchValue > inputArray[mid])
                {
                    int[] highList = new int [inputArray.Length - (mid + 1)];
                    for (int i = 0; i < highList.Length; i++)
                    {
                        highList[i] = inputArray[mid + i + 1];
                    }
                    return Bisect(searchValue, highList);
                }
            }
            return 0;
        }
        static void Main(string[] args)
        {
            // Bisect method

            int[] oneToTen = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int userInput = 0;
            Console.WriteLine("Input a number from 1-10");
            try
            {
                userInput = Int32.Parse(Console.ReadLine());
                if(!oneToTen.Contains<int>(userInput))
                {
                    throw new FormatException();
                }
                Console.WriteLine($"You searched for {userInput.ToString()}, the bisect method returned {Bisect(userInput, oneToTen)}");
            }
            catch(FormatException)
            {
                Console.WriteLine("You must enter a valid integer from 1-10");
            }

            // Player guess number

            /*
            Random rand = new Random();
            int chosenNumber = rand.Next(1, 1001);
            Console.WriteLine("Guess the number from 1-1000");
            int userGuess = Int32.Parse(Console.ReadLine());
            int guessCount = 0;
            while(userGuess != chosenNumber)
            {
                guessCount++;
                {
                    Console.Clear();
                    Console.WriteLine("Your guess was too low\nTry again");
                    userGuess = Int32.Parse(Console.ReadLine());
                }
                if (userGuess > chosenNumber)
                {
                    Console.Clear();
                    Console.WriteLine("Your guess was too high\nTry again");
                    userGuess = Int32.Parse(Console.ReadLine());
                }
            }
            Console.Clear();
            Console.WriteLine($"You got it in {guessCount} tries!");
            */


            // Computer guess number

            /*
            Console.WriteLine("Choose a number from 1-100");
            int chosenNumber = Int32.Parse(Console.ReadLine());
            int[] oneToHundred = Enumerable.Range(1, 100).ToArray();
            Bisect(chosenNumber, oneToHundred);
            Console.Clear();
            Console.WriteLine($"The computer got it in {computerGuesses} tries!");
            */
        }
    }
}
