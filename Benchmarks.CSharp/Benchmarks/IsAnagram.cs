namespace LeetCode;

public partial class CSharpBenchmarks
{
    [Benchmark]
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public void IsAnagram()
    {
        Problem.IsAnagram("anagram", "nagaram");
        Problem.IsAnagram("rat", "car");
    }
}