/// <summary>
/// Encapsulates the responsibilities of a word, including managing its text and shown/hidden state.
/// </summary>
public class Word
{
    private string _text;
    private bool _isHidden;

    /// <summary>
    /// Initializes a new word with the specified text.
    /// </summary>
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    /// <summary>
    /// Hides the word by marking it as hidden.
    /// </summary>
    public void Hide()
    {
        _isHidden = true;
    }

    /// <summary>
    /// Determines if the word is hidden.
    /// </summary>
    public bool IsHidden()
    {
        return _isHidden;
    }

    /// <summary>
    /// Returns a string representation of the word. If hidden, returns underscores matching the word length.
    /// </summary>
    public override string ToString()
    {
        if (_isHidden)
        {
            return new string('_', _text.Length);
        }

        return _text;
    }
}