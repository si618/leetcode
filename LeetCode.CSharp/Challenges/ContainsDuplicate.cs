namespace LeetCode;

using FluentAssertions;
using NUnit.Framework;

public sealed partial class Challenge
{
    [LeetCode("Contains Duplicate", Difficulty.Easy, Category.ArraysAndHashing)]
    // ReSharper disable once ParameterTypeCanBeEnumerable.Global
    public static bool ContainsDuplicate(int[] nums)
    {
        var set = new HashSet<int>();

        foreach (var num in nums)
        {
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
