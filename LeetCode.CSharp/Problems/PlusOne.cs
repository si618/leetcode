namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode(
        "Plus One",
        Difficulty.Easy,
        Category.MathAndGeometry,
        "https://www.youtube.com/watch?v=jIaA8boiG1s")]
    [SuppressMessage("ReSharper", "ParameterTypeCanBeEnumerable.Global")]
    public static int[] PlusOne(int[] digits)
    {
        var list = digits.Reverse().ToList();
        var carry = 1;
        var i = 0;

        while (carry == 1)
        {
            if (i < list.Count)
            {
                if (list[i] == 9)
                {
                    list[i] = 0;
                    carry = 1;
                }
                else
                {
                    list[i] += 1;
                    carry = 0;
                }
            }
            else
            {
                list.Add(1);
                carry = 0;
            }

            i++;
        }

        list.Reverse();

        return list.ToArray();
    }

    [Fact]
    public void PlusOneTest()
    {
        var ex1 = new[] { 1, 2, 3 };
        var ex2 = new[] { 4, 3, 2, 1 };
        var ex3 = new[] { 9 };

        PlusOne(ex1).Should().Equal(1, 2, 4);
        PlusOne(ex2).Should().Equal(4, 3, 2, 2);
        PlusOne(ex3).Should().Equal(1, 0);
    }
}
