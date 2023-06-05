using AutoMapper;
using BookBo =Infrastructure.BusinessObjects.Book;
using BookEo = Domain.Entities.Book;
using Infrastructure.UnitOfWorks;
using Infrastructure.BusinessObjects;

namespace Infrastructure.Services;

public class BookService : IBookService
{
    private readonly IApplicationUnitOfWork _applicationUnitofwork;
    private readonly IMapper _mapper;

    public BookService(
        IApplicationUnitOfWork applicationUnitOfWork,
        IMapper mapper)
    {
        _applicationUnitofwork= applicationUnitOfWork;
        _mapper= mapper;
    }

    public async Task AddBook(BookBo book)
    {
        var bookscount = await _applicationUnitofwork.Book.GetCount(x => x.Title == book.Title);

        if(bookscount>0)
        {
            throw new InvalidOperationException("Book already exists");
        }

         var bookEo = _mapper.Map<BookEo>(book);

         await _applicationUnitofwork.Book.AddAsync(bookEo);
         await _applicationUnitofwork.SaveAsync();
    }

    public IList<BookBo> GetBooks(BookBo book)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateBook(BookEdit book)
    {
        var entity = await _applicationUnitofwork.Book.GetByIdAsync(book.Id) ;

        if(entity is not null)
        {
            entity = _mapper.Map(book,entity);
            await _applicationUnitofwork.SaveAsync();
        }
        else
        {
            throw new  InvalidOperationException("Book does not exist");
        }
    }
}
