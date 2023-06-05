using Domain.Repositories;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UnitOfWorks
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public ApplicationUnitOfWork(
            IApplicationDbContext dbContext,
            IBookRepository bookRepository,
            IStudentRepository studentRepository,
            IStudentAndBookIssueReturnDetailsRepository studentAndBookIssueReturnDetailsRepository)
            : base((DbContext)dbContext)
        {
            Book = bookRepository;
            Student = studentRepository;
            StudentAndBookIssueReturnDetails = studentAndBookIssueReturnDetailsRepository;
        }

        public IBookRepository Book { get; private set; }
        public IStudentRepository Student { get; private set; }
        public IStudentAndBookIssueReturnDetailsRepository StudentAndBookIssueReturnDetails{ get; private set; }
    }
}
