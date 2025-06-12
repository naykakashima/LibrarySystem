namespace LibrarySystem
{
    public interface IBookService
    {
        Task<(bool Success, string Message)> BorrowBookAsync(string title);
        Task<(bool Success, string Message)> ReturnBookAsync(string title);
        Task<(bool Success, string Message)> DonateBookAsync(string title, string author);
        Task<(bool Success, string Message)> DonateAudioBookAsync(string title, string author, int runtimeMinutes);
        Task<BookBase?> GetBookByIdAsync(Guid id);
        Task<IEnumerable<BookBase>> GetAllBooksAsync();
        Task<IEnumerable<BookBase>> GetAvailableBooksAsync();
        Task<IEnumerable<BookBase>> GetUnavailableBooksAsync();

    }
}
