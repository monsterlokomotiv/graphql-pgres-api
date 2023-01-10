using BookManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Infrastructure.EntityFramework;

public class BooksDbContext : DbContext
{
    public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options)
    {
    }

    
    public DbSet<Author> Authors { get; set; } = default!;
    public DbSet<Book> Books { get; set; } = default!;
    public DbSet<Category> Categories { get; set; } = default!;
    public DbSet<Series> Series { get; set; } = default!;
    public DbSet<Order> Orders { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLowerCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().HasKey(o => o.Id);
        modelBuilder.Entity<Order>().HasIndex(o => o.Id);
        modelBuilder.Entity<Order>()
            .Property(o => o.Id).IsRequired().UseIdentityColumn();
        modelBuilder.Entity<Order>()
            .Property(o => o.Address)
            .HasColumnType("jsonb");

        //builder.Property(o => o.Id).IsRequired().UseIdentityColumn();

        //builder.HasIndex(p => p.Id);
        //builder.HasIndex(p => p.Address.Person.FirstName);

        //builder.Property(o => o.Address)
        //    .HasColumnType("jsonb");
    }
}
