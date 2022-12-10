namespace AdventOfCode;

public static class Program
{
    public static void Main()
    {
        var input = File.ReadAllLines("C:\\TEMP\\input.txt");
        var elfDict = new Dictionary<int, Elf>();
        var index = 1;
        foreach (var line in input)
        {
            var elf = elfDict.ContainsKey(index);

            if (!elf) elfDict.Add(index, new Elf());

            if (line is not "") elfDict[index].Foods.Add(int.Parse(line));
            else index++;
        }

        var highestIndex = 0;
        var highestCalories = 0;
        foreach (var elf in elfDict)
        {
            var total = elf.Value.Foods.Sum();
            elf.Value.Calories = total;

            if (highestCalories >= total) continue;

            highestCalories = total;
            highestIndex = elf.Key;
        }

        var ordered = elfDict.OrderByDescending(elf => elf.Value.Calories).ToList();
        var topThree = ordered.Take(3).ToList();
        var topThreeTotal = topThree.Sum(elf => elf.Value.Calories);

        Console.WriteLine($"Highest calories: {highestCalories} - " +
                          $"Elf: {highestIndex} - " +
                          $"Top three total: {topThreeTotal}");
    }
}

public class Elf
{
    public List<int> Foods { get; } = new();
    public int Calories { get; set; }
}
