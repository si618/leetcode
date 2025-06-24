namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode("Contains Duplicate",
        Difficulty.Easy,
        Category.ArraysAndHashing,
        "https://www.youtube.com/watch?v=3OamzN90kPg")]
    [SuppressMessage("ReSharper", "ParameterTypeCanBeEnumerable.Global")]
    public static bool ContainsDuplicate(int[] nums)
    {
        var set = new HashSet<int>();

        return nums.Any(num => !set.Add(num));
    }

    [Theory]
    [InlineData(new[] { 1, 2, 3, 1 }, true)]
    [InlineData(new[] { 1, 2, 3, 4 }, false)]
    [InlineData(new[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 }, true)]
    public void ContainsDuplicateTest(int[] nums, bool expected) =>
        ContainsDuplicate(nums).ShouldBe(expected);
}
