namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode(
        "Counting Bits",
        Difficulty.Easy,
        Category.BitManipulation,
        "https://www.youtube.com/watch?v=RyBM56RIWrM")]
    [SuppressMessage("ReSharper", "ReturnTypeCanBeEnumerable.Global")]
    public static int[] CountBits(int n)
    {
        var result = new int[n + 1];
        var offset = 1;

        for (var i = 1; i <= n; i++)
        {
            if (offset * 2 == i)
            {
                // i is power of two, meaning a new most significant bit
                offset = i;
            }

            result[i] = 1 + result[i - offset];
        }

        return result;
    }

    [Fact]
    public void CountBitsTest()
    {
        const int ex1 = 2;
        const int ex2 = 5;

        CountBits(ex1).Should().Equal(0, 1, 1);
        CountBits(ex2).Should().Equal(0, 1, 1, 2, 1, 2);
    }
}
