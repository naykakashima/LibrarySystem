using Library.Application.DTO;
using LibrarySystem;
using LibrarySystem.Application.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        [Authorize]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [Authorize]
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

        [Authorize]
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

        [Authorize]
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


        [Authorize]
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

        [Authorize]
        [HttpPut("BorrowBook/{id}")]
        public async Task<IActionResult> BorrowBook(Guid id)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null || !Guid.TryParse(userIdClaim, out var userId))
            {
                return Unauthorized("Invalid token");
            }
            var result = await _bookService.BorrowBookAsync(id, userId);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            else
            {
                return Ok(result.Message);
            }
        }

        [Authorize]
        [HttpPut("ReturnBook/{id}")]
        public async Task<IActionResult> ReturnBook(Guid id)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Console.Write(userIdClaim);
            if (userIdClaim == null || !Guid.TryParse(userIdClaim, out var userId))
            {
                return Unauthorized("Invalid token");
            }

            var result = await _bookService.ReturnBookAsync(id, userId);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            else
            {
                return Ok(result.Message);
            }
        }



    }
}
