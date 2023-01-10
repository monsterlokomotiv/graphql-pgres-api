using BookManagement.Domain;
using BookManagement.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.GraphQL.DataLoaders;

public class OrdersByIdDataLoader : BatchDataLoader<long, Order>
{
    private readonly BooksDbContext _dbContext;

    public OrdersByIdDataLoader(IBatchScheduler scheduler, 
        BooksDbContext dbContext)
        : base(scheduler)
    {
        _dbContext = dbContext;
    }

    protected async override Task<IReadOnlyDictionary<long, Order>> LoadBatchAsync(IReadOnlyList<long> keys, CancellationToken cancellationToken)
    {
        return await _dbContext.Orders.Where(a => keys.Contains(a.Id))
            .ToDictionaryAsync(a => a.Id, cancellationToken);
    }
}
