namespace BookManagement.Domain;

public class Author
{
    public long Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateOnly BirthDay { get; set; } = DateOnly.MinValue;
}
