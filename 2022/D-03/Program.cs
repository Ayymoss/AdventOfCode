namespace AdventOfCode;

public static class Program
{
    private static int CharacterToPriority(char c) => (int)c switch
    {
        >= 97 => c - 96,
        >= 65 => c - 64 + 26,
    };

    public static void Main()
    {
        var fileLines = File.ReadAllLines("C:\\TEMP\\input.txt");

        var elfCollection = new List<List<string>>();
        var elfGroup = new List<string>();
        elfCollection.Add(elfGroup);

        var tallyPartOne = 0;
        var tallyPartTwo = 0;

        // Sort into 3
        foreach (var line in fileLines)
        {
            if (elfGroup.Count != 3)
            {
                elfGroup.Add(line);
            }
            else
            {
                elfGroup = new List<string> {line};
                elfCollection.Add(elfGroup);
            }
        }

        foreach (var elfG in elfCollection)
        {
            tallyPartOne += (from elf in elfG
                let middle = elf.Length / 2
                let partOne = elf[..middle]
                let partTwo = elf.Substring(middle, middle)
                select partOne.Intersect(partTwo)
                into commonCharacters
                select commonCharacters.Sum(CharacterToPriority)).Sum();

            // This would fail if the group size was less than 3. In the AoC example, it is 300 strings, divisible by 3.
            if (elfG.Count != 3) throw new Exception("There is a group with less than 3 strings");
            var groupPriority = elfG[0].Intersect(elfG[1]).Intersect(elfG[2]).FirstOrDefault();
            
            tallyPartTwo += CharacterToPriority(groupPriority);
        }

        Console.WriteLine($"Part One: {tallyPartOne} - Part Two: {tallyPartTwo}");
    }
}
