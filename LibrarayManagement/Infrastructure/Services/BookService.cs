using AutoMapper;
using BookBo = Infrastructure.BusinessObjects.Book;
using BookEo = Domain.Entities.Book;
using Infrastructure.UnitOfWorks;
using Infrastructure.BusinessObjects;
using Domain.Enum;
using Domain.Entities;
using StudenBookIssueAndReturnDetailBo = Infrastructure.BusinessObjects.StudenBookIssueAndReturnDetail;
using StudenBookIssueAndReturnDetailEo = Domain.Entities.StudenBookIssueAndReturnDetail;

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

        var booklist = await _applicationUnitofwork.
             Book.GetAsync(x => x.Status.Equals(result));

        if(booklist is not null)
        {
            var booklitBo = _mapper.Map<IList<BookEo>, IList<BookBo>>
                (booklist);

            return booklitBo;
        }
        else
        {
            throw new InvalidOperationException("Book Not found");
        }

    }

    public async Task<BookBo> GetBook(int id)
    {
        var entity = await _applicationUnitofwork.Book.GetByIdAsync(id);

        if (entity is not null)
        {
            var book = _mapper.Map<BookEo, BookBo>(entity);
            return book;
        }
        else
        {
            throw new InvalidOperationException("Book Not found");
        }
    }


    public async Task ReturnBook(int studentId, int bookId)
    {
        var bookEo = await _applicationUnitofwork.Book.GetByIdAsync(bookId);
        var studentEo = await _applicationUnitofwork.Student.GetByIdAsync(studentId);

        if (studentEo is null || bookEo is null)
        {
            throw new InvalidOperationException("Book Or Student Id Invalid");
        }

        var studentissueDetail = await _applicationUnitofwork.StudentAndBookIssueReturnDetails
            .GetAsync(x => x.StudentId == studentId && x.BookId == bookId
            && x.IssueStatus == IssueStatus.Issue);

        if(studentissueDetail is null)
        {
            throw new InvalidOperationException("Nothing found to return");
        }

        var detail = studentissueDetail.LastOrDefault();
        detail.IssueStatus = IssueStatus.Free;
        detail.ReturnDate = DateTime.Now;

       _applicationUnitofwork.StudentAndBookIssueReturnDetails.EditAsync(detail);
       await _applicationUnitofwork.SaveAsync();

        bookEo.Status = IssueStatus.Free;

        await _applicationUnitofwork.SaveAsync();

    }

    public async Task AddIssue(int studentId, int bookId)
    {
        var bookEo = await _applicationUnitofwork.Book.GetByIdAsync(bookId);
        var studentEo = await _applicationUnitofwork.Student.GetByIdAsync(studentId);

        if (studentEo is null || bookEo is null)
        {
            throw new InvalidOperationException("Book Or Student Id Invalid");
        }

        var studentissueDetail = await _applicationUnitofwork.StudentAndBookIssueReturnDetails
                .GetAsync(x => x.StudentId == studentId);

            var bookcount = studentissueDetail.Where(x => x.StudentId == studentId &&
                 x.IssueDate.GetValueOrDefault().Date == DateTime.Now.Date).Count();

            var totalStudentOccupiedbook = studentissueDetail.Where
                (x => x.StudentId == studentId &&
                x.IssueStatus == IssueStatus.Issue).Count();

        if (bookEo.Status == IssueStatus.Free && bookcount < 2 && totalStudentOccupiedbook < 4)
        {
            StudenBookIssueAndReturnDetailEo entity = new StudenBookIssueAndReturnDetailEo();
            entity.BookId = bookId;
            entity.StudentId = studentId;
            entity.IssueDate = DateTime.Now;
            entity.IssueStatus = IssueStatus.Issue;

            await _applicationUnitofwork.StudentAndBookIssueReturnDetails.AddAsync(entity);
            await _applicationUnitofwork.SaveAsync();

            bookEo.Status = IssueStatus.Issue;

            await _applicationUnitofwork.SaveAsync();
        }
        else
        {
            throw new InvalidOperationException("Validation Failed");
        }

    }
}
