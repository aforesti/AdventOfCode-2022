using Xunit;

namespace Day2;

public class Tests
{
    [Fact]
    public void FinalTest()
    {
        var input = File.ReadAllLines("input.txt");
        var score = input.Sum(Game.CalcScore);
        Assert.Equal(12586, score);
    }
    
    [Theory]
    [InlineData("A Y", Game.GameResult.Win)]
    [InlineData("A X", Game.GameResult.Draw)]
    [InlineData("A Z", Game.GameResult.Loss)]
    [InlineData("B Y", Game.GameResult.Draw)]
    [InlineData("B X", Game.GameResult.Loss)]
    [InlineData("B Z", Game.GameResult.Win)]
    [InlineData("C Y", Game.GameResult.Loss)]
    [InlineData("C X", Game.GameResult.Win)]
    [InlineData("C Z", Game.GameResult.Draw)]
    public void CalcGameResultTest(string input, Game.GameResult expectedResult)
    {
        var player1Move = Game.GetMove(input, 0);
        var player2Move = Game.GetMove(input, 1);
        var result = Game.CalcGameResult(player1Move, player2Move);
        Assert.Equal(expectedResult, result);
    }
    
    [Theory]
    [InlineData("A Y", 8)]
    [InlineData("B X", 1)]
    [InlineData("C Z", 6)]
    public void CalcGameScoreTest(string input, int expectedResult)
    {
        var result = Game.CalcScore(input);
        Assert.Equal(expectedResult, result);
    }
}
