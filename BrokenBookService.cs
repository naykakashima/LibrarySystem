

using LibrarySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public class BrokenBookService : IBookService
    {
        public (bool Success, string Message) BorrowBook(string title)
            => (false, "❌ Library is closed for renovation!");

        public (bool Success, string Message) ReturnBook(string title)
            => (false, "❌ Library is closed for renovation!");

        public (bool Success, string Message) DonateBook(string title, string author)
            => (false, "❌ Library is closed for renovation!");

        public IEnumerable<Book> GetAllBooks()
            => new List<Book>();  // Return empty list

        public IEnumerable<Book> GetAvailableBooks()
            => new List<Book>();  // Return empty list

        public IEnumerable<Book> GetUnavailableBooks()
            => new List<Book>();  // Return empty list
    }
}
