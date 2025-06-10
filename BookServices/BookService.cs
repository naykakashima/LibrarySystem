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

        private readonly IBookRepository _repo;

        public BookService(IBookRepository repo)
        {
            _repo = repo;
        }

        public (bool Success, string Message) BorrowBook(string title)
        {
            var book = _repo.FindByTitle(title);

            if (book == null || !book.CanBeBorrowed())
                return (false, "Book cannot be borrowed!");

            book.Available = false;
            return (true, "Book Successfully Borrowed");
        }

        public (bool Success, string Message) ReturnBook(string title)
        {
            var book = _repo.FindByTitle(title);

            if (book == null)
                return (false, "Book Doesn't Exist");
            if (book.Available)
                return (false, "Book isn't lent out in our system!");

            book.Available = true;
            return (true, "Book Successfully Returned");
        }

        public (bool Success, string Message) DonateBook(string title, string author)
        {
            if (_repo.GetAll().Any(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase)))
                return (false, "Book Is Already In The System!");

            _repo.Add(new Book(title, author, true));
            return (true, "Book Succesfully Donated");
        }

        public IEnumerable<BookBase> GetAllBooks() => _repo.GetAll().OfType<BookBase>();
        public IEnumerable<BookBase> GetAvailableBooks() => _repo.GetAll().OfType<BookBase>().Where(b => b.Available);
        public IEnumerable<BookBase> GetUnavailableBooks() => _repo.GetAll().OfType<BookBase>().Where(b => !b.Available);

    }


}
