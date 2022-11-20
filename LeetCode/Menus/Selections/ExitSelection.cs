namespace LeetCode.Menus.Selections;

internal sealed record ExitSelection : Selection
{
    internal ExitSelection(int order) : base(Resources.Selection_Exit, order)
    {
    }

    public override int Execute()
    {
        ConsoleWriter.AnimateHeader();

        return 0;
    }
}