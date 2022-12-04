namespace Day03;

public static class RuckSack
{
    public static string FindCommonItem(string items)
    {
        var firstCompartment = items[..(items.Length / 2)];
        var secondCompartment = items[(items.Length / 2)..];
        var commonItem = firstCompartment.First(i => secondCompartment.Contains(i));
        return commonItem.ToString();
    }

    public static int GetPriority(string commonItem) 
        => commonItem[0] > 96 ? commonItem[0] - 96 : commonItem[0] - 64 + 26;

    public static string FindBadge(string[] items)
        => items[0].Intersect(items[1]).Intersect(items[2]).First().ToString();
    
    public static int SolvePart1(IEnumerable<string> input) 
        => input.Select(FindCommonItem).Select(GetPriority).Sum();
    
    public static int SolvePart2(IEnumerable<string> input)
        => input.Chunk(3).Select(FindBadge).Select(GetPriority).Sum();
}
