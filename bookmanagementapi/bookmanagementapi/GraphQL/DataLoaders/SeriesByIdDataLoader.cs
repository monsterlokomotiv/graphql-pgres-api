using BookManagement.Domain;
using BookManagement.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.GraphQL.DataLoaders;

public class SeriesByIdDataLoader : BatchDataLoader<long, Series>
{
    private readonly BooksDbContext _dbContext;

    public SeriesByIdDataLoader(IBatchScheduler batchScheduler,
        BooksDbContext dbContext,
        DataLoaderOptions? options = null) 
        : base(batchScheduler, options)
    {
        _dbContext = dbContext;
    }

    protected override async Task<IReadOnlyDictionary<long, Series>> LoadBatchAsync(IReadOnlyList<long> keys, CancellationToken cancellationToken)
    {
        return await _dbContext.Series.Where(s => keys.Contains(s.Id))
        .ToDictionaryAsync(s => s.Id, cancellationToken);
    }
}
