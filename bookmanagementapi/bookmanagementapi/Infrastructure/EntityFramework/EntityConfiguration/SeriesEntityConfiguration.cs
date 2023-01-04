using BookManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManagement.Infrastructure.EntityFramework.EntityConfiguration
{
    public class SeriesEntityConfiguration : IEntityTypeConfiguration<Series>
    {
        public void Configure(EntityTypeBuilder<Series> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasIndex(s => s.Name);

            builder.Property(s => s.Id)
                .UseIdentityColumn();

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(250);

            builder.HasMany(ser => ser.Books).WithOne(book => book.Series);
            builder.HasMany(ser => ser.Authors).WithMany(auth => auth.Series);
        }
    }
}
