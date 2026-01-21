using WordSearch.Api.Models;
using WordSearch.Api.Services.Interfaces;
using WordSearch.Api.Utils;

namespace WordSearch.Api.Services;

public class WordSearchService : IWordSearchService
{
    public WordSearchResponse FindWords(WordSearchRequest request)
    {
        MatrixValidator.Validate(request.Matrix, request.Words);

        var foundWords = new HashSet<string>();
        var matrix = request.Matrix;
        int rows = matrix.Count;
        int cols = matrix[0].Count;

        foreach (var word in request.Words.Distinct())
        {
            if (ExistsInMatrix(matrix, rows, cols, word))
            {
                foundWords.Add(word);
            }
        }

        return new WordSearchResponse
        {
            FoundWords = foundWords.ToList()
        };
    }

    private bool ExistsInMatrix(List<List<char>> matrix, int rows, int cols, string word)
    {
        int length = word.Length;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                // Horizontal →
                if (j + length <= cols && MatchHorizontal(matrix, i, j, word))
                    return true;

                // Vertical ↓
                if (i + length <= rows && MatchVertical(matrix, i, j, word))
                    return true;
            }
        }

        return false;
    }

    private bool MatchHorizontal(List<List<char>> matrix, int row, int col, string word)
    {
        for (int k = 0; k < word.Length; k++)
        {
            if (matrix[row][col + k] != word[k])
                return false;
        }
        return true;
    }

    private bool MatchVertical(List<List<char>> matrix, int row, int col, string word)
    {
        for (int k = 0; k < word.Length; k++)
        {
            if (matrix[row + k][col] != word[k])
                return false;
        }
        return true;
    }
}
