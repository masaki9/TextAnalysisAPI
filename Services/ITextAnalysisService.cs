namespace TextAnalysisAPI.Services;

/// <summary>
/// Interface for text service.
/// </summary>
public interface ITextAnalysisService
{
    /// <summary>
    /// Get the top longest words from a text file.
    /// </summary>
    /// <param name="file">Text file to analyze</param>
    /// <param name="topCount">Top count of longest words to return</param>
    /// <returns></returns>
    Task<List<string>> GetTopLongestWords(IFormFile file, int topCount);
}
