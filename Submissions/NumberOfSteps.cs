namespace Leetcode.Submissions;
using NUnit.Framework;

public class NumberOfStepsTest
{
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
    public void Test()
    {
        // Arrange, Act & Assert
        Assert.AreEqual(6, NumberOfSteps(14));
        Assert.AreEqual(4, NumberOfSteps(8));
        Assert.AreEqual(12, NumberOfSteps(123));
    }
}
