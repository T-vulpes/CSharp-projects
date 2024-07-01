using System;
using System.Collections.Generic;

namespace basic_hangmanGame
{
    class Program
    {
        static void Main()
        {
            List<string> words = new List<string>
            {
                // Animals
                "elephant", "giraffe", "kangaroo", "leopard", "penguin", "alligator", "crocodile",
                "flamingo", "hippopotamus", "jaguar", "ostrich", "rhinoceros", "squirrel", "zebra",
                // Countries
                "argentina", "brazil", "canada", "denmark", "egypt", "france", "germany",
                "hungary", "india", "japan", "kenya", "luxembourg", "mexico", "netherlands",
                "portugal", "qatar", "romania", "sweden", "turkey", "uruguay", "vietnam"
            };

            Random random = new Random();
            string selectedWord = words[random.Next(words.Count)];
            string validLetters = "abcdefghijklmnopqrstuvwxyz";
            int totalGuesses = 6; 
            string madeGuesses = "";


            List<string> HANGMAN_GRAPHICS = new List<string>
            {
                @"
--------
|    |
|
|
|
|
",
                @"
--------
|    |
|    O
|
|
|
",
                @"
--------
|    |
|    O
|    |
|
|
",
                @"
--------
|    |
|    O
|   /|
|
|
",
                @"
--------
|    |
|    O
|   /|\
|
|
",
                @"
--------
|    |
|    O
|   /|\
|   /
|
",
                @"
--------
|    |
|    O
|   /|\
|   / \
|
"
            };

            Console.WriteLine("Welcome to Hangman Game!");

            while (totalGuesses > 0)
            {
                string realWord = "";
                foreach (char letter in selectedWord)
                {
                    if (madeGuesses.Contains(letter.ToString())) 
                    {
                        realWord += letter;
                    }
                    else
                    {
                        realWord += "_ ";
                    }
                }

                if (realWord.Replace(" ", "") == selectedWord)
                {
                    Console.WriteLine(realWord);
                    Console.WriteLine("Congratulations, you won!");
                    break;
                }

                Console.WriteLine(HANGMAN_GRAPHICS[6 - totalGuesses]);
                Console.WriteLine("Guess the word: " + realWord);
                Console.WriteLine("Remaining guesses: " + totalGuesses);
                Console.Write("Guess a letter: ");
                string guess = Console.ReadLine().ToLower();

                if (validLetters.Contains(guess) && guess.Length == 1)
                {
                    madeGuesses += guess;
                    if (!selectedWord.Contains(guess))
                    {
                        totalGuesses--;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid letter...");
                }
            }

            if (totalGuesses == 0)
            {
                Console.WriteLine("Unfortunately, you lost. The correct word was: " + selectedWord);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
}
