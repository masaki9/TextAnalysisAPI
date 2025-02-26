using TextAnalysisAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace TextAnalysisAPI.Controllers;

/// <summary>
/// Controller for handling text analysis requests.
/// </summary>
[ApiController]
[Route("[controller]")]
public class TextAnalysisController : ControllerBase
{
    private readonly ITextAnalysisService _textService;

    /// <summary>
    /// Constructor for TextAnalysisController.
    /// </summary>
    /// <param name="textService"></param>
    public TextAnalysisController(ITextAnalysisService textService)
    {
        _textService = textService;
    }

    /// <summary>
    /// Analyze the uploaded text file and return the top 8 longest words.
    /// </summary>
    /// <param name="file">Text file to analyze</param>
    /// <response code="200">Returns the top 8 longest words found in the text.</response>
    /// <response code="400">Bad Request if the file is empty or null.</response>
    /// <returns></returns>
    [HttpPost("analysis")]
    public async Task<IActionResult> AnalyzeTextFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("File is empty or null.");
        }

        // Get the top 8 longest words from the text file
        var words = await _textService.GetTopLongestWords(file, 8);
        return Ok(words);
    }
}
