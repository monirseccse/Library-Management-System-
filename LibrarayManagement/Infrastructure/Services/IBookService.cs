using Infrastructure.BusinessObjects;

namespace Infrastructure.Services;

public interface IBookService
{
    public Task AddBook(Book book);
    public Task UpdateBook(BookEdit book);
    public IList<Book>GetBooks();
}
