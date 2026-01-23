using Microsoft.AspNetCore.Mvc;
using WordSearch.Api.DTOs;
using WordSearch.Api.Services;

namespace WordSearch.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WordSearchController : ControllerBase
{
    private readonly IWordSearchService _service;

    public WordSearchController(IWordSearchService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Search([FromBody] WordSearchRequestDto request)
    {
        try
        {
            var result = _service.Search(request);
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch
        {
            return StatusCode(500, new { message = "Unexpected server error." });
        }
    }
}