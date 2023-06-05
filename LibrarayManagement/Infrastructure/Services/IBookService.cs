using Domain.Entities;
using Infrastructure.BusinessObjects;
using BookBo = Infrastructure.BusinessObjects.Book;
using BookEo = Domain.Entities.Book;
using StudenBookIssueAndReturnDetailBo = Infrastructure.BusinessObjects.StudenBookIssueAndReturnDetail;

namespace Infrastructure.Services;

public interface IBookService
{
    public Task AddBook(BookBo book);
    public Task UpdateBook(BookEdit book);
    public Task<IReadOnlyList<BookBo>>GetBooks();
    public Task<IList<BookBo>> GetBooks(string status);
    public Task<BookBo> GetBook(int id);
    public Task AddIssue
        (int studentId, int bookId);
}
