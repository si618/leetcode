namespace LeetCode.ConsoleApp.Menus;

internal abstract class MenuBase : IMenu
{
    public IEnumerable<MenuItem> MenuItems { get; protected init; } = Array.Empty<MenuItem>();

    public abstract void Render();

    public IEnumerable<MenuItem> GetMenuItems() => MenuItems.OrderBy(menuItem => menuItem.Order);
}