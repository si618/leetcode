namespace LeetCode.CSharp.Benchmarks;

public class GroupAnagramsBenchmark : Benchmark
{
    [GlobalSetup(Target = nameof(GroupAnagrams))]
    public void GroupAnagramsSetup()
    {
        StringArray1 = new string[10_000];

        for (var i = 0; i < StringArray1.Length; i++)
        {
            StringArray1[i] = BuildPseudoRandomString(Random.Next(100));
        }
    }

    [Benchmark]
    public IList<IList<string>> GroupAnagrams() => Problem.GroupAnagrams(StringArray1);

    [GlobalCleanup(Target = nameof(GroupAnagrams))]
    public void GroupAnagramsCleanup() => StringArray1 = Array.Empty<string>();
}