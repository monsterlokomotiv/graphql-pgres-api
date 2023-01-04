using BookManagement.Application.Abstractions;
using BookManagement.Domain;

namespace BookManagement;

public class Query
{
    public Book[] GetBooks([Service] IBookRepository bookRepo) => bookRepo.GetAll().ToArray();

    public Book? GetBook([Service] IBookRepository bookRepo, int id) => bookRepo.Get(id);
}
