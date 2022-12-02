using Xunit;

namespace Day2;

public class Tests
{
    [Fact]
    public void FinalTest()
    {
        var input = File.ReadAllLines("input.txt");
        var score = input.Sum(Game.CalcScore);
        Assert.Equal(13193, score);
    }
    
    [Theory]
    [InlineData("A Y", 4)]
    [InlineData("B X", 1)]
    [InlineData("C Z", 7)]
    public void CalcGameScoreTest(string input, int expectedResult)
    {
        var result = Game.CalcScore(input);
        Assert.Equal(expectedResult, result);
    }
}
