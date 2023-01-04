namespace BookManagement.Domain;

public class Author
{
    public long Id { get; set; }

    public DateOnly BirthDay { get; set; } = DateOnly.MinValue;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public ReadOnlySpan<char> FullName => (FirstName + LastName).AsSpan();

    public virtual ICollection<Book> Books { get; set; }
}
