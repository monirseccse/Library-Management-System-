using Domain.Repositories;

namespace Infrastructure.UnitOfWorks;

public interface IApplicationUnitOfWork : IUnitOfWork
{
    public IBookRepository Book { get; }
    public IStudentRepository Student { get; }
    public IStudentAndBookIssueReturnDetailsRepository StudentAndBookIssueReturnDetails { get;}
}
