using BookManagement.Domain;
using BookManagement.GraphQL.DataLoaders;
using BookManagement.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.GraphQL.Queries;

public class Query
{
    public Book[] GetBooks(BooksDbContext context) => context.Books.ToArray();

    public Task<Book[]> GetBook(BooksDbContext context, long id) => context.Books.Where(b => b.Id == id).Include(b => b.Authors).ToArrayAsync();
    public Task<Author> GetAuthor(AuthorsByIdDataLoader dataLoader, long id, CancellationToken cancellationToken) =>
        dataLoader.LoadAsync(id, cancellationToken);
}
