using System;

class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    // Constructor
    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }

    // Method to display comment
    public override string ToString()
    {
        return $"{Name}: {Text}";
    }
}

// Video class to track video details and associated comments
class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // Length in seconds
    public List<Comment> Comments { get; set; }

    // Constructor
    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>(); // Initialize the list of comments
    }

    // Method to add a comment to the video
    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    // Method to get the number of comments
    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    // Method to display video details
    public void DisplayVideoDetails()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");

        // Display all comments
        foreach (var comment in Comments)
        {
            Console.WriteLine($"  - {comment}");
        }
        Console.WriteLine(); // For separating videos
    }
}


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

        Video video1 = new Video("How to Code in C#", "John Doe", 600);
        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "I learned so much!"));

        Video video2 = new Video("Introduction to C# Programming", "Jane Smith", 500);
        video2.AddComment(new Comment("Charlie", "This was very helpful!"));
        video2.AddComment(new Comment("Dana", "Can you explain the basics again?"));

        Video video3 = new Video("Advanced C# Features", "Alice Johnson", 720);
        video3.AddComment(new Comment("Eve", "Amazing content!"));
        video3.AddComment(new Comment("Frank", "Very detailed, thanks!"));

        // Storing videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Iterating through the list of videos and displaying their details
        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
        }

    }
}