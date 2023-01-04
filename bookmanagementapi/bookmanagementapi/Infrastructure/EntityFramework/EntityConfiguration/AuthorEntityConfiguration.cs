using BookManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data.SqlTypes;

namespace BookManagement.Infrastructure.EntityFramework.EntityConfiguration;

public class AuthorEntityConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(a => a.Id);
        builder.HasIndex(a => a.FirstName);
        builder.HasIndex(a => a.LastName);

        builder.Property(a => a.Id)
            .UseIdentityColumn();

        builder.Property(a => a.FirstName)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(a => a.LastName)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(a => a.BirthDay)
            .HasDefaultValue(DateOnly.FromDateTime((DateTime)SqlDateTime.MinValue));

        builder.HasMany(a => a.Books).WithMany(b => b.Authors);
    }
}
