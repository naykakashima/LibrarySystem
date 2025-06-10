using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public class MockBookService : IBookService
    {
        private readonly IBookRepository _repo;

        public MockBookService(IBookRepository repo)
        {
            _repo = repo;
        }

        public (bool Success, string Message) BorrowBook(string title)
        {
            var book = _repo.FindByTitle(title);

            if (book == null)
                return (false, "❌ [MOCK] Book not found!");
            if (!book.Available)
                return (false, "❌ [MOCK] Book already borrowed!");

            book.Available = false;
            return (true, "✅ [MOCK] Book borrowed successfully!");
        }

        public (bool Success, string Message) ReturnBook(string title)
        {
            var book = _repo.FindByTitle(title);

            if (book == null)
                return (false, "❌ [MOCK] Book not found!");
            if (book.Available)
                return (false, "❌ [MOCK] Book wasn't borrowed!");

            book.Available = true;
            return (true, "✅ [MOCK] Book returned successfully!");
        }

        public (bool Success, string Message) DonateBook(string title, string author)
        {
            if (_repo.GetAll().Any(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase)))
                return (false, "❌ [MOCK] Book already exists!");

            _repo.Add(new Book(title, author, true));
            return (true, "✅ [MOCK] Book donated successfully!");
        }

        public IEnumerable<BookBase> GetAllBooks() => _repo.GetAll().OfType<BookBase>();
        public IEnumerable<BookBase> GetAvailableBooks() => _repo.GetAll().OfType<BookBase>().Where(b => b.Available);
        public IEnumerable<BookBase> GetUnavailableBooks() => _repo.GetAll().OfType<BookBase>().Where(b => b.Available);
    }
}