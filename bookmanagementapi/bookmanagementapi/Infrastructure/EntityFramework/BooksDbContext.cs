using BookManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Infrastructure.EntityFramework;

public class BooksDbContext : DbContext
{
    public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; } = default!;
    public DbSet<Author> Author { get; set; } = default!;
     
}
