// ReSharper disable once CheckNamespace
namespace LeetCode;

using BenchmarkDotNet.Attributes;

public partial class CSharpBenchmarks
{
    [Benchmark]
    public void IsAnagram()
    {
        // ReSharper disable once StringLiteralTypo
        Submission.IsAnagram("anagram", "nagaram");
        Submission.IsAnagram("rat", "car");
    }
}