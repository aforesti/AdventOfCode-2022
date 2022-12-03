using Xunit;

namespace Day03;

public class Tests
{
    [Theory]
    [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp", "p")]
    [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", "L")]
    [InlineData("PmmdzqPrVvPwwTWBwg", "P")]
    [InlineData("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", "v")]
    [InlineData("ttgJtRGJQctTZtZT", "t")]
    [InlineData("CrZsJsPPZsGzwwsLwLmpwMDw", "s")]
    public void ShouldFindCommonItemInTheRuckSack(string items, string commonItem)
    {
        var result = RuckSack.FindCommonItem(items);
        
        Assert.Equal(commonItem, result);
    }
    
    [Theory]
    [InlineData("p", 16)]
    [InlineData("L", 38)]
    [InlineData("P", 42)]
    [InlineData("v", 22)]
    [InlineData("t", 20)]
    [InlineData("s", 19)]
    public void ShouldGetThePriorityOfTheCommonItemInTheRuckSack(string commonItem, int priority)
    {
        var result = RuckSack.GetPriority(commonItem);
        
        Assert.Equal(priority, result);
    }
    
    [Fact]
    public void ShouldGetTheTotalPriorityOfTheRuckSack()
    {
        var input = File.ReadAllLines("input.txt");
        var result = RuckSack.GetTotalPriority(input);
        
        Assert.Equal(7826, result);
    }
    
    
    [Theory]
    [InlineData(new[] {"vJrwpWtwJgWrhcsFMMfFFhFp", "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", "PmmdzqPrVvPwwTWBwg"}, "r")]
    [InlineData(new[] {"wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", "ttgJtRGJQctTZtZT", "CrZsJsPPZsGzwwsLwLmpwMDw"}, "Z")]
    public void ShouldFindElfBadgeInTheRuckSack(string[] items, string badge)
    {
        var result = RuckSack.FindBadge(items);
        
        Assert.Equal(badge, result);
    }
    
    [Fact]
    public void ShouldGetTheTotalPriorityOfTheRuckSackWithElfBadge()
    {
        var input = File.ReadAllLines("input.txt");
        var result = RuckSack.GetTotalPriorityWithBadge(input);
        
        Assert.Equal(2577, result);
    }
}
