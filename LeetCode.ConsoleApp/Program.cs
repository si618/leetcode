var selection = MenuSelection.ListProblems;
var prompt = new SelectionPrompt<MenuSelection>().AddChoices(selection.GetRootMenuSelections());

while (selection != MenuSelection.Exit)
{
    AnsiConsole.Clear();
    ConsoleWriter.WriteHeader();
    selection = AnsiConsole.Prompt(prompt);
    selection.Execute();
}
