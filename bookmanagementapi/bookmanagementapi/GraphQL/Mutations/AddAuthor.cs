using BookManagement.Domain;

namespace BookManagement.GraphQL.Mutations;

public record AddAuthorInput(DateOnly BirthDay, string FirstName, string LastName);

public class AddAuthorPayload
{
    public AddAuthorPayload(Author author)
    {
        Author = author;
    }

    public Author Author { get; }
}
