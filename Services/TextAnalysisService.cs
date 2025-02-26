namespace TextAnalysisAPI.Services;

/// <summary>
/// Service for text analysis.
/// </summary>
public class TextAnalysisService : ITextAnalysisService
{
    /// <summary>
    /// Get the top longest words from a text file.
    /// </summary>
    /// <param name="file">Text file to analyze</param>
    /// <param name="topCount">Top count of longest words to return</param>
    /// <returns></returns>
    public List<string> GetTopLongestWords(IFormFile file, int topCount)
    {
        using var reader = new StreamReader(file.OpenReadStream());
        var content = reader.ReadToEnd();
        var words = content.Split(new char[] { ' ', '\n', '\r', ',', '.', '!', '?' },
                                    StringSplitOptions.RemoveEmptyEntries)
                            .Select(word => word.Trim())
                            .OrderByDescending(word => word.Length)
                            .Take(topCount)
                            .ToList();
        return words;
    }
}
