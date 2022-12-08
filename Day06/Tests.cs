namespace Day06;

public class Tests
{
    [Theory]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    public void GetStartOfPackageMarkerTest(string input, int expected)
    {
        var result = GetMarker(input, 4);
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 23)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
    public void GetStartOfMessageMarkerTest(string input, int expected)
    {
        var result = GetMarker(input, 14);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SolveTest()
    {
        var input = File.ReadAllText("input.txt");
        var packageStartMark = GetMarker(input, 4);
        Assert.Equal(1287, packageStartMark);
        
        var messageStartMark = GetMarker(input, 14);
        Assert.Equal(3716, messageStartMark);
    }
    
    private int GetMarker(string input, int numOfDistinctChars)
    {
        for (int i = 0; i < input.Length; i++)
        {
            var isMark = input[i..(i + numOfDistinctChars)].ToCharArray().Distinct().Count() == numOfDistinctChars;
            if (isMark)
            {
                return i + numOfDistinctChars;
            }
        }
        throw new Exception("no marker found");
    }


}
