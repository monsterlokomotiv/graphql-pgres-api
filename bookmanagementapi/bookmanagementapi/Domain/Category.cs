namespace BookManagement.Domain;

public class Category
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
