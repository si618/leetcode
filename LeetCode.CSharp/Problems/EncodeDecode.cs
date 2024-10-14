namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    private const char EncodeDecodeDelimiter = ':';

    [LeetCode("Encode and Decode Strings (Encode)",
        Difficulty.Medium,
        Category.ArraysAndHashing,
        "https://www.youtube.com/watch?v=B1k_sxOSgv8")]
    public static string Encode(IEnumerable<string> strs) =>
        string.Concat(strs.SelectMany(s => $"{s.Length}{EncodeDecodeDelimiter}{s}"));

    [LeetCode("Encode and Decode Strings (Decode)",
        Difficulty.Medium,
        Category.ArraysAndHashing,
        "https://www.youtube.com/watch?v=B1k_sxOSgv8")]
    public static IEnumerable<string> Decode(string str)
    {
        var result = new List<string>();
        var i = 0;

        while (i < str.Length)
        {
            var j = i;

            // Find length of encoded string
            while (str[j] != EncodeDecodeDelimiter)
            {
                j++;
            }

            // Assumes string is correctly encoded
            var length = int.Parse(str.AsSpan(i, j - i));

            // Move past delimiter
            j++;

            // Extract substring
            result.Add(str.AsSpan(j, length).ToString());

            // Move to next encoded string or end
            i = j + length;
        }

        return result;
    }

    [Theory]
    [InlineData(new string[] { }, "")]
    [InlineData(new[] { "" }, "0:")]
    [InlineData(new[] { "abc" }, "3:abc")]
    [InlineData(new[] { "abc", "c : a" }, "3:abc5:c : a")]
    public void EncodeTest(string[] strs, string expected) => Encode(strs).Should().Be(expected);

    [Theory]
    [InlineData("", new string[] { })]
    [InlineData("0:", new[] { "" })]
    [InlineData("3:abc", new[] { "abc" })]
    [InlineData("3:abc5:c : a", new[] { "abc", "c : a" })]
    public void DecodeTest(string str, string[] expected) => Decode(str).Should().Equal(expected);
}
