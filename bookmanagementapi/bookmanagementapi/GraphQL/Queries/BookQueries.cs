using BookManagement.Domain;
using BookManagement.Infrastructure.EntityFramework;

namespace BookManagement.GraphQL.Queries;

public partial class Query
{
    //[UsePaging]
    //[UseProjection]
    //[UseFiltering]
    //[UseSorting]
    //public IQueryable<Book> GetBooks(BooksDbContext context) => context.Books;

    [UseProjection]
    [UseSorting]
    public IQueryable<Book> GetBooks(BooksDbContext context, BookFilterCriteriaDto criteria)
    {
        var bookQuery = context.Books.AsQueryable();
        if(criteria.Id != null && criteria.Id != 0)
            bookQuery = bookQuery.Where(b => b.Id == criteria.Id);

        if(!string.IsNullOrEmpty(criteria.Title))
            bookQuery = bookQuery.Where(b => b.Title.Contains(criteria.Title));

        return bookQuery;
    }
}

public class BookFilterCriteriaDto
{
    public long? Id { get; set; } = 0;
    public string Title { get; set; } = string.Empty;
}