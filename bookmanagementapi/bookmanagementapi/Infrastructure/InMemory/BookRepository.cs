using BookManagement.Application.Abstractions;
using BookManagement.Domain;

namespace BookManagement.Infrastructure.InMemory;

public class BookRepository : IBookRepository
{
    private readonly List<Book> _books = new()
    {

    };

    public Book? Get(int id)
    {
        return _books.FirstOrDefault(b => b.Id == id);
    }

    public IEnumerable<Book> GetAll()
    {
        return _books.ToArray();
    }
}
