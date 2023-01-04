using BookManagement.Application.Abstractions;
using BookManagement.Domain;

namespace BookManagement.Infrastructure.InMemory;

public class AuthorRepository : IAuthorRepository
{
    private readonly List<Author> _authors = new()
    {
        new Author()
        {
            Id = 1,
            FirstName = "Darth",
            LastName = "Vader"
        },
        new Author()
        {
            Id = 2,
            FirstName = "Darth",
            LastName = "Maul"
        },
        new Author()
        {
            Id = 3,
            FirstName = "Obi-Wan",
            LastName = "Kenobi"
        }
    };

    public Author? Get(long id)
    {
        return _authors.FirstOrDefault(author => author.Id == id);
    }
}
