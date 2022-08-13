namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void IsAnagram()
    {
        // ReSharper disable once StringLiteralTypo
        Problem.IsAnagram("anagram", "nagaram");
        Problem.IsAnagram("rat", "car");
    }
}