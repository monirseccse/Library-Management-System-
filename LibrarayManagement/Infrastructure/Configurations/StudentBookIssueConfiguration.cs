using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class StudentBookIssueConfiguration : IEntityTypeConfiguration<StudenBookIssueAndReturnDetail>
{
    public void Configure(EntityTypeBuilder<StudenBookIssueAndReturnDetail> builder)
    {
        builder.Property(p => p.Id).IsRequired();
        builder.Property(p => p.BookId).IsRequired();
        builder.Property(p => p.StudentId).IsRequired();
        builder.Property(p => p.IssueStatus)
            .HasConversion<string>().IsRequired();

        builder.Property(p => p.IssueDate).IsRequired(false);
        builder.Property(p => p.ReturnDate).IsRequired(false);
    }
}
