namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode("Valid Sudoku",
        Difficulty.Medium,
        Category.ArraysAndHashing,
        "https://www.youtube.com/watch?v=TjFXEUCMqI8")]
    public static bool IsValidSudoku(char[][] board)
    {
        var columns = new Dictionary<int, HashSet<short>>();
        var subBoxes = new Dictionary<(int, int), HashSet<short>>();

        for (var r = 0; r < 9; r++)
        {
            var row = new HashSet<short>();

            for (var c = 0; c < 9; c++)
            {
                if (!columns.TryGetValue(c, out var column))
                {
                    column = [];
                    columns[c] = column;
                }

                // Integer division rounds down creating sub-boxes:
                // row 0 column 0 | row 0 column 1 | row 0 column 2
                // row 1 column 0 | row 1 column 1 | row 1 column 2
                // row 2 column 0 | row 2 column 1 | row 2 column 2
                var subBoxKey = (r / 3, c / 3);
                if (!subBoxes.TryGetValue(subBoxKey, out var subBox))
                {
                    subBox = [];
                    subBoxes.Add(subBoxKey, subBox);
                }

                var cell = board[r][c];

                // Ignore empty cells
                if (cell == '.')
                {
                    continue;
                }

                // Cell must be integer between 1 and 9
                var digit = Convert.ToInt16(cell);

                if (row.TryGetValue(digit, out _) ||
                    column.TryGetValue(digit, out _) ||
                    subBox.Contains(digit))
                {
                    return false;
                }

                row.Add(digit);
                column.Add(digit);
                subBox.Add(digit);
            }
        }

        return true;
    }

    [Fact]
    public void IsValidSudokuTest()
    {
        var ex1 = new char[][]
        {
            ['5', '3', '.', '.', '7', '.', '.', '.', '.'],
            ['6', '.', '.', '1', '9', '5', '.', '.', '.'],
            ['.', '9', '8', '.', '.', '.', '.', '6', '.'],
            ['8', '.', '.', '.', '6', '.', '.', '.', '3'],
            ['4', '.', '.', '8', '.', '3', '.', '.', '1'],
            ['7', '.', '.', '.', '2', '.', '.', '.', '6'],
            ['.', '6', '.', '.', '.', '.', '2', '8', '.'],
            ['.', '.', '.', '4', '1', '9', '.', '.', '5'],
            ['.', '.', '.', '.', '8', '.', '.', '7', '9']
        };
        var ex2 = new char[][]
        {
            ['8', '3', '.', '.', '7', '.', '.', '.', '.'],
            ['6', '.', '.', '1', '9', '5', '.', '.', '.'],
            ['.', '9', '8', '.', '.', '.', '.', '6', '.'],
            ['8', '.', '.', '.', '6', '.', '.', '.', '3'],
            ['4', '.', '.', '8', '.', '3', '.', '.', '1'],
            ['7', '.', '.', '.', '2', '.', '.', '.', '6'],
            ['.', '6', '.', '.', '.', '.', '2', '8', '.'],
            ['.', '.', '.', '4', '1', '9', '.', '.', '5'],
            ['.', '.', '.', '.', '8', '.', '.', '7', '9']
        };
        var ex3 = new char[][]
        {
            ['.', '.', '4', '.', '.', '.', '6', '3', '.'],
            ['.', '.', '.', '.', '.', '.', '.', '.', '.'],
            ['5', '.', '.', '.', '.', '.', '.', '9', '.'],
            ['.', '.', '.', '5', '6', '.', '.', '.', '.'],
            ['4', '.', '3', '.', '.', '.', '.', '.', '1'],
            ['.', '.', '.', '7', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '5', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.', '.', '.', '.']
        };

        IsValidSudoku(ex1).ShouldBeTrue();
        IsValidSudoku(ex2).ShouldBeFalse();
        IsValidSudoku(ex3).ShouldBeFalse();
    }
}
