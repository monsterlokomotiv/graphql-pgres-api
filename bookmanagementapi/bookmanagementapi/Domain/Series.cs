namespace BookManagement.Domain;

public class Series
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public virtual ICollection<Author> Authors { get; set; } = default!;
    public virtual ICollection<Book> Books { get; set; } = default!;
    
}
