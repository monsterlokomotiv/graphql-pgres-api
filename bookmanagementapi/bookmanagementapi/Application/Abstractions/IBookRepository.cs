using BookManagement.Domain;

namespace BookManagement.Application.Abstractions;

public interface IBookRepository
{
    IEnumerable<Book> GetAll();
    Book? Get(int id);
}
