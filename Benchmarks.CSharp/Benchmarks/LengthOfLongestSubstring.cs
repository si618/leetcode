namespace LeetCode;

public partial class CSharpBenchmarks
{
    [GlobalSetup(Target = nameof(LengthOfLongestSubstring))]
    public void LengthOfLongestSubstringSetup()
    {
        _string1 = string.Join("", Enumerable.Range(1, 1_000_000).Select(i => i.ToString()));
    }

    [Benchmark]
    public int LengthOfLongestSubstring()
    {
        return Problem.LengthOfLongestSubstring(_string1);
    }
}