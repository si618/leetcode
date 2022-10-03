namespace LeetCode.CSharp;

public partial class Benchmarks
{
    [GlobalSetup(Target = nameof(LengthOfLongestSubstring))]
    public void LengthOfLongestSubstringSetup()
    {
        String1 = BuildPseudoRandomString(1_000_000);
    }

    [Benchmark]
    public int LengthOfLongestSubstring()
    {
        return Problem.LengthOfLongestSubstring(String1);
    }

    [GlobalCleanup(Target = nameof(LengthOfLongestSubstring))]
    public void LengthOfLongestSubstringCleanup()
    {
        String1 = string.Empty;
    }
}