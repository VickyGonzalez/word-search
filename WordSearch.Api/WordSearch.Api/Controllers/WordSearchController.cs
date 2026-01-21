using Microsoft.AspNetCore.Mvc;
using WordSearch.Api.Models;
using WordSearch.Api.Services.Interfaces;

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
    public IActionResult FindWords([FromBody] WordSearchRequest request)
    {
        try
        {
            var result = _service.FindWords(request);
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(500, new { error = "Internal server error" });
        }
    }

}
