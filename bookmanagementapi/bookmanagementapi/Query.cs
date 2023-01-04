using BookManagement.Application.Abstractions;
using BookManagement.Domain;
using BookManagement.Infrastructure.InMemory;

namespace BookManagement;

public class Query
{
    private IBookRepository _bookRepository;
    public Query()
    {
        _bookRepository = new BookRepository();
    }

    public Book[] GetBooks() => _bookRepository.GetAll().ToArray();

    public Book? GetBook(int id) => _bookRepository.Get(id);
}
