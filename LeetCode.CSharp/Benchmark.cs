namespace LeetCode.CSharp;

[Config(typeof(BenchmarkConfig))]
public abstract class Benchmark
{
    protected int Int1 { get; set; }
    protected int Int2 { get; set; }

    protected int[] IntArray1 { get; set; } = Array.Empty<int>();
    protected int[] IntArray2 { get; set; } = Array.Empty<int>();
    protected int[][] IntArrayMulti1 { get; set; } = Array.Empty<int[]>();
    protected int?[] IntArrayNullable { get; set; } = Array.Empty<int?>();

    protected ListNode ListNode1 { get; set; } = new();
    protected ListNode ListNode2 { get; set; } = new();

    protected string String1 { get; set; } = string.Empty;
    protected string String2 { get; set; } = string.Empty;

    protected TreeNode TreeNode1 { get; set; } = new();
    protected TreeNode TreeNode2 { get; set; } = new();

    protected static readonly Random Random = new(42);

    /// <summary>
    /// Build a pseudo random string
    /// </summary>
    /// <remarks>
    /// <paramref name="frequencyOfSpace"/> allows space character to be injected
    /// 0 space uses a-z so 26 chars, so word is entire length of string for given size
    /// 1 space gives ~1 in 27 chance of being space, so average word length of ~27
    /// 2 space gives ~2 in 28 chance of being space, so average word length of ~14
    /// etc.
    /// </remarks>
    /// <param name="size">The size of the string to return</param>
    /// <param name="frequencyOfSpace">How frequently should space occur</param>
    /// <returns>Pseudo random string</returns>
    protected static string BuildPseudoRandomString(int size, int frequencyOfSpace = 0)
    {
        var stringBuilder = new StringBuilder(size);
        var range = 26 + frequencyOfSpace;
        var previous = char.MinValue;

        for (var i = 0; i < size; i++)
        {
            // Avoid double spaces by checking the previously generated character
            var next = previous == ' ' ? Random.Next(0, 26) : Random.Next(0, range);

            // Any character past z is considered a space
            var value = next >= 26 ? ' ' : (char)('a' + next);
            stringBuilder.Append(value);

            previous = value;
        }

        return stringBuilder.ToString();
    }
}
