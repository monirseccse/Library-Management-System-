using Domain.Common;
using Domain.Enum;

namespace Domain.Entities;

public class Book : BaseEntity
{
    public string Title { get; set; }
    public double Price { get; set; }
    public string Author { get; set; }
    public List<StudenBookIssueAndReturnDetail> Issues { get; set; }
}
