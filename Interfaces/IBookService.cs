
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public interface IBookService
    {
        (bool Success, string Message) BorrowBook(string title);
        (bool Success, string Message) ReturnBook(string title);
        (bool Success, string Message) DonateBook(string title, string author);
        public IEnumerable<Book> GetAllBooks();
        public IEnumerable<Book> GetAvailableBooks();
        public IEnumerable<Book> GetUnavailableBooks();

    }
}
