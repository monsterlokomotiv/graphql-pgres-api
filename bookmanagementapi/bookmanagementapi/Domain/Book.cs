namespace BookManagement.Domain;

public class Book
{
    public long Id { get; set; }
    
    public string Description { get; set; } = string.Empty;
    public DateOnly PublishedDate { get; set; } = DateOnly.MinValue;
    public string Title { get; set; } = string.Empty;

    public long CategoryId { get; set; }
    public virtual Category Category { get; set; } = default!;
    public virtual Publisher Publisher { get; set; } = default!;
    public long SeriesId { get; set; }
    public virtual Series Series { get; set; } = default!;
    public virtual ICollection<Author> Authors { get; set; } = default!;
}
