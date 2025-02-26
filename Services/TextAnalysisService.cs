using TextAnalysisAPI.Models;

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
    public async Task<List<string>> GetTopLongestWords(IFormFile file, int topCount)
    {
        using var reader = new StreamReader(file.OpenReadStream());
        var fullText = await reader.ReadToEndAsync();
        var words = fullText.Split(new char[] { ' ', '\n', '\r', ',', '.', '!', '?' },
                            StringSplitOptions.RemoveEmptyEntries)
                            .Select(word => new Word(word)) // Create Word objects
                            .DistinctBy(word => word.Text) // Remove duplicates
                            .OrderByDescending(word => word.Length) // Order by word length
                            .Take(topCount) // Get the top longest words
                            .Select(word => word.Text) // Convert to list of strings
                            .ToList();

        return words;
    }
}
