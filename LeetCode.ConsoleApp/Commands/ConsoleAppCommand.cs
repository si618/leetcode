namespace LeetCode.ConsoleApp.Commands;

public sealed class ConsoleAppCommand : Command
{
    public override int Execute(CommandContext context)
    {
        var selected = MenuSelection.ListProblems;
        var mainMenu = new SelectionPrompt<MenuSelection>()
            .AddChoices(MenuSelection.GetMainMenuSelections());

        while (selected != MenuSelection.Exit)
        {
            AnsiConsole.Clear();
            ConsoleWriter.WriteHeader(extraLine: true);
            selected = AnsiConsole.Prompt(mainMenu);
            selected.Execute();
        }

        return 0;
    }
}
