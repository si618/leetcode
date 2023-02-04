namespace LeetCode.CSharp.Benchmarks;

public class EncodeBenchmark : Benchmark
{
    [GlobalSetup(Target = nameof(Encode))]
    public void EncodeSetup()
    {
        StringArray1 = new string[1_000];

        for (var i = 0; i < StringArray1.Length; i++)
        {
            StringArray1[i] = BuildPseudoRandomString(Random.Next(1_000), 2);
        }
    }

    [Benchmark]
    public string Encode() => Problem.Encode(StringArray1);

    [GlobalCleanup(Target = nameof(Encode))]
    public void EncodeCleanup() => StringArray1 = Array.Empty<string>();
}

public class DecodeBenchmark : Benchmark
{
    [GlobalSetup(Target = nameof(Decode))]
    public void DecodeSetup()
    {
        StringArray1 = new string[1_000];

        for (var i = 0; i < StringArray1.Length; i++)
        {
            StringArray1[i] = BuildPseudoRandomString(Random.Next(1_000), 2);
        }

        String1 = Problem.Encode(StringArray1);
    }

    [Benchmark]
    public List<string> Decode() => Problem.Decode(String1).ToList();

    [GlobalCleanup(Target = nameof(Decode))]
    public void DecodeCleanup()
    {
        String1 = string.Empty;
        StringArray1 = Array.Empty<string>();
    }
}