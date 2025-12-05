namespace DayFour;

internal static class GridNav
{
    public static int CountSurroundingPapers(this char[,] grid, int x, int y)
    {
        int surroundingPaperCount = 0;

        // if 5,5
        // x = row
        // y = column

        // check up
        if (IsPaper(grid, x - 1, y))
            surroundingPaperCount++;

        // check up/right
        if (IsPaper(grid, x - 1, y + 1))
            surroundingPaperCount++;

        // check right
        if (IsPaper(grid, x, y + 1))
            surroundingPaperCount++;

        // check right/down
        if (IsPaper(grid, x + 1, y + 1))
            surroundingPaperCount++;

        // check down
        if (IsPaper(grid, x + 1, y))
            surroundingPaperCount++;

        // check down/left
        if (IsPaper(grid, x + 1, y - 1))
            surroundingPaperCount++;

        // check left
        if (IsPaper(grid, x, y - 1))
            surroundingPaperCount++;

        // check up/left
        if (IsPaper(grid, x - 1, y - 1))
            surroundingPaperCount++;

        return surroundingPaperCount;
    }

    public static char[,] ScanGrid(this char[,] grid)
    {
        var updatedGrid = grid;

        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                if (grid[i, j] == '@')
                {
                    var paperCount = grid.CountSurroundingPapers(i, j);

                    if (paperCount < 4)
                    {
                        updatedGrid[i, j] = 'X';
                    }
                }
            }
        }

        return updatedGrid;
    }

    public static int CountValidPapers(this char[,] grid)
    {
        int totalValidPapers = 0;

        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                if (grid[i, j] == 'X')
                {
                    totalValidPapers++;
                }
            }
        }

        return totalValidPapers;
    }


    public static char[,] CleanGrid(this char[,] grid)
    {
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                if (grid[i, j] == 'X')
                {
                    grid[i, j] = '.';
                }
            }
        }

        return grid;
    }

    public static void Print(this char[,] grid)
    {
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                Console.Write(grid[i, j]);
            }

            Console.WriteLine();
        }
    }

    private static bool IsPaper(char[,] grid, int x, int y)
    {
        if (x < 0 || y < 0)
        {
            return false;
        }

        if (x >= grid.GetLength(0) || y >= grid.GetLength(1))
        {
            return false;
        }

        return grid[x, y] == '@' || grid[x,y] == 'X';
    }


}
