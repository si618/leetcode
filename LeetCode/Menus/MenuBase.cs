namespace LeetCode.Menus;

internal abstract class MenuBase
{
    protected IEnumerable<Selection> Choices { get; init; } = Array.Empty<Selection>();

    protected IEnumerable<Selection> GetChoices() => Choices.OrderBy(m => m.Order);

    public abstract int Render();
}