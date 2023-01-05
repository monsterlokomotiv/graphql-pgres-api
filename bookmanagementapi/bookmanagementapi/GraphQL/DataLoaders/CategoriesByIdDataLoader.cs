using BookManagement.Domain;
using BookManagement.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.GraphQL.DataLoaders;

public class CategoriesByIdDataLoader : BatchDataLoader<long, Category>
{
    private readonly BooksDbContext _dbContext;
    public CategoriesByIdDataLoader(IBatchScheduler batchScheduler, 
        BooksDbContext dbContext,
        DataLoaderOptions? options = null) 
        : base(batchScheduler, options)
    {
        _dbContext = dbContext;
    }

    protected override async Task<IReadOnlyDictionary<long, Category>> LoadBatchAsync(IReadOnlyList<long> keys, CancellationToken cancellationToken)
    {
        return await _dbContext.Categories.Where(a => keys.Contains(a.Id))
            .ToDictionaryAsync(a => a.Id, cancellationToken);
    }
}
