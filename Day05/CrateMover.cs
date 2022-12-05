using System.Text.RegularExpressions;

namespace Day05;

public class CrateMover
{
    private readonly List<Stack<char>> _stacks;
    internal record Values(int Qty, int Origin, int Destination);
    public CrateMover(List<Stack<char>>? stacks)
    {
        _stacks = stacks ?? new()
        {
            new(new []{ 'S', 'T', 'H', 'F', 'W', 'R'}),            // 1
            new(new []{ 'S', 'G', 'D', 'Q', 'W' }),                // 2
            new(new []{ 'B', 'T', 'W' }),                          // 3
            new(new []{ 'D', 'R', 'W', 'T', 'N', 'Q', 'Z', 'J' }), // 4
            new(new []{ 'F', 'B', 'H', 'G', 'L', 'V', 'T', 'Z' }), // 5
            new(new []{ 'L', 'P', 'T', 'C', 'V', 'B', 'S', 'G' }), // 6
            new(new []{ 'Z', 'B', 'R', 'T', 'W', 'G', 'P' }),      // 7
            new(new []{ 'N', 'G', 'M', 'T', 'C', 'J', 'R' }),      // 8
            new(new []{ 'L', 'G', 'B', 'W' }),                     // 9
        };
    }
    
    internal static Values ParseInput(string input)
    {
        var values = Regex.Match(input, @"move (\d+) from (\d+) to (\d+)").Groups.Values.Skip(1).Select(x => int.Parse(x.Value)).ToArray();
        return new Values(values[0], values[1], values[2]);
    }

    private void Move(Values values)
    {
        var origin = _stacks[values.Origin - 1];
        var destination = _stacks[values.Destination - 1];
        for (var i = 0; i < values.Qty; i++)
        {
            destination.Push(origin.Pop());
        }
    }
    
    public string RunCrateMover9000(IEnumerable<string> input)
    {
        var values = input.Select(ParseInput);
        foreach (var value in values)
        {
            Move(value);
        } 
        return string.Join("", _stacks.Select(x => x.Peek().ToString()).ToArray());
    }
    
    public string RunCrateMover9001(IEnumerable<string> input)
    {
        foreach (var line in input)
        {
            Move2(ParseInput(line));
        }
        return string.Join("", _stacks.Select(x => x.Peek()).ToArray());
    }

    private void Move2(Values values)
    {
        var origin = _stacks[values.Origin - 1];
        var destination = _stacks[values.Destination - 1];
        var qty = values.Qty;
        var tempStack = new Stack<char>();
        for (var i = 0; i < qty; i++)
        {
            tempStack.Push(origin.Pop());
        }
        for (var i = 0; i < qty; i++)
        {
            destination.Push(tempStack.Pop());
        }
    }
}
