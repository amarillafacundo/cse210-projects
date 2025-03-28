using System;

class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    
    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }

    
    public override string ToString()
    {
        return $"{Name}: {Text}";
    }
}


class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } 
    public List<Comment> Comments { get; set; }

    
    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>(); 
    }

    
    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    
    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    
    public void DisplayVideoDetails()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");

        
        foreach (var comment in Comments)
        {
            Console.WriteLine($"  - {comment}");
        }
        Console.WriteLine(); 
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

        
        List<Video> videos = new List<Video> { video1, video2, video3 };

        
        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
        }

    }
}