using Domain.Enum;

namespace Infrastructure.BusinessObjects;

public class StudenBookIssueAndReturnDetail
{
    public int BookId { get; set; }
    public int StudentId { get; set; }
    public DateTime? IssueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}
