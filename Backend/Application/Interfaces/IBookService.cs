namespace LibrarySystem
{
    public interface IBookService
    {
        Task<(bool Success, string Message)> BorrowBookAsync(string title);
        Task<(bool Success, string Message)> ReturnBookAsync(string title);
        Task<(bool Success, string Message)> DonateBookAsync(string title, string author);
        Task<(bool Success, string Message)> DonateAudioBookAsync(string title, string author, int runtimeMinutes);
        Task<(bool Success, string Message)> UpdateBookAsync(Guid id, string title, string author, bool available);
        Task<(bool Success, string Message)> DeleteBookAsync(Guid id);
        Task<BookBase?> GetBookByIdAsync(Guid id);
        Task<IEnumerable<BookBase>> GetAllBooksAsync();
        Task<IEnumerable<BookBase>> GetAvailableBooksAsync();
        Task<IEnumerable<BookBase>> GetUnavailableBooksAsync();

    }
}
