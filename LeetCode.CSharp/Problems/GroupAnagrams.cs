namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode("Group Anagrams",
        Difficulty.Medium,
        Category.ArraysAndHashing,
        "https://www.youtube.com/watch?v=vzdNOK2oB2E")]
    [SuppressMessage("ReSharper", "ReturnTypeCanBeEnumerable.Global")]
    [SuppressMessage("ReSharper", "ParameterTypeCanBeEnumerable.Global")]
    public static IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var dictionary = new Dictionary<string, IList<string>>();

        foreach (var str in strs)
        {
            var hash = new char[26];

            foreach (var c in str)
            {
                hash[c - 'a']++;
            }

            var key = new string(hash);

            if (dictionary.TryGetValue(key, out var list))
            {
                list.Add(str);
            }
            else
            {
                dictionary.Add(key, new List<string> { str });
            }
        }

        return dictionary.Values.ToList();
    }

    [Fact]
    public void GroupAnagramsTest()
    {
        var ex1 = new[] { "eat", "tea", "tan", "ate", "nat", "bat" };
        var ex1Expected = new List<List<string>>
        {
            new() { "eat", "tea", "ate" },
            new() { "tan", "nat" },
            new() { "bat" }
        };
        var ex2 = new[] { "" };
        var ex2Expected = new List<List<string>> { new() { "" } };
        var ex3 = new[] { "a" };
        var ex3Expected = new List<List<string>> { new() { "a" } };
        var ex4 = new[] { "cab", "tin", "pew", "duh", "may", "ill", "buy", "bar", "max", "doc" };
        var ex4Expected = new List<List<string>>
        {
            new() { "cab" },
            new() { "tin" },
            new() { "pew" },
            new() { "duh" },
            new() { "may" },
            new() { "ill" },
            new() { "buy" },
            new() { "bar" },
            new() { "max" },
            new() { "doc" }
        };

        var strs = new string[100_000];
        for (var i = 0; i < strs.Length; i++)
        {
            strs[i] = Benchmark.BuildPseudoRandomString(Benchmark.Random.Next(100));
        }

        GroupAnagrams(ex1).Should().BeEquivalentTo(ex1Expected);
        GroupAnagrams(ex2).Should().BeEquivalentTo(ex2Expected);
        GroupAnagrams(ex3).Should().BeEquivalentTo(ex3Expected);
        GroupAnagrams(ex4).Should().BeEquivalentTo(ex4Expected);
    }
}
