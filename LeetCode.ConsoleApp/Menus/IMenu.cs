namespace LeetCode.ConsoleApp.Menus;

internal interface IMenu
{
    IEnumerable<MenuItem> MenuItems { get; }

    void Render();

    IEnumerable<MenuItem> GetMenuItems();
}
