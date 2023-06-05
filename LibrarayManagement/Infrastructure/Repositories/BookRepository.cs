using Domain.Entities;
using Domain.Repositories;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BookRepository : Repository<Book>, IBookRepository
{
    public BookRepository(IApplicationDbContext context) : base((DbContext)context)
    {
    }
}
