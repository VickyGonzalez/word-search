namespace WordSearch.Api.DTOs;

public class WordSearchRequestDto
{
    public List<string> Matrix { get; set; } = new();
    public List<string> Words { get; set; } = new();
}
