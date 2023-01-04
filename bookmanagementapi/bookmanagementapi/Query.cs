using BookManagement.Application.Abstractions;
using BookManagement.Domain;

namespace BookManagement;

public class Query
{
    public Book[] GetBooks(IBookRepository bookRepo) => bookRepo.GetAll().ToArray();

    public Book? GetBook(IBookRepository bookRepo, long id) => bookRepo.Get(id);
    public Author? GetAuthor(IAuthorRepository authorRepo, long id) => authorRepo.Get(id);
}
