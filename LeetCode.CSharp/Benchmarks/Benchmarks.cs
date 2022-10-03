namespace LeetCode.CSharp;

[Config(typeof(RuntimeConfig))]
public partial class Benchmarks
{
    private int Int1 { get; set; }

    private int[] IntArray1 { get; set; } = Array.Empty<int>();
    private int[] IntArray2 { get; set; } = Array.Empty<int>();
    private int[][] IntArrayMulti { get; set; } = Array.Empty<int[]>();
    private int?[] IntArrayNullable { get; set; } = Array.Empty<int?>();

    private ListNode ListNode1 { get; set; } = new();
    private ListNode ListNode2 { get; set; } = new();

    private string String1 { get; set; } = string.Empty;
    private string String2 { get; set; } = string.Empty;

    private TreeNode TreeNode1 { get; set; } = new();
    private TreeNode TreeNode2 { get; set; } = new();

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
    private static string BuildPseudoRandomString(int size, int frequencyOfSpace = 0)
    {
        var random = new Random(42);
        var stringBuilder = new StringBuilder(size);
        var range = 26 + frequencyOfSpace;
        var previous = char.MinValue;

        for (var i = 0; i < size; i++)
        {
            // Avoid double spaces by checking the previously generated character
            var next = previous == ' ' ? random.Next(0, 26) : random.Next(0, range);

            // Any character past z is considered a space
            var value = next >= 26 ? ' ' : (char)('a' + next);
            stringBuilder.Append(value);

            previous = value;
        }

        return stringBuilder.ToString();
    }
}
