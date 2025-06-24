namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode("Happy Number",
        Difficulty.Easy,
        Category.MathAndGeometry,
        "https://www.youtube.com/watch?v=ljz85bxOYJ0")]
    public static bool IsHappy(int n)
    {
        var visited = new HashSet<int>();

        while (!visited.Contains(n))
        {
            visited.Add(n);

            n = SumOfSquares(n);

            if (n == 1)
            {
                return true; // :)
            }
        }

        return false; // :(

        static int SumOfSquares(int i)
        {
            var result = 0;

            while (i != 0)
            {
                var digit = i % 10;
                digit *= digit;
                result += digit;
                i /= 10;
            }
            return result;
        }
    }

    [Fact]
    public void IsHappyTest()
    {
        IsHappy(19).ShouldBeTrue();
        IsHappy(2).ShouldBeFalse();
    }
}
