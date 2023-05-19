using System;
using System.IO;
using System.Threading;

class Hangman
{
    static void Main()
    {
        while (true)
        {
            GameStart();
            Console.WriteLine("Press Y to play again or N to exit: ");
            string choice = Console.ReadLine();
            if (choice != "Y" && choice!="y")
            {
                break;
            }
        }
        
    }

    private static void GameStart()
    {
        string word = ChooseWord();

        int numberOfLives = word.Length / 2 + 1;
        char[] currentWordState = new string('_', word.Length).ToCharArray();
        string allGuesses = "";

        //Game Loop
        while (true)
        {
            DrawingUI(numberOfLives, currentWordState, allGuesses);
            //Handle Input
            string guessInput = Console.ReadLine();
            guessInput = guessInput.ToLower();
            char guessLetter = new char();

            if (guessInput.Length > 1)
            {
                Console.Clear();
                Console.WriteLine("\aWrong input! You need to input a single letter.\nTry again in 1 second.");
                Thread.Sleep(2500);
            }
            else if (guessInput.Length == 1)
            {
                guessLetter = Convert.ToChar(guessInput);
                if (!Char.IsLetter(guessLetter))
                {
                    Console.Clear();
                    Console.WriteLine("\aWrong input! Input a proper letter. ");
                    Thread.Sleep(2500);
                    continue;
                }
            }
            bool isWrongGuess = true;

            isWrongGuess = ChangeLettersUIArray(word, currentWordState, guessLetter, isWrongGuess);

            numberOfLives = WrongGuessConditions(numberOfLives, allGuesses, guessLetter, isWrongGuess);

            allGuesses = allGuesses + guessLetter + " ";
            //Game Over
            if (numberOfLives <= 0)
            {
                Console.Clear();
                Console.WriteLine("\aGame over. The correct word was {0}", word);
                break;
            }

            //Winning
            string helper = new string(currentWordState);
            if (!helper.Contains("_"))
            {
                Console.Clear();
                Console.WriteLine("You won! The correct word is {0}", word);
                break;
            }
        }
    }

    private static int WrongGuessConditions(int numberOfLives, string allGuesses, char guessLetter, bool isWrongGuess)
    {
        if (isWrongGuess && !allGuesses.Contains(guessLetter.ToString()))
        {
            numberOfLives--;
        }

        return numberOfLives;
    }

    private static bool ChangeLettersUIArray(string word, char[] currentWordState, char guessLetter, bool isWrongGuess)
    {
        for (int i = 0; i < word.Length; i++)
        {
            if (word[i] == guessLetter)
            {
                currentWordState[i] = guessLetter;
                isWrongGuess = false;
            }
        }
        return isWrongGuess;
    }

    private static void DrawingUI(int numberOfLives, char[] currentWordState, string allGuesses)
    {
        Console.Clear();
        Console.Write("Current word is: ");
        for (int i = 0; i < currentWordState.Length; i++)
        {
            Console.Write("{0} ", currentWordState[i]);
        }

        Console.WriteLine();
        Console.WriteLine("Number of lives: {0}", numberOfLives);
        Console.WriteLine("Guessed Letters {0}", allGuesses);
        Console.Write("Please input a single letter here: ");
    }

    private static string ChooseWord()
    {
        string[] words = File.ReadAllLines(@"wordsEn.txt");
        Random rng = new Random();
        string word = "";

        while (word.Length <= 4)
        {
            int randomWordIndex = rng.Next(0, words.Length);
            word = words[randomWordIndex].ToLower();
        }

        return word;
    }
}

