using BookManagement.Domain;
using BookManagement.GraphQL.DataLoaders;
using BookManagement.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.GraphQL.Queries;

public partial class Query
{
    
    public Task<Author> GetAuthor(AuthorsByIdDataLoader dataLoader, long id, CancellationToken cancellationToken) =>
        dataLoader.LoadAsync(id, cancellationToken);

    [UseProjection]
    public IQueryable<Order> GetOrders(BooksDbContext context) => context.Orders;

    [UseProjection]
    public IQueryable<Order> GetOrdersByReceiverName(BooksDbContext context, string firstName) => context.Orders.Where(o => o.Address.Person.FirstName.Contains(firstName)).AsQueryable();
}
