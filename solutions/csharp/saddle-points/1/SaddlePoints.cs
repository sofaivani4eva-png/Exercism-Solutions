
using System.Collections.Generic;

public static class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int r = 0; r < rows; r++)
        {
            int maxInRow = matrix[r, 0];

            for (int c = 1; c < cols; c++)
            {
                if (matrix[r, c] > maxInRow)
                    maxInRow = matrix[r, c];
            }

            for (int c = 0; c < cols; c++)
            {
                if (matrix[r, c] != maxInRow)
                    continue;

                int minInColumn = matrix[0, c];

                for (int i = 1; i < rows; i++)
                {
                    if (matrix[i, c] < minInColumn)
                        minInColumn = matrix[i, c];
                }

                if (matrix[r, c] == minInColumn)
                    yield return (r + 1, c + 1);
            }
        }
    }
}