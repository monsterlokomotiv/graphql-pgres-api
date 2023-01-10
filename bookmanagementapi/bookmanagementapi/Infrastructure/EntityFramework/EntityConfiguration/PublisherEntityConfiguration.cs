using BookManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManagement.Infrastructure.EntityFramework.EntityConfiguration;

public class PublisherEntityConfiguration : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .IsRequired()
            .UseIdentityColumn();

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.HasMany(p => p.Books)
            .WithOne(b => b.Publisher);
    }
}
