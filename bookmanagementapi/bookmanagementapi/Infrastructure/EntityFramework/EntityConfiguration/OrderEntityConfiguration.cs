using BookManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManagement.Infrastructure.EntityFramework.EntityConfiguration;

public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        //builder.Property(o => o.Id).IsRequired().UseIdentityColumn();

        //builder.HasIndex(p => p.Id);
        //builder.HasIndex(p => p.Address.Person.FirstName);

        //builder.Property(o => o.Address)
        //    .HasColumnType("jsonb");
    }
}
