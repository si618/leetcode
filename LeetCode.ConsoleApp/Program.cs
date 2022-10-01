var selection = MenuSelection.ListProblems;

while (selection != MenuSelection.Exit)
{
    AnsiConsole.Clear();
    ConsoleWriter.WriteHeader();

    selection = AnsiConsole.Prompt(
        new SelectionPrompt<MenuSelection>()
            .AddChoices(MenuSelection.List.OrderBy(s => s.Value)));

    selection.Execute();
}
