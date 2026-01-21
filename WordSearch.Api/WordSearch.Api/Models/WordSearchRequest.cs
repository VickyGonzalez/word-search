namespace WordSearch.Api.Models;

public class WordSearchRequest
{
    public List<List<char>> Matrix { get; set; } = [];
    public List<string> Words { get; set; } = [];
}
