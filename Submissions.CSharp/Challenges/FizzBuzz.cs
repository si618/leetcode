namespace LeetCode;

using FluentAssertions;
using NUnit.Framework;

public sealed partial class Submission
{
    [LeetCode("Fizz Buzz", Difficulty.Easy, Category.NotInNeetCode)]
    public static IList<string> FizzBuzz(int n)
    {
        var result = new List<string>();

        for (int i = 1; i <= n; i++)
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
        var input1 = 3;
        var output1 = new List<string> { "1", "2", "Fizz" };
        var input2 = 5;
        var output2 = new List<string> { "1", "2", "Fizz", "4", "Buzz" };
        var input3 = 15;
        var output3 = new List<string> { "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz" };

        FizzBuzz(input1).Should().Equal(output1);
        FizzBuzz(input2).Should().Equal(output2);
        FizzBuzz(input3).Should().Equal(output3);
    }
}
