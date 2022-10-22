namespace LeetCode.Menus.Selections;

internal sealed record ExitSelection : Selection
{
    public const string Exit = "Exit";

    internal ExitSelection(int order) : base(Exit, order)
    {
    }

    public override int Execute()
    {
        return 0;
    }
}