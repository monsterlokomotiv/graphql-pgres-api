using BookManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data.SqlTypes;

namespace BookManagement.Infrastructure.EntityFramework.EntityConfiguration
{
    public class BookEntityConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.HasIndex(x => x.Title);
            builder.HasIndex(x => x.PublishedDate);

            builder.Property(b => b.Id)
                .UseIdentityColumn();

            builder.Property(b => b.Description)
                .IsRequired()
                .HasMaxLength(1024)
                .HasDefaultValue(string.Empty);

            builder.Property(b => b.PublishedDate)
                .HasDefaultValue(DateOnly.FromDateTime((DateTime)SqlDateTime.MinValue));

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasOne(book => book.Category).WithMany(x => x.Books);
            builder.HasMany(book => book.Authors).WithMany(auth => auth.Books);
        }
    }
}
