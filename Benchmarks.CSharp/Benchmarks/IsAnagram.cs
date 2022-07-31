namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void IsAnagram()
    {
        // ReSharper disable once StringLiteralTypo
        Challenge.IsAnagram("anagram", "nagaram");
        Challenge.IsAnagram("rat", "car");
    }
}