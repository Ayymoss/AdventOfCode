using System.Text.RegularExpressions;

namespace AdventOfCode;

public static class Program
{
    public static void Main()
    {
        const Mode mode = Mode.PartTwo;
        var lines = File.ReadAllLines("C:\\TEMP\\input.txt");
        var regex = new Regex(@"^(\w) (\w)$");
        var tally = 0;

        foreach (var line in lines)
        {
            var match = regex.Match(line);
            var opponent = match.Groups[1].Value;
            var me = match.Groups[2].Value;

            switch (mode)
            {
                case Mode.PartOne:
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

                    break;

                case Mode.PartTwo:
                    switch (me)
                    {
                        // Draw
                        case "Y":
                            switch (opponent)
                            {
                                case "A":
                                    tally += 1 + 3;
                                    break;
                                case "B":
                                    tally += 2 + 3;
                                    break;
                                case "C":
                                    tally += 3 + 3;
                                    break;
                            }

                            break;

                        // Lose
                        case "X":
                            switch (opponent)
                            {
                                case "A":
                                    tally += 3;
                                    break;
                                case "B":
                                    tally += 1;
                                    break;
                                case "C":
                                    tally += 2;
                                    break;
                            }

                            break;

                        // Win
                        case "Z":
                            switch (opponent)
                            {
                                case "A":
                                    tally += 2 + 6;
                                    break;
                                case "B":
                                    tally += 3 + 6;
                                    break;
                                case "C":
                                    tally += 1 + 6;
                                    break;
                            }

                            break;
                    }

                    break;
            }
        }

        Console.WriteLine(tally);
    }
}

public enum Mode
{
    PartOne,
    PartTwo
}
