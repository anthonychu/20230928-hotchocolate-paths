public class Book
{
    public string Title { get; set; } = "";
    public Author? Author { get; set; }
}

public class Author
{
    public string Name { get; set; } = "";
    public string? WorldId { get; set; }
}

public class Query
{
    public Book GetBook([Service] IHttpContextAccessor contextAccessor)
    {
        var worldId = contextAccessor?.HttpContext?.Items["worldId"] as string;
        return new Book
        {
            Title = "C# in depth.",
            Author = new Author
            {
                Name = "Jon Skeet",
                WorldId = worldId
            }
        };
    }
}
