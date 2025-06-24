namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode("Reverse Bits",
        Difficulty.Easy,
        Category.BitManipulation,
        "https://www.youtube.com/watch?v=UcoN6UjAI64")]
    public static uint ReverseBits(uint n)
    {
        uint result = 0;

        for (var i = 0; i < 32; i++)
        {
            var bit = n >> i & 1;
            result |= bit << 31 - i;
        }

        return result;
    }

    [Fact]
    public void ReverseBitsTest()
    {
        const uint ex1 = 0b00000010100101000001111010011100;
        const uint ex2 = 0b11111111111111111111111111111101;

        ReverseBits(ex1).ShouldBe(0b00111001011110000010100101000000U);
        ReverseBits(ex2).ShouldBe(0b10111111111111111111111111111111U);
    }
}
