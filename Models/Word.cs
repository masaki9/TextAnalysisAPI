namespace TextAnalysisAPI.Models;

/// <summary>
/// Represents a word in a text file.
/// </summary>
public class Word
{
    public string Text { get; private set; }
    public int Length => Text.Length;

    /// <summary>
    /// Constructor for Word.
    /// </summary>
    /// <param name="text"></param>
    public Word(string text)
    {
        Text = text.ToLower(); // Convert the word to lowercase
    }
}
