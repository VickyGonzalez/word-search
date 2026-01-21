using WordSearch.Api.Models;

namespace WordSearch.Api.Services.Interfaces;

public interface IWordSearchService
{
    WordSearchResponse FindWords(WordSearchRequest request);
}