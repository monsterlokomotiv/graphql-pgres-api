using BookManagement.Domain;
using BookManagement.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace BookManagement;

public class Query
{
    public Book[] GetBooks(BooksDbContext context) => context.Books.ToArray();

    public Book[] GetBook(BooksDbContext context, long id) => context.Books.Where(b => b.Id == id).Include(b => b.Authors).ToArray();
    public Author[] GetAuthor(BooksDbContext context, long id) => context.Authors.Where(a => a.Id == id).ToArray();
}
