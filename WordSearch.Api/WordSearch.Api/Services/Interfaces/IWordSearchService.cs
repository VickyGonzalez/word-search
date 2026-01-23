using WordSearch.Api.DTOs;

namespace WordSearch.Api.Services;

public interface IWordSearchService
{
    WordSearchResponseDto Search(WordSearchRequestDto request);
}
