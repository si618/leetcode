namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode(
    "Number of 1 Bits",
    Difficulty.Easy,
    Category.BitManipulation,
    "https://www.youtube.com/watch?v=5Km3utixwZs")]
    public static int HammingWeight(uint n)
    {
        // return System.Numerics.BitOperations.PopCount(n);

        var count = (uint)0;

        while (n != 0)
        {
            count += n % 2;
            n >>= 1;
        }

        return (int)count;
    }

    [Fact]
    public void HammingWeightTest()
    {
        HammingWeight(0b00000000000000000000000000001011).Should().Be(3);
        HammingWeight(0b00000000000000000000000010000000).Should().Be(1);
        HammingWeight(0b11111111111111111111111111111101).Should().Be(31);
    }
}
