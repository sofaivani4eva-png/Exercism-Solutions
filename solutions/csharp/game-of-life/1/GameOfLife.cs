using System;

public static class GameOfLife
{
    public static int[,] Tick(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        int[,] nextGeneration = new int[rows, cols];

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                int aliveNeighbors = 0;

                for (int dr = -1; dr <= 1; dr++)
                {
                    for (int dc = -1; dc <= 1; dc++)
                    {
                        if (dr == 0 && dc == 0)
                            continue;

                        int nr = r + dr;
                        int nc = c + dc;

                        if (nr >= 0 && nr < rows &&
                            nc >= 0 && nc < cols)
                        {
                            aliveNeighbors += matrix[nr, nc];
                        }
                    }
                }

                if (matrix[r, c] == 1)
                {
                    if (aliveNeighbors == 2 || aliveNeighbors == 3)
                        nextGeneration[r, c] = 1;
                    else
                        nextGeneration[r, c] = 0;
                }
                else
                {
                    if (aliveNeighbors == 3)
                        nextGeneration[r, c] = 1;
                    else
                        nextGeneration[r, c] = 0;
                }
            }
        }

        return nextGeneration;
    }
}