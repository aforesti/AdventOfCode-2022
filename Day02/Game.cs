namespace Day2;

public static class Game
{
    private enum GameMove { Rock = 1, Paper = 2, Scissors = 3 }
    private enum GameResult { Win = 6, Draw = 3, Loss = 0 }

    private static GameResult GetGameResult(char input) => input switch
    {
        'X' => GameResult.Loss,
        'Y' => GameResult.Draw,
        'Z' => GameResult.Win,
        _ => throw new ArgumentException("Invalid input"),
    };

    private static GameMove GetGameMove(char input) => input switch
    {
        'A' => GameMove.Rock,
        'B' => GameMove.Paper,
        'C' => GameMove.Scissors,
        _ => throw new ArgumentException($"Invalid move: {input}"),
    };

    public static int GetGameScore(string input)
    {
        var player1Move = GetGameMove(input[0]);
        var gameResult = GetGameResult(input[2]);
        
        GameMove player2Move;
        if (gameResult == GameResult.Draw)
            player2Move = player1Move;
        else
        {
            player2Move = player1Move switch
            {
                GameMove.Paper => gameResult == GameResult.Loss ? GameMove.Rock : GameMove.Scissors,
                GameMove.Rock => gameResult == GameResult.Loss ? GameMove.Scissors : GameMove.Paper,
                GameMove.Scissors => gameResult == GameResult.Loss ? GameMove.Paper : GameMove.Rock,
                _ => throw new ArgumentOutOfRangeException($"Invalid move: {player1Move}"),
            };
        }
        return (int)player2Move + (int)gameResult;
    }
}