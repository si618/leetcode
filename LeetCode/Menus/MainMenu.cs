﻿namespace LeetCode.Menus;

internal sealed class MainMenu : MenuBase
{
    public MainMenu()
    {
        MenuItems = new List<Selection>
        {
            new ProblemListSelection(1),
            new BenchmarkListSelection(2),
            new AboutSelection(3),
            new ExitSelection(4)
        };
    }
    public override int Render()
    {
        var selected = MenuItems.First();
        var prompt = new SelectionPrompt<Selection>()
            .AddChoices(GetMenuItems())
            .UseConverter(m => m.Name);

        var exitCode = 0;
        while (selected.Name != ExitSelection.Exit)
        {
            ConsoleWriter.WriteHeader(clearConsole: true, appendLine: true);
            selected = AnsiConsole.Prompt(prompt);
            exitCode = selected.Execute();
        }
        return exitCode;
    }
}
