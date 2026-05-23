/// <summary>
/// Encapsulates the responsibilities of a scripture reference, including handling single and multiple verses.
/// </summary>
public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    /// <summary>
    /// Initializes a new reference with a single verse.
    /// </summary>
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = verse;
    }

    /// <summary>
    /// Initializes a new reference with a range of verses.
    /// </summary>
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    /// <summary>
    /// Returns a string representation of the reference in the format "Book Chapter:Verse" or "Book Chapter:StartVerse-EndVerse".
    /// </summary>
    public override string ToString()
    {
        if (_startVerse == _endVerse)
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }

        return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
    }
}