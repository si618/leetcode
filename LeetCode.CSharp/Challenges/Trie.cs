namespace LeetCode;

using FluentAssertions;
using NUnit.Framework;

public sealed partial class Challenge
{
    [LeetCode("Implement Trie (Prefix Tree)", Difficulty.Medium, Category.Tries)]
    public class Trie
    {
        public Trie()
        {
            Root = new TrieChild();
        }

        private TrieChild Root { get; }

        public void Insert(string word)
        {
            var current = Root;

            foreach (var c in word)
            {
                if (!current.Children.ContainsKey(c))
                {
                    current.Children.Add(c, new TrieChild());
                }
                current = current.Children[c];
            }

            current.EndOfWord = true;
        }

        public bool Search(string word)
        {
            var current = Root;

            foreach (var c in word)
            {
                if (!current.Children.ContainsKey(c))
                {
                    return false;
                }
                current = current.Children[c];
            }

            return current.EndOfWord;
        }

        public bool StartsWith(string prefix)
        {
            var current = Root;

            foreach (var c in prefix)
            {
                if (!current.Children.ContainsKey(c))
                {
                    return false;
                }
                current = current.Children[c];
            }

            return true;
        }
    }

    public record TrieChild
    {
        public Dictionary<char, TrieChild> Children { get; } = new();
        public bool EndOfWord { get; set; }
    }

    [Test]
    public void TrieTest()
    {
        var trie = new Trie();

        trie.Insert("apple");
        trie.Search("apple").Should().BeTrue();
        trie.Search("app").Should().BeFalse();
        trie.StartsWith("app").Should().BeTrue();

        trie.Insert("app");
        trie.Search("app").Should().BeTrue();
    }
}
