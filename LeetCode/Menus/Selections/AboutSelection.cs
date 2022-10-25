namespace LeetCode.Menus.Selections;

internal sealed record AboutSelection : Selection
{
    internal AboutSelection(int order) : base("About", order)
    {
    }

    public override int Execute()
    {
        ConsoleWriter.WriteHeader(clearConsole: true);

        AnsiConsole.WriteLine("About stuff goes here");

        ConsoleWriter.WaitForKeyPress();

        return 0;
    }
}