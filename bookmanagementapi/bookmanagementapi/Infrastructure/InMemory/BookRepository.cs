using BookManagement.Application.Abstractions;
using BookManagement.Domain;

namespace BookManagement.Infrastructure.InMemory;

public class BookRepository : IBookRepository
{
    private readonly List<Book> _books = new()
    {
        new Book
        {
            Id = 1,
            Title = "TheFirstBook",
            Description = "My very first book :)",
            PublishedDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-3)),
            Authors = new [] 
            {
                new Author()
                {
                    Id = 1,
                    FirstName = "Darth",
                    LastName = "Vader"
                }
            }
        }
    };

    public Book? Get(int id)
    {
        return _books.FirstOrDefault(b => b.Id == id);
    }

    public IEnumerable<Book> GetAll()
    {
        return _books.ToArray();
    }

    public IEnumerable<Book> GetByAuthorName(string authorName)
    {
        return _books.Where(b => b.Authors.Any(author => author.FullName.Contains(authorName.AsSpan(), StringComparison.InvariantCultureIgnoreCase)));
    }

    public IEnumerable<Book> GetByTitle(string title)
    {
        return _books.Where(b => b.Title.Contains(title));
    }
}
