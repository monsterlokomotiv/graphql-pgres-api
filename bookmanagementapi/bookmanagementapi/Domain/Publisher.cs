namespace BookManagement.Domain;

public class Publisher
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public virtual ICollection<Book> Books { get; set; } = default!;
}
