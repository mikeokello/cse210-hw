/// <summary>
/// Represents a comment on a video.
/// </summary>
public class Comment
{
    private readonly string _name;
    private readonly string _text;

    /// <summary>
    /// Initializes a new instance of the Comment class.
    /// </summary>
    /// <param name="name">The name of the person making the comment.</param>
    /// <param name="text">The text content of the comment.</param>
    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
    }

    /// <summary>
    /// Gets the name of the person who made the comment.
    /// </summary>
    public string Name => _name;

    /// <summary>
    /// Gets the text content of the comment.
    /// </summary>
    public string Text => _text;
}