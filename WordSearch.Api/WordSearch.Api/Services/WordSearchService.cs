using WordSearch.Api.DTOs;
using WordSearch.Api.Utils;

namespace WordSearch.Api.Services;

public class WordSearchService : IWordSearchService
{
    public WordSearchResponseDto Search(WordSearchRequestDto request)
    {       
        var matrix = request.Matrix
            .Select(r => r.Trim().ToLowerInvariant().ToCharArray().ToList())
            .ToList();

        var words = request.Words
            .Select(w => w.Trim().ToLowerInvariant())
            .Where(w => !string.IsNullOrWhiteSpace(w))
            .Distinct()
            .ToList();

        MatrixValidator.Validate(matrix, words);

        var foundWords = new List<FoundWordDto>();

        foreach (var word in words)
        {
            var positions = FindWord(matrix, word);
            if (positions.Any())
            {
                foundWords.Add(new FoundWordDto
                {
                    Word = word,
                    Positions = positions
                });
            }
        }

        return new WordSearchResponseDto
        {
            FoundWords = foundWords
        };
    }

    private List<PositionDto> FindWord(List<List<char>> matrix, string word)
    {
        int rows = matrix.Count;
        int cols = matrix[0].Count;
        var result = new List<PositionDto>();
               
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c <= cols - word.Length; c++)
            {
                if (MatchHorizontal(matrix, word, r, c))
                {
                    for (int i = 0; i < word.Length; i++)
                        result.Add(new PositionDto { Row = r, Col = c + i });
                }
            }
        }

      
        for (int c = 0; c < cols; c++)
        {
            for (int r = 0; r <= rows - word.Length; r++)
            {
                if (MatchVertical(matrix, word, r, c))
                {
                    for (int i = 0; i < word.Length; i++)
                        result.Add(new PositionDto { Row = r + i, Col = c });
                }
            }
        }

        return result;
    }

    private bool MatchHorizontal(List<List<char>> matrix, string word, int row, int col)
    {
        for (int i = 0; i < word.Length; i++)
            if (matrix[row][col + i] != word[i])
                return false;

        return true;
    }

    private bool MatchVertical(List<List<char>> matrix, string word, int row, int col)
    {
        for (int i = 0; i < word.Length; i++)
            if (matrix[row + i][col] != word[i])
                return false;

        return true;
    }
}
