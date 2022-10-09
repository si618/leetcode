namespace LeetCode.ConsoleApp.Menus;

internal class MainMenu : MenuBase
{
    public MainMenu()
    {
        MenuItems = new List<MenuItem>
        {
            new ProblemListMenuItem(1),
            new BenchmarkListMenuItem(2),
            new AboutMenuItem(3),
            new("Exit", 4)
        };
    }
    public override void Render()
    {
        var selected = MenuItems.First();
        var prompt = new SelectionPrompt<MenuItem>()
            .AddChoices(GetMenuItems())
            .UseConverter(m => m.Name);

        while (selected.Name != "Exit")
        {
            AnsiConsole.Clear();
            ConsoleWriter.WriteHeader(extraLine: true);
            selected = AnsiConsole.Prompt(prompt);
            selected.Execute();
        }
    }
}
