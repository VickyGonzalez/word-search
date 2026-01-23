namespace WordSearch.Api.DTOs;

public class WordSearchResponseDto
{
    public List<FoundWordDto> FoundWords { get; set; } = new();
}
