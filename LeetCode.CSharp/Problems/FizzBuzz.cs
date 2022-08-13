namespace LeetCode;

using FluentAssertions;
using NUnit.Framework;

public sealed partial class Problem
{
    [LeetCode("Fizz Buzz", Difficulty.Easy, Category.NotInNeetCode)]
    public static IList<string> FizzBuzz(int n)
    {
        var result = new List<string>();

        for (var i = 1; i <= n; i++)
        {
            var value = string.Empty;

            if (i % 3 == 0)
            {
                value = "Fizz";
            }

            if (i % 5 == 0)
            {
                value += "Buzz";
            }

            if (string.IsNullOrEmpty(value))
            {
                value = i.ToString();
            }

            result.Add(value);
        }

        return result;
    }

    [Test]
    public void FizzBuzzTest()
    {
        var output1 = new List<string> { "1", "2", "Fizz" };
        var output2 = new List<string> { "1", "2", "Fizz", "4", "Buzz" };
        var output3 = new List<string> { "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz" };

        FizzBuzz(3).Should().Equal(output1);
        FizzBuzz(5).Should().Equal(output2);
        FizzBuzz(15).Should().Equal(output3);
    }
}
