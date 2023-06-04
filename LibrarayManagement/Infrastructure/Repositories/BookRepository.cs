using Domain.Entities;
using Domain.Repositories;
using Infrastructure.DbContexts;
using Infrastructure.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BookRepository : Repository<Book>, IBookRepository
{
    public BookRepository(IApplicationDbContext context) : base((DbContext)context)
    {
    }
}
