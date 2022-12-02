namespace Day2;

public static class Game
{
    public enum GameMove { Rock = 1, Paper = 2, Scissors = 3 }
    public enum GameResult { Win = 6, Draw = 3, Loss = 0 }
    
    public static int CalcScore(string input)
    {
        var player1Move = GetMove(input, 0);
        var player2Move = GetMove(input, 1);
        var gameResult = CalcGameResult(player1Move, player2Move);
        return (int)gameResult + (int)player2Move;
    }
    
    private static GameMove StrToMove(string c)
    {
        return c switch
        {
            "A" or "X" => GameMove.Rock,
            "B" or "Y" => GameMove.Paper,
            "C" or "Z" => GameMove.Scissors,
            _ => throw new ArgumentException($"Invalid move: {c}"),
        };
    }
    
    public static GameMove GetMove(string input, int player)
    {
        var moves = input.Split(' ');
        return StrToMove(moves[player]);
    }
    
    public static GameResult CalcGameResult(GameMove player1, GameMove player2)
    {
        if (player1 == player2)
            return GameResult.Draw;
        
        return player2 switch
        {
            GameMove.Paper => player1 == GameMove.Rock ? GameResult.Win : GameResult.Loss,
            GameMove.Rock => player1 == GameMove.Scissors ? GameResult.Win : GameResult.Loss,
            GameMove.Scissors => player1 == GameMove.Paper ? GameResult.Win : GameResult.Loss,
            _ => throw new ArgumentOutOfRangeException(nameof(player2), player2, null),
        };
    }
}