using System.Text.RegularExpressions;

namespace AdventOfCode;

public class DayTwo
{
    public static void Main()
    {
        var lines = File.ReadAllLines("C:\\TEMP\\input.txt");
        var regex = new Regex(@"^(\w) (\w)$");
        var tally = 0;

        foreach (var line in lines)
        {
            var match = regex.Match(line);
            var opponent = match.Groups[1].Value;
            var me = match.Groups[2].Value;

            switch (opponent)
            {
                // WIN CONDITION
                case "C" when me == "X":
                    tally += 7;
                    break;
                case "A" when me == "Y":
                    tally += 8;
                    break;
                case "B" when me == "Z":
                    tally += 9;
                    break;

                // LOSS CONDITION
                case "B" when me == "X":
                    tally += 1;
                    break;
                case "C" when me == "Y":
                    tally += 2;
                    break;
                case "A" when me == "Z":
                    tally += 3;
                    break;

                // DRAW CONDITION
                case "A" when me == "X":
                    tally += 4;
                    break;
                case "B" when me == "Y":
                    tally += 5;
                    break;
                case "C" when me == "Z":
                    tally += 6;
                    break;
            }
        }

        Console.WriteLine(tally);
    }
}
