namespace LeetCode.ConsoleApp.Menus;

public abstract class MenuSelection : SmartEnum<MenuSelection, MenuItem>, IMenuSelection
{
    protected MenuSelection(MenuItem menuItem) : base(menuItem.Name, menuItem)
    {
    }

    public static readonly MenuSelection ListProblems =
        new ProblemList(new MenuItem("List Problems", 1, 1));

    public static readonly MenuSelection RunBenchmarks =
        new BenchmarkList(new MenuItem("Run Benchmarks", 1, 2));

    public static readonly MenuSelection About =
        new AboutApp(new MenuItem("About", 1, 3));

    public static readonly MenuSelection Exit =
        new ExitApp(new MenuItem("Exit", 1, 4));

    public abstract void Execute();

    public static IEnumerable<MenuSelection> GetMainMenuSelections() =>
        List
            .Where(s => s.Value.Depth == 1)
            .OrderBy(s => s.Value.Order);
}