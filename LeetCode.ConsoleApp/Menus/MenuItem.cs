namespace LeetCode.ConsoleApp.Menus;

internal record MenuItem(string Name, int Order)
{
    /// <summary>
    /// Execute the menu item when selected
    /// </summary>
    /// <returns>Status code</returns>
    public virtual int Execute() => 0;
}