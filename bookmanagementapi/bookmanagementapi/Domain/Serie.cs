namespace BookManagement.Domain;

public class Serie
{
    public long Id { get; set; }
    public ICollection<Author> Authors { get; set; } = Array.Empty<Author>();
    public ICollection<Book> Books { get; set; } = Array.Empty<Book>();
    
}
