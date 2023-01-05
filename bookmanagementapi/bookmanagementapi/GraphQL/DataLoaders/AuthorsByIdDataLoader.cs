using BookManagement.Domain;
using BookManagement.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.GraphQL.DataLoaders;

public class AuthorsByIdDataLoader : BatchDataLoader<long, Author>
{
    private readonly BooksDbContext _dbContext;

    public AuthorsByIdDataLoader(IBatchScheduler scheduler, 
        BooksDbContext dbContext)
        : base(scheduler)
    {
        _dbContext = dbContext;
    }

    protected async override Task<IReadOnlyDictionary<long, Author>> LoadBatchAsync(IReadOnlyList<long> keys, CancellationToken cancellationToken)
    {
        return await _dbContext.Authors.Where(a => keys.Contains(a.Id))
            .ToDictionaryAsync(a => a.Id, cancellationToken);
    }
}
