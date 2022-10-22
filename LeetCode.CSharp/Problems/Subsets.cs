namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode(
        "Subsets",
        Difficulty.Medium,
        Category.BackTracking,
        "https://www.youtube.com/watch?v=REOH22Xwdkk")]
    public static IList<IList<int>> Subsets(int[] nums)
    {
        var subsets = new List<IList<int>>();
        var subset = new List<int>();

        // NeetCode explanation: https://youtu.be/REOH22Xwdkk?t=163
        void DepthFirstSearch(int index)
        {
            if (index >= nums.Length)
            {
                // Add copy to result as reached end of leaf nodes
                subsets.Add(new List<int>(subset));
                return;
            }

            // Add current item and continue backtracking
            subset.Add(nums[index]);
            DepthFirstSearch(index + 1);

            // Remove current item and continue backtracking
            subset.Remove(nums[index]);

            // ReSharper disable once TailRecursiveCall
            // For clarity - minimal difference found in benchmark
            DepthFirstSearch(index + 1);
        }

        DepthFirstSearch(0);

        return subsets;
    }

    [Fact]
    public void SubsetsTest()
    {
        var ex1 = new[] { 1, 2, 3 };
        var ep1 = new List<IList<int>>
        {
            new List<int> { 1, 2, 3 },
            new List<int> { 1, 2 },
            new List<int> { 1, 3 },
            new List<int> { 1 },
            new List<int> { 2, 3 },
            new List<int> { 2 },
            new List<int> { 3 },
            new List<int>()
        };
        var ex2 = new[] { 0 };
        var ep2 = new List<IList<int>>
        {
            new List<int>{ 0 },
            new List<int>()
        };

        Subsets(ex1).Should().BeEquivalentTo(ep1);
        Subsets(ex2).Should().BeEquivalentTo(ep2);
    }
}
