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
    
    public static string FindBadge(string[] items)
    {
        if (items.Length != 3)
            throw new Exception("Not valid elf group");

        return items.SelectMany(x => x.ToCharArray()).First(c => items[0].Contains(c) && items[1].Contains(c) && items[2].Contains(c)).ToString();
    }
    
    public static int GetTotalPriorityWithBadge(string[] input)
    {
        var totalPriority = 0;
        // 3 items per group
        for (var i = 0; i < input.Length; i += 3)
        {
            var group = input[i..(i + 3)];
            var badge = FindBadge(group);
            var priority = GetPriority(badge);
            totalPriority += priority;
        }
        return totalPriority;
    }
}
