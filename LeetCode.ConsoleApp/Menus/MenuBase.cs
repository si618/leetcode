namespace LeetCode.ConsoleApp.Menus;

internal abstract class MenuBase
{
    public IEnumerable<Selection> MenuItems { get; protected init; } = Array.Empty<Selection>();

    public IEnumerable<Selection> GetMenuItems() => MenuItems.OrderBy(m => m.Order);

    public abstract int Render();
}