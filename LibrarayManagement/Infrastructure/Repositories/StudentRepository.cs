using Domain.Entities;
using Domain.Repositories;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class StudentRepository : Repository<Student>, IStudentRepository
{
    public StudentRepository(IApplicationDbContext context) : base((DbContext)context)
    {
    }
}
