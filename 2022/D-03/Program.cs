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
        var tally = 0;

        foreach (var line in fileLines)
        {
            var middle = line.Length / 2;
            var partOne = line.Substring(0, middle);
            var partTwo = line.Substring(middle, middle);
            var commonCharacters = partOne.Intersect(partTwo);

            foreach (var character in commonCharacters)
            {
                tally += CharacterToPriority(character);
            }
        }

        Console.WriteLine(tally);
    }
}
