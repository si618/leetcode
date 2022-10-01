namespace LeetCode.ConsoleApp;

public abstract class MenuSelection : SmartEnum<MenuSelection>, IMenuSelection
{
    public static readonly MenuSelection ListProblems = new ProblemList();
    public static readonly MenuSelection RunBenchmarks = new RunBenchmark();
    public static readonly MenuSelection Exit = new ExitApp();

    public abstract void Execute();

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

    private sealed class RunBenchmark : MenuSelection
    {
        public RunBenchmark() : base("Run Benchmarks", 2)
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