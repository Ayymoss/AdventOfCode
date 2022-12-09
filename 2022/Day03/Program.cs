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
        var pairFound = false;

        foreach (var line in fileLines)
        {
            var middle = line.Length / 2;
            var partOne = line.Substring(0, middle);
            var partTwo = line.Substring(middle, middle);

            for (var i = 0; i < middle; i++)
            {
                if (pairFound) continue;
                for (var j = 0; j < middle; j++)
                {
                    if (pairFound) continue;
                    if (partOne[i] != partTwo[j]) continue;

                    tally += CharacterToPriority(partOne[i]);
                    pairFound = true;
                }
            }

            pairFound = false;
        }

        Console.WriteLine(tally);
    }
}
