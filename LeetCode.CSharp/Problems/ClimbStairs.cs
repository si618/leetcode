namespace LeetCode;

public sealed partial class Problem
{
    [LeetCode(
        "Climbing Stairs",
        Difficulty.Easy,
        Category.OneDDynamicProgramming,
        "Y0lT9Fck7qI")]
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

    [Test]
    public void ClimbStairsTest()
    {
        ClimbStairs(2).Should().Be(2);
        ClimbStairs(3).Should().Be(3);
    }
}
