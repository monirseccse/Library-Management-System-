using Domain.Repositories;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UnitOfWorks
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public ApplicationUnitOfWork(
            ApplicationDbContext dbContext,
            IBookRepository bookRepository,
            IStudentRepository studentRepository) : base((DbContext)dbContext)
        {
            Book = bookRepository;
            Student = studentRepository;
        }

        public IBookRepository Book { get; private set; }
        public IStudentRepository Student { get; private set; }
    }
}
