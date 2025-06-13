using LibrarySystem;
using Microsoft.AspNetCore.Mvc;


namespace Library.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook([FromBody] BookDto newBook)
        {
            if (newBook == null)
                return BadRequest("Book data is required.");

            var result = await _bookService.DonateBookAsync(newBook.Title, newBook.Author);

            if (!result.Success)
                return Conflict(result.Message);

            return Ok(newBook);
        }

        [HttpPost("AddAudioBook")]
        public async Task<IActionResult> AddAudioBook([FromBody] AudioBookDto newAudioBook)
        {
            if (newAudioBook == null)
                return BadRequest("Book data is required.");

            var result = await _bookService.DonateAudioBookAsync(newAudioBook.Title, newAudioBook.Author, newAudioBook.runtimeMinutes);

            if (!result.Success)
                return Conflict(result.Message);

            return Ok(newAudioBook);
        }

        [HttpPut("UpdateBook/{id}")]
        public async Task<IActionResult> UpdateBook(Guid id, [FromBody] UpdateBookDto dto)
        {
            var result = await _bookService.UpdateBookAsync(id, dto.Title, dto.Author, dto.Available);

            if (!result.Success)
            {

                return NotFound(result.Message);

            } else
            {

                return Ok(result.Message);

            }
        }

        [HttpDelete("DeleteBook/{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            var result = await _bookService.DeleteBookAsync(id);

            if (!result.Success)
            {

                return NotFound(result.Message);

            }
            else
            {

                return Ok(result.Message);

            }
        }



    }
}
