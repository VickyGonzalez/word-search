namespace WordSearch.Api.Utils;

public static class MatrixValidator
{
    public static void Validate(List<List<char>> matrix, List<string> words)
    {
        if (matrix == null || matrix.Count == 0)
            throw new ArgumentException("Matrix cannot be empty.");

        if (matrix.Count > 64)
            throw new ArgumentException("Matrix cannot have more than 64 rows.");

        int columnCount = matrix[0].Count;

        if (columnCount == 0 || columnCount > 64)
            throw new ArgumentException("Matrix columns must be between 1 and 64.");

        foreach (var row in matrix)
        {
            if (row == null)
                throw new ArgumentException("Matrix rows cannot be null.");

            if (row.Count != columnCount)
                throw new ArgumentException("All matrix rows must have the same length.");
        }

        if (words == null || words.Count == 0)
            throw new ArgumentException("Words list cannot be empty.");
    }
}
