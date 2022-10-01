var selection = MenuSelection.ListProblems;
var prompt = new SelectionPrompt<MenuSelection>().AddChoices(MenuSelection.GetMainMenuSelections());

while (selection != MenuSelection.Exit)
{
    AnsiConsole.Clear();
    ConsoleWriter.WriteHeader();
    selection = AnsiConsole.Prompt(prompt);
    selection.Execute();
}
