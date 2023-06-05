using Domain.Entities;
using Domain.Repositories;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class StudentAndBookIssueReturnDetailsRepository : Repository<StudenBookIssueAndReturnDetail>, IStudentAndBookIssueReturnDetailsRepository
{
    public StudentAndBookIssueReturnDetailsRepository(IApplicationDbContext context) : base((DbContext)context)
    {
    }

}
