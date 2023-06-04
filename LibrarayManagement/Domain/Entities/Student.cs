using Domain.Common;

namespace Domain.Entities;

public class Student : BaseEntity
{
    public string Name { get; set; }
    public string Class { get; set; }

    public List<StudenBookIssueAndReturnDetail> Issues { get; set; }
}
