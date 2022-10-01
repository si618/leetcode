namespace LeetCode.ConsoleApp;

using System.Text;

public static class ConsoleWriter
{
    /// <summary>
    /// Output <paramref name="text"/> to console after converting to colourful rainbow.
    /// </summary>
    /// <remarks>
    /// Converted with thanks from: https://github.com/andot/lolcat/blob/master/Out-Rainbow.psm1
    /// </remarks>
    private static void WriteRainbow(string text)
    {
        const double spread = 3.0;
        const double frequency = .1;
        const char esc = (char)27;

        var random = new Random();
        var seed = random.Next(255);
        var lines = text.ReplaceLineEndings().Split(Environment.NewLine);
        var output = new StringBuilder();

        foreach (var line in lines)
        {
            seed++;

            var length = line.Length;
            if (length == 0)
            {
                output.AppendLine();
                continue;
            }

            var s = seed;

            for (var i = 0; i < length; i++)
            {
                var n = s + i / spread;
                var c = line[i];

                if (i < length - 1 && char.IsSurrogatePair(c, line[i + 1]))
                {
                    c += line[i + 1];
                    i++;
                }

                var red = (int)(Math.Sin(frequency * n) * 127 + 128);
                var green = (int)(Math.Sin(frequency * n + 2 * Math.PI / 3) * 127 + 128);
                var blue = (int)(Math.Sin(frequency * n + 4 * Math.PI / 3) * 127 + 128);

                output.Append($"{esc}[38;2;{red};{green};{blue};1m{c}{esc}[0m");
            }

            output.AppendLine();
        }

        Console.Write(output.ToString());
    }

    public static void WriteHeader()
    {
        const string header =
@"    __                __   ______            __
   / /   ___   ___   / /_ / ____/____   ____/ /___
  / /   / _ \ / _ \ / __// /    / __ \ / __  // _ \
 / /___/  __//  __// /_ / /___ / /_/ // /_/ //  __/
/_____/\___/ \___/ \__/ \____/ \____/ \__,_/ \___/
"; ;
        WriteRainbow(header);
        // var foreground = AnsiConsole.Foreground;
        // AnsiConsole.Foreground = Color.SpringGreen2;
        // AnsiConsole.WriteLine("    __                __   ______            __");
        // AnsiConsole.Foreground = Color.SpringGreen3_1;
        // AnsiConsole.WriteLine("   / /   ___   ___   / /_ / ____/____   ____/ /___");
        // AnsiConsole.Foreground = Color.Green3_1;
        // AnsiConsole.WriteLine(@"  / /   / _ \ / _ \ / __// /    / __ \ / __  // _ \");
        // AnsiConsole.Foreground = Color.SpringGreen3_1;
        // AnsiConsole.WriteLine(" / /___/  __//  __// /_ / /___ / /_/ // /_/ //  __/");
        // AnsiConsole.Foreground = Color.SpringGreen2;
        // AnsiConsole.WriteLine(@"/_____/\___/ \___/ \__/ \____/ \____/ \__,_/ \___/");
        // AnsiConsole.Foreground = foreground;
    }

    public static void WriteProblems()
    {
        AnsiConsole.WriteLine("Solved C# Problems");

        var countOfProblems = 0;
        var nl = Environment.NewLine;
        var benchmarks = Reflection.GetCSharpBenchmarks().ToArray();

        foreach (var category in Reflection.GetProblemsByCategory())
        {
            AnsiConsole.WriteLine($"{nl}{category.Key.Description()}{nl}");

            foreach (var problem in category.ToArray())
            {
                var missing = benchmarks.Contains(problem.Name)
                    ? string.Empty
                    : " * Missing Benchmark *";
                AnsiConsole.WriteLine($"  [{problem.Difficulty}] {problem.Description}");
            }

            countOfProblems += category.Count();
        }

        AnsiConsole.WriteLine($"{nl}Total Problems: {countOfProblems}{nl}");
    }

    public static void WriteProblemDetail(string name)
    {
        var problem = Reflection.GetProblem(name);
        if (problem is null)
        {
            AnsiConsole.WriteLine($"Unknown '{name}' Problem");
            return;
        }

        AnsiConsole.WriteLine($"Benchmark:    {problem.Name}");

        if (problem.Name != problem.Description)
        {
            AnsiConsole.WriteLine($"Description:  {problem.Description}");
        }

        AnsiConsole.WriteLine($"Difficulty:   {problem.Difficulty}");
        AnsiConsole.WriteLine($"Category:     {problem.Category.Description()}");

        if (problem.Link is not null)
        {
            AnsiConsole.WriteLine($"NeetCode:     {problem.Link}");
        }
    }
}
