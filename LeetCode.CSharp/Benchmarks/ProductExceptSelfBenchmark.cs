namespace LeetCode.CSharp.Benchmarks;

public class ProductExceptSelfBenchmark : Benchmark
{
    [GlobalSetup(Target = nameof(ProductExceptSelf))]
    public void ProductExceptSelfSetup() => IntArray1 = Enumerable.Range(1, 100_000).ToArray();

    [Benchmark]
    public int[] ProductExceptSelf() => Problem.ProductExceptSelf(IntArray1);

    [GlobalCleanup(Target = nameof(ProductExceptSelf))]
    public void ProductExceptSelfCleanup() => StringArray1 = Array.Empty<string>();
}