using System;

/// <summary>
/// Class for Rock Paper Scissors game logic.
/// </summary>
public class RockPaperScissors
{
    /// <summary>
    /// Determines the winner of a Rock-Paper-Scissors game using nested conditionals.
    /// </summary>
    /// <param name="player1">Choice of player 1: "rock", "paper", or "scissors".</param>
    /// <param name="player2">Choice of player 2: "rock", "paper", or "scissors".</param>
    /// <returns>String indicating the result: "Player 1 wins", "Player 2 wins", or "Draw".</returns>
    public static string DetermineWinner(string player1, string player2)
    {
        player1 = player1.ToLower();
        player2 = player2.ToLower();

        if (player1 == player2)
        {
            return "Draw";
        }
        else if (player1 == "rock")
        {
            if (player2 == "scissors")
                return "Player 1 wins";
            else // paper
                return "Player 2 wins";
        }
        else if (player1 == "paper")
        {
            if (player2 == "rock")
                return "Player 1 wins";
            else // scissors
                return "Player 2 wins";
        }
        else if (player1 == "scissors")
        {
            if (player2 == "paper")
                return "Player 1 wins";
            else // rock
                return "Player 2 wins";
        }
        else
        {
            return "Invalid input";
        }
    }
}