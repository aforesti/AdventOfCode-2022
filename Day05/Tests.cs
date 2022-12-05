using Xunit;

namespace Day05;

public class Tests
{

    private readonly CrateMover _crateMover;
    public Tests()
    {
        var stacks = new List<Stack<char>>() 
        {
            new(new[] { 'Z', 'N' }),
            new(new[] { 'M', 'C', 'D', }),
            new(new[] { 'P' }),
        };
        _crateMover = new CrateMover(stacks);
    }
    
    [Fact]
    public void ParseInputTest()
    {
        var values = CrateMover.ParseInput("move 1 from 2 to 1");
        
        Assert.Equal(1, values.Qty);
        Assert.Equal(2, values.Origin);
        Assert.Equal(1, values.Destination);
    }
    
    private readonly IEnumerable<string> input = new []
    {
        "move 1 from 2 to 1",
        "move 3 from 1 to 3",
        "move 2 from 2 to 1",
        "move 1 from 1 to 2",
    };
    
    [Fact]
    public void MoveTestPart1()
    {
        var result = _crateMover.RunCrateMover9000(input);
        
        Assert.Equal("CMZ", result);
    }

    [Fact]
    public void MoveTestPart2()
    {
        var result = _crateMover.RunCrateMover9001(input);
        
        Assert.Equal("MCD", result);
    }

}
