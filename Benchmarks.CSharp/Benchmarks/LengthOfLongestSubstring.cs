namespace LeetCode;

public partial class CSharpBenchmarks
{
    [GlobalSetup(Target = nameof(LengthOfLongestSubstring))]
    public void LengthOfLongestSubstringSetup()
    {
        String1 = string.Join("", Enumerable.Range(1, 1_000_000).Select(i => i.ToString()));
    }

    [Benchmark]
    public int LengthOfLongestSubstring()
    {
        return Problem.LengthOfLongestSubstring(String1);
    }
}