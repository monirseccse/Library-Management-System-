using Domain.Common;
using Domain.Enum;

namespace Domain.Entities;

public class StudenBookIssueAndReturnDetail : BaseEntity
{
    public int BookId { get; set; }
    public int StudentId { get; set; }
    public DateTime? IssueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public IssueStatus IssueStatus { get; set; }
    public Book Book { get; set; }
    public Student Student { get; set; }
}
