namespace LeetCode.CSharp.Problems;

public sealed partial class Problem
{
    [LeetCode("Number of Islands",
        Difficulty.Medium,
        Category.Graphs,
        "https://www.youtube.com/watch?v=pV2kpPD66nE")]
    public static int NumIslands(char[][]? grid)
    {
        if (grid is null || grid.Length == 0)
        {
            return 0;
        }

        const char sea = '0';
        var rows = grid.Length;
        var columns = grid[0].Length;
        var visited = new HashSet<(int, int)>();
        var queue = new Queue<(int, int)>();
        var directions = new
        {
            Up = (1, 0),
            Left = (-1, 0),
            Right = (0, 1),
            Down = (0, -1)
        };

        var islands = 0;

        for (var row = 0; row < rows; row++)
        {
            for (var column = 0; column < columns; column++)
            {
                if (grid[row][column] == sea)
                {
                    continue;
                }

                var position = (row, column);
                if (visited.Contains(position))
                {
                    continue;
                }

                BreadthFirstSearch(position);

                islands++;
            }
        }

        return islands;

        void TestDirection((int row, int column) position, (int row, int column) direction)
        {
            var row = position.row + direction.row;
            var column = position.column + direction.column;
            if (row < 0 || row >= rows || column < 0 || column >= columns)
            {
                // Out of map infers sea
                return;
            }

            if (grid[row][column] == sea)
            {
                return;
            }

            var testDirection = (row, column);
            if (!visited.Add(testDirection))
            {
                return;
            }

            // Non-visited land found
            queue.Enqueue(testDirection);
        }

        void BreadthFirstSearch((int, int) position)
        {
            // Position is guaranteed to be land
            visited.Add(position);

            // Add to position to be searched in all directions
            queue.Enqueue(position);

            while (queue.Count != 0)
            {
                var test = queue.Dequeue();
                TestDirection(test, directions.Up);
                TestDirection(test, directions.Left);
                TestDirection(test, directions.Right);
                TestDirection(test, directions.Down);
            }
        }
    }

    [Fact]
    public void NumIslandsTest()
    {
        var ex1 = new char[][]
        {
            ['1', '1', '1', '1', '0'],
            ['1', '1', '0', '1', '0'],
            ['1', '1', '0', '0', '0'],
            ['0', '0', '0', '0', '0']
        };
        var ex2 = new char[][]
        {
            ['1', '1', '0', '0', '0'],
            ['1', '1', '0', '0', '0'],
            ['0', '0', '1', '0', '0'],
            ['0', '0', '0', '1', '1']
        };

        NumIslands(null).ShouldBe(0);
        NumIslands([]).ShouldBe(0);
        NumIslands(ex1).ShouldBe(1);
        NumIslands(ex2).ShouldBe(3);
    }
}
