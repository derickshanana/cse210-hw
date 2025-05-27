public class Comment
{
    // Properties
    public string CommenterName { get; }
    public string Text { get; }

    // Constructor
    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }

    // Method to display comment information
    public override string ToString()
    {
        return $"{CommenterName}: {Text}";
    }
}
public class Video
{
    // Properties
    public string Title { get; }
    public string Author { get; }
    public int LengthInSeconds { get; }
    private List<Comment> _comments = new List<Comment>();

    // Constructor
    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
    }

    // Method to add a comment
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Method to get number of comments
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    // Method to display all comments
    public void DisplayComments()
    {
        foreach (var comment in _comments)
        {
            Console.WriteLine($" - {comment}");
        }
    }

    // Method to display video information
    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthInSeconds} seconds");
        Console.WriteLine($"Number of comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");
        DisplayComments();
        Console.WriteLine();
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Create videos
        var video1 = new Video("C# Tutorial for Beginners", "Programming Guru", 1200);
        var video2 = new Video("Learn Python in 1 Hour", "Code Master", 3600);
        var video3 = new Video("Introduction to Machine Learning", "AI Enthusiast", 2400);
        var video4 = new Video("Web Development Crash Course", "Web Wizard", 1800);

        // Add comments to video1
        video1.AddComment(new Comment("User1", "Great tutorial!"));
        video1.AddComment(new Comment("User2", "Very helpful for beginners."));
        video1.AddComment(new Comment("User3", "Can you make one about OOP?"));

        // Add comments to video2
        video2.AddComment(new Comment("PythonFan", "Excellent content!"));
        video2.AddComment(new Comment("Newbie", "I learned so much in one hour."));
        video2.AddComment(new Comment("Coder123", "Clear and concise explanations."));
        video2.AddComment(new Comment("DevPro", "Best Python tutorial I've seen!"));

        // Add comments to video3
        video3.AddComment(new Comment("AILover", "Fascinating introduction!"));
        video3.AddComment(new Comment("Student42", "Would love more examples."));
        video3.AddComment(new Comment("TechEnthusiast", "When is the next part coming?"));

        // Add comments to video4
        video4.AddComment(new Comment("WebDev", "Perfect crash course!"));
        video4.AddComment(new Comment("FrontendFan", "Covered all the basics."));
        video4.AddComment(new Comment("BackendPro", "Nice overview of web technologies."));

        // Create list of videos
        var videos = new List<Video> { video1, video2, video3, video4 };

        // Display information for each video
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}