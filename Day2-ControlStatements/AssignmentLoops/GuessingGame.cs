using System;

/// <summary>
/// Class for playing a guessing game.
/// </summary>
public class GuessingGame
{
    /// <summary>
    /// Plays a guessing game where the user guesses a secret number using do-while loop.
    /// </summary>
    /// <param name="secretNumber">The secret number to guess.</param>
    public static void PlayGame(int secretNumber)
    {
        int guess;
        do
        {
            Console.Write("Guess the number: ");
            guess = Convert.ToInt32(Console.ReadLine());
            if (guess < secretNumber)
            {
                Console.WriteLine("Too low!");
            }
            else if (guess > secretNumber)
            {
                Console.WriteLine("Too high!");
            }
        } while (guess != secretNumber);
        Console.WriteLine("Correct! You guessed it.");
    }
}