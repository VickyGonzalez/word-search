namespace WordSearch.Api.DTOs;

public class FoundWordDto
{
    public string Word { get; set; } = string.Empty;
    public List<PositionDto> Positions { get; set; } = new();
}
