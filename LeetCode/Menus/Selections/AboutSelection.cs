namespace LeetCode.Menus.Selections;

internal sealed record AboutSelection : Selection
{
    internal AboutSelection(int order) : base(Resources.Selection_About, order)
    {
    }

    public override int Execute()
    {
        ConsoleWriter.WriteHeader(clearConsole: true);

        AnsiConsole.WriteLine(Resources.About);

        ConsoleWriter.WaitForKeyPress();

        return 0;
    }
}