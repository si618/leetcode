namespace LeetCode;

using FluentAssertions;
using NUnit.Framework;

public sealed partial class Submission
{
    [LeetCode(Difficulty.Easy, Category.None)]
    public static int NumberOfSteps(int num)
    {
        var steps = 0;

        while (num != 0)
        {
            steps++;

            if (num % 2 == 0)
            {
                num /= 2;
            }
            else
            {
                num -= 1;
            }
        }

        return steps;
    }

    [Test]
    public void NumberOfStepsTest()
    {
        NumberOfSteps(14).Should().Be(6);
        NumberOfSteps(8).Should().Be(4);
        NumberOfSteps(123).Should().Be(12);
    }
}
