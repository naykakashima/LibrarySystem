using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public class BookService : IBookService
    {
        private readonly List<Book> _books;

        public BookService(List<Book> books)
        {
            _books = books ?? throw new ArgumentNullException(nameof(books));
        }

        public (bool Success, string Message) BorrowBook(string title)
        {
            var book = _books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (book == null)
                return (false, "Book Not Found");
            if (!book.Available)
                return (false, "Book Is Not Available");

            book.Available = false;
            return (true, "Book Successfully Borrowed");
        }

        public (bool Success, string Message) ReturnBook(string title)
        {
            var book = _books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (book == null)
                return (false, "Book Doesn't Exist");
            if (book.Available)
                return (false, "Book isn't lent out in our system!");

            book.Available = true;
            return (true, "Book Successfully Returned");
        }

        public (bool Success, string Message) DonateBook(string title, string author)
        {
            if (_books.Any(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase)))
                return (false, "Book Is Already In The System!");

            _books.Add(new Book(title, author, true));
            return (true, "Book Succesfully Donated");
        }

        public IEnumerable<Book> GetAllBooks() => _books;
        public IEnumerable<Book> GetAvailableBooks() => _books.Where(b => b.Available);
        public IEnumerable<Book> GetUnavailableBooks() => _books.Where(b => !b.Available);

    }


}
