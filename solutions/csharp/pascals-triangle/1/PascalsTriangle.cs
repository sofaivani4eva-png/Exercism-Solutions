
using System.Collections.Generic;

public static class PascalsTriangle
{
    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
    {
        var triangle = new List<IEnumerable<int>>();
        var previousRow = new List<int>();

        for (int i = 0; i < rows; i++)
        {
            var currentRow = new List<int>();

            currentRow.Add(1);

            for (int j = 1; j < i; j++)
            {
                currentRow.Add(previousRow[j - 1] + previousRow[j]);
            }

            if (i > 0)
            {
                currentRow.Add(1);
            }

            triangle.Add(currentRow);
            previousRow = currentRow;
        }

        return triangle;
    }
}