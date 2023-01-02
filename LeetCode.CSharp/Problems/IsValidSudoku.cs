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
                    column = new HashSet<short>();
                    columns[c] = column;
                }

                // Integer division rounds down creating sub-boxes:
                // row 0 column 0 | row 0 column 1 | row 0 column 2
                // row 1 column 0 | row 1 column 1 | row 1 column 2
                // row 2 column 0 | row 2 column 1 | row 2 column 2
                var subBoxKey = (r / 3, c / 3);
                if (!subBoxes.TryGetValue(subBoxKey, out var subBox))
                {
                    subBox = new HashSet<short>();
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
        var ex1 = new[]
        {
            new[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
            new[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
            new[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
            new[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
            new[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
            new[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
            new[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
            new[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
            new[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
        };
        var ex2 = new[]
        {
            new[] { '8', '3', '.', '.', '7', '.', '.', '.', '.' },
            new[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
            new[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
            new[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
            new[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
            new[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
            new[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
            new[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
            new[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
        };
        var ex3 = new[]
        {
            new[] { '.', '.', '4', '.', '.', '.', '6', '3', '.' },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
            new[] { '5', '.', '.', '.', '.', '.', '.', '9', '.' },
            new[] { '.', '.', '.', '5', '6', '.', '.', '.', '.' },
            new[] { '4', '.', '3', '.', '.', '.', '.', '.', '1' },
            new[] { '.', '.', '.', '7', '.', '.', '.', '.', '.' },
            new[] { '.', '.', '.', '5', '.', '.', '.', '.', '.' },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' },
            new[] { '.', '.', '.', '.', '.', '.', '.', '.', '.' }
        };

        IsValidSudoku(ex1).Should().BeTrue();
        IsValidSudoku(ex2).Should().BeFalse();
        IsValidSudoku(ex3).Should().BeFalse();
    }
}
