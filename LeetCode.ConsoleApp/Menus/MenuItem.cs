namespace LeetCode.ConsoleApp.Menus;

public record MenuItem(string Name, int Order) : IComparable<MenuItem>
{
    public int CompareTo(MenuItem? other) => Name.Equals(other?.Name) ? 0 : 1;
}
