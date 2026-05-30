using System;
using System.Collections.Generic;

/// <summary>
/// Represents a YouTube video with title, author, length, and comments.
/// </summary>
public class Video
{
    private readonly string _title;
    private readonly string _author;
    private readonly int _length;
    private readonly List<Comment> _comments;

    /// <summary>
    /// Initializes a new instance of the Video class.
    /// </summary>
    /// <param name="title">The title of the video.</param>
    /// <param name="author">The author of the video.</param>
    /// <param name="length">The length of the video in seconds.</param>
    /// <exception cref="ArgumentNullException">Thrown when title or author is null or empty.</exception>
    /// <exception cref="ArgumentException">Thrown when length is negative.</exception>
    public Video(string title, string author, int length)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentNullException(nameof(title), "Video title cannot be null or empty.");
        if (string.IsNullOrWhiteSpace(author))
            throw new ArgumentNullException(nameof(author), "Video author cannot be null or empty.");
        if (length < 0)
            throw new ArgumentException("Video length cannot be negative.", nameof(length));

        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    /// <summary>
    /// Gets the title of the video.
    /// </summary>
    public string Title => _title;

    /// <summary>
    /// Gets the author of the video.
    /// </summary>
    public string Author => _author;

    /// <summary>
    /// Gets the length of the video in seconds.
    /// </summary>
    public int Length => _length;

    /// <summary>
    /// Gets the number of comments on the video.
    /// </summary>
    public int CommentCount => _comments.Count;

    /// <summary>
    /// Adds a comment to the video.
    /// </summary>
    /// <param name="comment">The comment to add.</param>
    /// <exception cref="ArgumentNullException">Thrown when comment is null.</exception>
    public void AddComment(Comment comment)
    {
        if (comment == null)
            throw new ArgumentNullException(nameof(comment), "Comment cannot be null.");
        
        _comments.Add(comment);
    }

    /// <summary>
    /// Gets a read-only copy of the comments list.
    /// </summary>
    /// <returns>A read-only collection of comments.</returns>
    public IReadOnlyList<Comment> GetComments()
    {
        return _comments.AsReadOnly();
    }
}