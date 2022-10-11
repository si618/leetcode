namespace LeetCode.ConsoleApp.Menus.Selections;

internal abstract record Selection(string Name, int Order)
{
    /// <summary>
    /// Execute a menu item when selected
    /// </summary>
    /// <returns>Status code</returns>
    public abstract int Execute();
}