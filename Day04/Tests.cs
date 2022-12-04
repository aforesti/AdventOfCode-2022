global using Xunit;

namespace Day04;

public class Tests
{
    [Theory]
    [InlineData("2-4,6-8", false)]
    [InlineData("2-3,4-5", false)]
    [InlineData("5-7,7-9", false)]
    [InlineData("2-8,3-7", true)]
    [InlineData("6-6,4-6", true)]
    [InlineData("2-6,4-8", false)]
    public void FullOverlappingWorkTest(string input, bool expected)
    {
        var result = FullOverlappingWork(input);
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData("2-4,6-8", false)]
    [InlineData("2-3,4-5", false)]
    [InlineData("5-7,7-9", true)]
    [InlineData("2-8,3-7", true)]
    [InlineData("6-6,4-6", true)]
    [InlineData("2-6,4-8", true)]
    public void OverlappingWorkTest(string input, bool expected)
    {
        var result = OverlappingWork(input);
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void Part1()
    {
        var input = File.ReadAllLines("input.txt");
        var count = input.Count(FullOverlappingWork);

        Assert.Equal(542, count);
    }
    
    [Fact]
    public void Part2()
    {
        var input = File.ReadAllLines("input.txt");
        var count = input.Count(OverlappingWork);

        Assert.Equal(900, count);
    }
    
    private static bool FullOverlappingWork(string input)
    {
        var (firstElf, secondElf) = GetRanges(input);
        return firstElf.All(x => secondElf.Contains(x)) || secondElf.All(x => firstElf.Contains(x));
    }
    
    private static bool OverlappingWork(string input)
    {
        var (firstElf, secondElf) = GetRanges(input);
        return firstElf.Intersect(secondElf).Any();
    }
    
    private static (int[] firstElf, int[] secondElf) GetRanges(string input)
    {
        var ranges = input.Split(',').Select(x => x.Split('-').Select(int.Parse).ToArray()).ToArray();
        var firstElf = Enumerable.Range(ranges[0][0], ranges[0][1] - ranges[0][0] + 1).ToArray();
        var secondElf = Enumerable.Range(ranges[1][0], ranges[1][1] - ranges[1][0] + 1).ToArray();
        return (firstElf, secondElf);
    }
}
