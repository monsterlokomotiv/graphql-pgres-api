using BookManagement.Domain;

namespace BookManagement.Application.Abstractions;

public interface IBookRepository
{
    IEnumerable<Book> GetAll();
    Book? Get(long id);
    IEnumerable<Book> GetByAuthorName(string authorName);
    IEnumerable<Book> GetByTitle(string title);
}
