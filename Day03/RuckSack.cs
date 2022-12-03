namespace Day03;

public static class RuckSack
{
    public static string FindCommonItem(string items)
    {
        try
        {
            var firstCompartment = items[..(items.Length / 2)];
            var secondCompartment = items[(items.Length / 2)..];
            var commonItem = firstCompartment.First(i => secondCompartment.Contains(i));
            return commonItem.ToString();
        }
        catch (Exception)
        {
            Console.WriteLine($"{items} has no common item");
            throw;
        }
    }

    public static int GetPriority(string commonItem)
    {
        if (commonItem[0] > 96)
            return commonItem[0] - 96;
        
        return commonItem[0] - 64 + 26;
    }
    
    public static int GetTotalPriority(string[] input)
    {
        var totalPriority = 0;
        foreach (var items in input)
        {
            var commonItem = FindCommonItem(items);
            var priority = GetPriority(commonItem);
            totalPriority += priority;
        }

        return totalPriority;
    }
}
