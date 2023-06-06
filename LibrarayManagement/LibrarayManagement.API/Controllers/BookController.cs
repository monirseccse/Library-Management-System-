using AutoMapper;
using Infrastructure.BusinessObjects;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibrarayManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IStudentService _studentService;

        public BookController(
            IBookService bookService,
            IStudentService studentService)
        {
            _bookService= bookService;
            _studentService= studentService;
        }

        [HttpPost()]
        public async Task<IActionResult> Post(Book model)
        {
            try
            {
                await  _bookService.AddBook(model);
                return Ok("saved successfully");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Put(BookEdit model)
        {
            try
            {
                await _bookService.UpdateBook(model);

                return Ok("updated successfully");

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet()]
        public async Task<ActionResult<IReadOnlyList<Book>>>GetBooks()
        {
            try
            {
                var booklist = await _bookService.GetBooks();
                return Ok(booklist);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetBookbystatus")]
        public async Task<ActionResult<IReadOnlyList<Book>>> GetBooks(string status)
        {
            try
            {
                var booklist = await _bookService.GetBooks(status);

                return Ok(booklist);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


        [HttpPost("issueBook")]
        public async Task<ActionResult> IssueBook(int studentId, int bookId)
        {
            try
            {
                await _bookService.AddIssue(studentId, bookId);

                return Ok("issued successfully");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("returnBook")]
        public async Task<ActionResult> ReturnBook(int studentId, int bookId)
        {
            try
            {
                await _bookService.ReturnBook(studentId, bookId);

                return Ok("returned sucessfully");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
