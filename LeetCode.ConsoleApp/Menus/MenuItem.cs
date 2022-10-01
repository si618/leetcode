namespace LeetCode.ConsoleApp.Menus;

public record MenuItem(string Name, int Depth, int Order) : IComparable<MenuItem>
{
    public int CompareTo(MenuItem? other) =>
        Depth - other?.Depth + (Order - other?.Order) ?? 0;
}
