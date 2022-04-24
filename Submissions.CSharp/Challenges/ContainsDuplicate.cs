namespace LeetCode;

using FluentAssertions;
using NUnit.Framework;

public sealed partial class Submission
{
    [LeetCode(
        "Contains Duplicate",
        Difficulty.Easy,
        Category.ArraysAndHashing)]
    public static bool ContainsDuplicate(int[] nums)
    {
        var set = new HashSet<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            var num = nums[i];

            if (set.Contains(num))
            {
                return true;
            }

            set.Add(num);
        }

        return false;
    }

    [Test]
    public void ContainsDuplicateTest()
    {
        var ex1 = new[] { 1, 2, 3, 1 };
        var ex2 = new[] { 1, 2, 3, 4 };
        var ex3 = new[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 };

        ContainsDuplicate(ex1).Should().BeTrue();
        ContainsDuplicate(ex2).Should().BeFalse();
        ContainsDuplicate(ex3).Should().BeTrue();
    }
}
