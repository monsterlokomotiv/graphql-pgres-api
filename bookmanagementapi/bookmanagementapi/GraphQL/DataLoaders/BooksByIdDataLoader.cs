using BookManagement.Domain;
using BookManagement.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.GraphQL.DataLoaders;

public class BooksByIdDataLoader : BatchDataLoader<long, Book>
{
    private readonly BooksDbContext _context;

    public BooksByIdDataLoader(IBatchScheduler batchScheduler, 
        BooksDbContext context,
        DataLoaderOptions? options = null) 
        : base(batchScheduler, options)
    {
        _context = context;
    }

    protected override async Task<IReadOnlyDictionary<long, Book>> LoadBatchAsync(IReadOnlyList<long> keys, CancellationToken cancellationToken)
    {
        return await _context.Books.Where(b => keys.Contains(b.Id))
            .ToDictionaryAsync(b => b.Id, cancellationToken);
    }
}
