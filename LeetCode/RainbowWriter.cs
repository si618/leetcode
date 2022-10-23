namespace LeetCode;

/// <summary>
/// Create rainbow text for standard ANSI or https://spectreconsole.net/ markup.
/// </summary>
/// <remarks>
/// Converted with thanks from: https://github.com/andot/lolcat/blob/master/Out-Rainbow.psm1
/// </remarks>
public class RainbowWriter
{
    public RainbowWriter(
        double spread = 3,
        double frequency = .1,
        int? seed = null,
        bool useSpectreMarkup = false)
    {
        Spread = spread;
        Frequency = frequency;
        Random = seed.HasValue ? new Random(seed.Value) : new Random();
        UseSpectreMarkup = useSpectreMarkup;
    }

    public double Spread { get; set; }
    public double Frequency { get; set; }

    private Random Random { get; }
    private bool UseSpectreMarkup { get; }

    private const char Escape = (char)27;
    private const string AnsiFormat = "{0}[38;2;{1};{2};{3};1m{4}{0}[0m";
    private const string SpectreFormat = "[rgb({0},{1},{2})]{3}[/]";

    /// <summary>
    /// Convert <paramref name="text"/> to a rainbow.
    /// </summary>
    public string Write(string text)
    {
        var seed = Random.Next(255);
        var lines = text.ReplaceLineEndings().Split(Environment.NewLine);
        var output = new StringBuilder();

        foreach (var line in lines)
        {
            seed++;

            var length = line.Length;
            if (length == 0 && output.Length > 0)
            {
                output.AppendLine();
                continue;
            }

            var s = seed;

            for (var i = 0; i < length; i++)
            {
                var n = s + i / Spread;
                var c = line[i];

                if (i < length - 1 && char.IsSurrogatePair(c, line[i + 1]))
                {
                    c += line[i + 1];
                    i++;
                }

                var red = (int)(Math.Sin(Frequency * n) * 127 + 128);
                var green = (int)(Math.Sin(Frequency * n + 2 * Math.PI / 3) * 127 + 128);
                var blue = (int)(Math.Sin(Frequency * n + 4 * Math.PI / 3) * 127 + 128);

                if (UseSpectreMarkup)
                {
                    output.AppendFormat(SpectreFormat, red, green, blue, c);
                }
                else
                {
                    output.AppendFormat(AnsiFormat, Escape, red, green, blue, c);
                }
            }

            output.AppendLine();
        }

        return output.ToString();
    }
}
