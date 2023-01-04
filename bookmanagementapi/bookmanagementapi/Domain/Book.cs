namespace BookManagement.Domain;

public class Book
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateOnly PublishedDate { get; set; } = DateOnly.MinValue;
    
    public virtual IEnumerable<Author> Authors { get; set; } = Array.Empty<Author>();
}
