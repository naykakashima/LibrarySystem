
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public interface IBookService
    {
        Task<(bool Success, string Message)> BorrowBookAsync(string title);
        Task<(bool Success, string Message)> ReturnBookAsync(string title);
        Task<(bool Success, string Message)> DonateBookAsync(string title, string author);

        Task<IEnumerable<BookBase>> GetAllBooksAsync();
        Task<IEnumerable<BookBase>> GetAvailableBooksAsync();
        Task<IEnumerable<BookBase>> GetUnavailableBooksAsync();

    }
}
