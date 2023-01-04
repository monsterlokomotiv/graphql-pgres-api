namespace BookManagement.Domain;

public class Book
{
    public long Id { get; set; }
    
    public string Description { get; set; } = string.Empty;
    public DateOnly PublishedDate { get; set; } = DateOnly.MinValue;
    public string Title { get; set; } = string.Empty;

    public virtual ICollection<Author> Authors { get; set; } = Array.Empty<Author>();
}
