var input = File.ReadAllText("input.txt");

var caloriesPerElf = input.Split(Environment.NewLine + Environment.NewLine)
    .Select(x => 
        x.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .Sum())
    .ToArray();

var answerPart1 = caloriesPerElf.Max();
var answerPart2 = caloriesPerElf.OrderDescending().Take(3).Sum();

Console.WriteLine($"Part 1: {answerPart1}"); //  66487
Console.WriteLine($"Part 2: {answerPart2}"); // 197301
