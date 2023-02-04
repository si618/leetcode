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

    [Fact]
    public void EncodeTest()
    {
        var ex1 = new List<string> { "abc" };
        var ex2 = new List<string> { "abc", "c : a" };

        Encode(Array.Empty<string>()).Should().Be(string.Empty);
        Encode(ex1).Should().Be("3:abc");
        Encode(ex2).Should().Be("3:abc5:c : a");
    }

    [Fact]
    public void DecodeTest()
    {
        const string ex1 = "3:abc";
        const string ex2 = "3:abc5:c : a";

        Decode(string.Empty).Should().BeEmpty();
        Decode(ex1).Should().Equal("abc");
        Decode(ex2).Should().Equal("abc", "c : a");
    }
}
