namespace LeetCode.ConsoleApp;

using System.Collections.Immutable;
using System.Collections.ObjectModel;

public abstract class MenuSelection : SmartEnum<MenuSelection>, IMenuSelection
{
    public static readonly MenuSelection ListProblems = new ProblemList();
    public static readonly MenuSelection RunBenchmarks = new BenchmarkList();
    public static readonly MenuSelection Exit = new ExitApp();

    public abstract void Execute();

    public IReadOnlyList<MenuSelection> GetRootMenuSelections() =>
        new ReadOnlyCollection<MenuSelection>(List.OrderBy(s => s.Value).ToList());

    private MenuSelection(string name, int order) : base(name, order)
    {
    }

    private sealed class ProblemList : MenuSelection
    {
        public ProblemList() : base("List Problems", 1)
        {
        }

        public override void Execute()
        {
        }
    }

    private sealed class BenchmarkList : MenuSelection
    {
        public BenchmarkList() : base("Run Benchmarks", 2)
        {
        }

        public override void Execute()
        {
        }
    }

    private sealed class ExitApp : MenuSelection
    {
        public ExitApp() : base("Exit", 3)
        {
        }

        public override void Execute()
        {
        }
    }
}