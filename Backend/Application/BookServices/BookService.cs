using Microsoft.EntityFrameworkCore;
using LibrarySystem.Application.DTO;
using Library.Application.Interfaces;

namespace LibrarySystem
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;

        public BookService(IBookRepository repo)
        {
            _repo = repo;
        }

        public async Task<(bool Success, string Message)> BorrowBookAsync(Guid id, Guid userId)
        {
            var book = await _repo.GetByIdAsync(id);

            if (book == null || !book.CanBeBorrowed())
                return (false, "Book cannot be borrowed!");

            book.Available = false;
            book.BorrowedByUserId = userId;
            await _repo.SaveChangesAsync();
            return (true, "Book Successfully Borrowed");
        }

        public async Task<(bool Success, string Message)> ReturnBookAsync(Guid id, Guid userId)
        {
            var book = await _repo.GetByIdAsync(id);

            if (book == null)
                return (false, "Book Doesn't Exist");
            if (book.Available)
                return (false, "Book isn't lent out in our system!");

            book.Available = true;
            book.BorrowedByUserId = null;
            book.BorrowedByUser = null;
            await _repo.SaveChangesAsync();
            return (true, "Book Successfully Returned");
        }

        public async Task<(bool Success, string Message)> DonateBookAsync(string title, string author)
        {
            var allBooks = await _repo.GetAllAsync();
            if (allBooks.Any(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase)))
                return (false, "Book Is Already In The System!");

            await _repo.AddAsync(new Book(title, author, true));
            return (true, "Book Successfully Donated");
        }

        public async Task<(bool Success, string Message)> DonateAudioBookAsync(string title, string author, int runtimeMinutes)
        {
            var allBooks = await _repo.GetAllAsync();
            if (allBooks.Any(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase)))
                return (false, "Book Is Already In The System!");

            await _repo.AddAsync(new AudioBook(title, author, runtimeMinutes, true));
            return (true, "Book Successfully Donated");
        }

        public async Task<(bool Success, string Message)> UpdateBookAsync(Guid id, string title, string author, bool available)
        {
            var updated = await _repo.UpdateAsync(id, title, author, available);
            return updated
                ? (true, "Book successfully updated.")
                : (false, "Book not found.");
        }

        public async Task<BookBase?> GetBookByIdAsync(Guid id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<List<BookDisplayDto>> GetAllBooksAsync()
        {
            var physicalBooks = await _repo.GetAll()
                .OfType<Book>()
                .Select(b => new BookDisplayDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Available = b.Available,
                    Type = "Book"
                })
                .ToListAsync();

            var audioBooks = await _repo.GetAll()
                .OfType<AudioBook>()
                .Select(ab => new BookDisplayDto
                {
                    Id = ab.Id,
                    Title = ab.Title,
                    Author = ab.Author,
                    Available = ab.Available,
                    Type = "AudioBook",
                    RuntimeMinutes = ab.runtimeMinutes
                })
                .ToListAsync();

            return physicalBooks.Concat(audioBooks).ToList();
        }

        public async Task<IEnumerable<BookBase>> GetAvailableBooksAsync()
        {
            return (await _repo.GetAllAsync()).OfType<BookBase>().Where(b => b.Available);
        }

        public async Task<IEnumerable<BookBase>> GetUnavailableBooksAsync()
        {
            return (await _repo.GetAllAsync()).OfType<BookBase>().Where(b => !b.Available);
        }

        public async Task<(bool Success, string Message)> DeleteBookAsync(Guid id)
        {
            var deleted = await _repo.DeleteAsync(id);
            return deleted
                ? (true, "Book deleted successfully.")
                : (false, "Book not found.");
        }
    }
}
