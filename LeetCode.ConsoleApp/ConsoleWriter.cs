namespace LeetCode.ConsoleApp;

internal static class ConsoleWriter
{
    public static void WriteHeader(bool appendLine = false)
    {
        const string header =
@"    __                __   ______            __
   / /   ___   ___   / /_ / ____/____   ____/ /___
  / /   / _ \ / _ \ / __// /    / __ \ / __  // _ \
 / /___/  __//  __// /_ / /___ / /_/ // /_/ //  __/
/_____/\___/ \___/ \__/ \____/ \____/ \__,_/ \___/";

        var output = MakeRainbow(header);

        if (appendLine)
        {
            output.AppendLine();
        }

        Console.Write(output);
    }

    /// <summary>
    /// Output <paramref name="text"/> to console after converting to a colourful rainbow pattern.
    /// </summary>
    /// <remarks>
    /// Converted with thanks from: https://github.com/andot/lolcat/blob/master/Out-Rainbow.psm1
    /// </remarks>
    private static StringBuilder MakeRainbow(string text, double spread = 3, double frequency = .1)
    {
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

        return output;
    }
}
