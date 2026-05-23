using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Encapsulates the responsibilities of a scripture, including managing its reference and words.
/// </summary>
public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    /// <summary>
    /// Initializes a new scripture with a reference and text.
    /// </summary>
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    /// <summary>
    /// Randomly hides the specified number of visible words.
    /// </summary>
    public void HideRandomWords(int numberToHide)
    {
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        Random random = new Random();

        for (int i = 0; i < numberToHide && visibleWords.Count > 0; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    /// <summary>
    /// Determines if all words in the scripture are hidden.
    /// </summary>
    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    /// <summary>
    /// Returns a string representation of the scripture with its reference and words.
    /// </summary>
    public override string ToString()
    {
        string text = string.Join(" ", _words);
        return $"{_reference} {text}";
    }
}