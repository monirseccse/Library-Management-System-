using AutoMapper;
using BookBo = Infrastructure.BusinessObjects.Book;
using BookEo = Domain.Entities.Book;
using Infrastructure.UnitOfWorks;
using Infrastructure.BusinessObjects;
using Domain.Enum;
using Domain.Entities;

namespace Infrastructure.Services;

public class BookService : IBookService
{
    private readonly IApplicationUnitOfWork _applicationUnitofwork;
    private readonly IMapper _mapper;

    public BookService(
        IApplicationUnitOfWork applicationUnitOfWork,
        IMapper mapper)
    {
        _applicationUnitofwork = applicationUnitOfWork;
        _mapper = mapper;
    }

    public async Task AddBook(BookBo book)
    {
        var bookscount = await _applicationUnitofwork.Book.GetCount(x => x.Title == book.Title);

        if (bookscount > 0)
        {
            throw new InvalidOperationException("Book already exists");
        }

        var bookEo = _mapper.Map<BookEo>(book);

        await _applicationUnitofwork.Book.AddAsync(bookEo);
        await _applicationUnitofwork.SaveAsync();
    }

    public async Task<IReadOnlyList<BookBo>> GetBooks()
    {
        var booklist = await _applicationUnitofwork.Book.GetAllAsync();
        var booklitBo = _mapper.Map<IReadOnlyList<BookEo>, IReadOnlyList<BookBo>>
                (booklist);

        return booklitBo;
    }

    public async Task UpdateBook(BookEdit book)
    {
        var entity = await _applicationUnitofwork.Book.GetByIdAsync(book.Id);

        if (entity is not null)
        {
            entity = _mapper.Map(book, entity);
            await _applicationUnitofwork.SaveAsync();
        }
        else
        {
            throw new InvalidOperationException("Book does not exist");
        }
    }

    public async Task<IList<BookBo>> GetBooks(string status)
    {
        Enum.TryParse<IssueStatus>(status, out IssueStatus result);

        var issuelist = await _applicationUnitofwork.
             StudentAndBookIssueReturnDetails.GetAsync(x => x.IssueStatus.Equals(result), "Book");

        var bookentity = issuelist.Select(x => x.Book).ToList();
        var booklitBo = _mapper.Map<IList<BookEo>, IList<BookBo>>
            (bookentity);

        return booklitBo;
    }

    public async Task<BookBo> GetBook(int id)
    {
        var entity = await _applicationUnitofwork.Book.GetByIdAsync(id);

        if (entity is not null)
        {
            var book = _mapper.Map<BookEo,BookBo>(entity);
            return book;
        }
        else
        {
            throw new InvalidOperationException("Book Not found");
        }
    }
}
