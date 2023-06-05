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

        public BookController(IBookService bookService)
        {
            _bookService= bookService;
        }

        [HttpPost()]
        public async Task<IActionResult> Post(Book model)
        {
            try
            {
                await  _bookService.AddBook(model);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Put(BookEdit model)
        {
            try
            {
                await _bookService.UpdateBook(model);

                return Ok();

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet()]
        public async Task<ActionResult<IReadOnlyList<Book>>>GetBooks()
        {
            try
            {
                var booklist = _bookService.GetBooks();
                return Ok(booklist);
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        [HttpGet("status")]
        public async Task<ActionResult<IReadOnlyList<Book>>> GetBooks(string status)
        {
            try
            {
                var booklist = _bookService.GetBooks();
                return Ok(booklist);
            }
            catch (Exception ex)
            {

                return BadRequest();
            }

        }
    }
}
