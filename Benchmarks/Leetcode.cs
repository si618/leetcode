namespace Leetcode.Benchmarks;
using BenchmarkDotNet.Attributes;
using global::Leetcode.Submissions;

public class Leetcode
{
    [Benchmark]
    public void IsPalindrome()
    {
        var isTrue = new ListNode(1,
            new ListNode(2,
                new ListNode(2,
                    new ListNode(1, null))));
        var isFalse = new ListNode(1, new ListNode(2, null));
        IsPalindromeTest.IsPalindrome(isTrue);
        IsPalindromeTest.IsPalindrome(isFalse);
    }

    [Benchmark]
    public void RomanToInt()
    {
        RomanToIntTest.RomanToInt("III");
        RomanToIntTest.RomanToInt("LVIII");
        RomanToIntTest.RomanToInt("MCMXCIV");
    }

    [Benchmark]
    public void RansomNote()
    {
        RansomNoteTest.CanConstruct("b", "a");
        RansomNoteTest.CanConstruct("ab", "aa");
        RansomNoteTest.CanConstruct("aab", "aa");
    }

    [Benchmark]
    public void FizzBuzz()
    {
        FizzBuzzTest.FizzBuzz(3);
        FizzBuzzTest.FizzBuzz(5);
        FizzBuzzTest.FizzBuzz(15);
    }

    [Benchmark]
    public void MiddleNode()
    {
        var even = new ListNode(1,
            new ListNode(2,
                new ListNode(3,
                    new ListNode(4, null))));
        var odd = new ListNode(1,
            new ListNode(2,
                new ListNode(3,
                    new ListNode(4,
                        new ListNode(5, null)))));
        MiddleNodeTest.MiddleNode(even);
        MiddleNodeTest.MiddleNode(odd);
    }

    [Benchmark]
    public void KWeakestRows()
    {
        var ex1 = new int[][]
        {
            new[] { 1, 1, 0, 0, 0 },
            new[] { 1, 1, 1, 1, 0 },
            new[] { 1, 0, 0, 0, 0 },
            new[] { 1, 1, 0, 0, 0 },
            new[] { 1, 1, 1, 1, 1 }
        };
        var ex2 = new int[][]
        {
            new[] { 1, 0, 0, 0 },
            new[] { 1, 1, 1, 1 },
            new[] { 1, 0, 0, 0 },
            new[] { 1, 0, 0, 0 }
        };
        KWeakestRowsTest.KWeakestRows(ex1, 3);
        KWeakestRowsTest.KWeakestRows(ex2, 2);
    }

    [Benchmark]
    public void NumberOfSteps()
    {
        NumberOfStepsTest.NumberOfSteps(14);
        NumberOfStepsTest.NumberOfSteps(8);
        NumberOfStepsTest.NumberOfSteps(123);
    }

    [Benchmark]
    public void MaximumWealth()
    {
        var ex1 = new int[][]
        {
            new[] { 1, 2, 3 },
            new[] { 3, 2, 1 }
        };
        var ex2 = new int[][]
        {
            new[] { 1, 5 },
            new[] { 7, 3 },
            new[] { 3, 5 }
        };
        MaximumWealthTest.MaximumWealth(ex1);
        MaximumWealthTest.MaximumWealth(ex2);
    }

    [Benchmark]
    public void TwoSum()
    {
        var ex1 = new[] { 2, 7, 11, 15 };
        var ex2 = new[] { 3, 2, 4 };
        var ex3 = new[] { 3, 3 };
        TwoSumTest.TwoSum(ex1, 9);
        TwoSumTest.TwoSum(ex2, 6);
        TwoSumTest.TwoSum(ex3, 6);
    }
}