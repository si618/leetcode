namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode("Climbing Stairs",
        Difficulty.Easy,
        Category.OneDDynamicProgramming,
        "https://www.youtube.com/watch?v=Y0lT9Fck7qI")]
    public static int ClimbStairs(int n)
    {
        // End of decision tree always has one step as two steps would be out of bounds
        var oneStep = 1;
        var twoStep = 1;

        // Start from the top of the stairs and work backwards to solve each sub-problem
        for (var i = 0; i < n - 1; i++)
        {
            // Memoize result to avoid recalculation
            var previousStep = oneStep;
            oneStep += twoStep;
            twoStep = previousStep;
        }

        return oneStep;
    }

    [Theory]
    [InlineData(2, 2)]
    [InlineData(3, 3)]
    public void ClimbStairsTest(int n, int expected) => ClimbStairs(n).Should().Be(expected);
}
