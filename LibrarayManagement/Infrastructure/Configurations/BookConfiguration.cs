using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public sealed class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(p => p.Id).IsRequired();
        builder.Property(p => p.Title).IsRequired().HasMaxLength(256);
        builder.Property(p => p.Author).IsRequired().HasMaxLength(256);
        builder.Property(p => p.Price).HasPrecision(18, 2);
        builder.Property(p => p.Status)
           .HasConversion<string>().IsRequired();

        builder.HasMany(p => p.Issues).WithOne(p => p.Book).HasForeignKey(p => p.BookId);
    }
}
