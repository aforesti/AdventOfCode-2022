using System.Diagnostics;

namespace Day2;

public static class Game
{
    private enum GameMove { Rock = 1, Paper = 2, Scissors = 3 }
    private enum GameResult { Win = 6, Draw = 3, Loss = 0 }

    private static GameResult GetGameResult(char input)
    {
        return input switch
        {
            'X' => GameResult.Loss,
            'Y' => GameResult.Draw,
            'Z' => GameResult.Win,
            _ => throw new ArgumentException("Invalid input"),
        };
    }

    public static int CalcScore(string input)
    {
        var move = GetMove(input);
        var gameResult = GetGameResult(input[2]);
        return (int)gameResult + (int)move;
    }
    
    private static GameMove GetGameMove(char input)
    {
        return input switch
        {
            'A' => GameMove.Rock,
            'B' => GameMove.Paper,
            'C' => GameMove.Scissors,
            _ => throw new ArgumentException($"Invalid move: {input}"),
        };
    }

    private static GameMove GetMove(string input)
    {
        var player1Move = GetGameMove(input[0]);
        var gameResult = GetGameResult(input[2]);
        
        if (gameResult == GameResult.Draw)
        {
            return player1Move;
        }

        return player1Move switch
        {
            GameMove.Paper => gameResult == GameResult.Loss ? GameMove.Rock : GameMove.Scissors,
            GameMove.Rock => gameResult == GameResult.Loss ? GameMove.Scissors : GameMove.Paper,
            GameMove.Scissors => gameResult == GameResult.Loss ? GameMove.Paper : GameMove.Rock,
            _ => throw new ArgumentOutOfRangeException(),
        };
    }
}