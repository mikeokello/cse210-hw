using System;
using System.Collections.Generic;

/// <summary>
/// Main entry point for the YouTube Videos application.
/// Demonstrates creating videos with comments and displaying their information.
/// </summary>
class Program
{
    /// <summary>
    /// Main method that creates sample videos and displays their information.
    /// </summary>
    static void Main(string[] args)
    {
        try
        {
            // Create videos
            Video video1 = new Video("Learn C# Basics", "Programming Hub", 600);
            Video video2 = new Video("Object-Oriented Programming Explained", "Code Academy", 850);
            Video video3 = new Video("How to Build a Console App", "Tech Tutorials", 720);

            // Add comments to video 1
            video1.AddComment(new Comment("John", "Very helpful tutorial!"));
            video1.AddComment(new Comment("Sarah", "I finally understand C# basics."));
            video1.AddComment(new Comment("Mike", "Great explanation!"));

            // Add comments to video 2
            video2.AddComment(new Comment("Emma", "This made OOP easy to understand."));
            video2.AddComment(new Comment("Daniel", "Excellent teaching style."));
            video2.AddComment(new Comment("Grace", "Very informative video."));

            // Add comments to video 3
            video3.AddComment(new Comment("Peter", "This helped me build my first app."));
            video3.AddComment(new Comment("Linda", "Clear and easy to follow."));
            video3.AddComment(new Comment("James", "Thanks for sharing this tutorial."));

            // Store videos in a list
            List<Video> videos = new List<Video>
            {
                video1,
                video2,
                video3
            };

            // Display video information
            DisplayVideos(videos);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    /// <summary>
    /// Displays information about a collection of videos.
    /// </summary>
    /// <param name="videos">The list of videos to display.</param>
    private static void DisplayVideos(List<Video> videos)
    {
        foreach (Video video in videos)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length (seconds): {video.Length}");
            Console.WriteLine($"Number of Comments: {video.CommentCount}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  {comment.Name}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}