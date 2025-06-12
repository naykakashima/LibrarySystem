namespace LibrarySystem
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;

        public BookService(IBookRepository repo)
        {
            _repo = repo;
        }

        public async Task<(bool Success, string Message)> BorrowBookAsync(string title)
        {
            var book = await _repo.FindByTitleAsync(title);

            if (book == null || !book.CanBeBorrowed())
                return (false, "Book cannot be borrowed!");

            book.Available = false;
            return (true, "Book Successfully Borrowed");
        }

        public async Task<(bool Success, string Message)> ReturnBookAsync(string title)
        {
            var book = await _repo.FindByTitleAsync(title);

            if (book == null)
                return (false, "Book Doesn't Exist");
            if (book.Available)
                return (false, "Book isn't lent out in our system!");

            book.Available = true;
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

        public async Task<BookBase?> GetBookByIdAsync(Guid id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<IEnumerable<BookBase>> GetAllBooksAsync()
        {
            return (await _repo.GetAllAsync()).OfType<BookBase>();
        }

        public async Task<IEnumerable<BookBase>> GetAvailableBooksAsync()
        {
            return (await _repo.GetAllAsync()).OfType<BookBase>().Where(b => b.Available);
        }

        public async Task<IEnumerable<BookBase>> GetUnavailableBooksAsync()
        {
            return (await _repo.GetAllAsync()).OfType<BookBase>().Where(b => !b.Available);
        }
    }
}
