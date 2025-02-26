using TextAnalysisAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace TextAnalysisAPI.Controllers;

[ApiController]
[Route("[controller]")]
/// <summary>
/// Controller for handling text analysis requests.
/// </summary>
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

    [HttpPost("analysis")]
    /// <summary>
    /// Analyze the uploaded text file and return the top 8 longest words.
    /// </summary>
    /// <param name="file">Text file to analyze</param>
    /// <returns></returns>
    public IActionResult AnalyzeTextFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

        // Get the top 8 longest words from the text file
        var words = _textService.GetTopLongestWords(file, 8);
        return Ok(words);
    }
}