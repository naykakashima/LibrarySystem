using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public class MockBookService : IBookService
    {
        // Mock data - in-memory list of books
        private readonly List<Book> _mockBooks = new()
        {
            new Book("The Hobbit", "J.R.R. Tolkien", true),
            new Book("Dune", "Frank Herbert", false), // Borrowed
            new Book("The Martian", "Andy Weir", true),
            new Book("Educated", "Tara Westover", false), // Borrowed
            new Book("Project Hail Mary", "Andy Weir", true)

        };

        public (bool Success, string Message) BorrowBook(string title)
        {
            var book = _mockBooks.FirstOrDefault(b =>
                b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (book == null)
                return (false, "❌ [MOCK] Book not found!");
            if (!book.Available)
                return (false, "❌ [MOCK] Book already borrowed!");

            book.Available = false;
            return (true, "✅ [MOCK] Book borrowed successfully!");
        }

        public (bool Success, string Message) ReturnBook(string title)
        {
            var book = _mockBooks.FirstOrDefault(b =>
                b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (book == null)
                return (false, "❌ [MOCK] Book not found!");
            if (book.Available)
                return (false, "❌ [MOCK] Book wasn't borrowed!");

            book.Available = true;
            return (true, "✅ [MOCK] Book returned successfully!");
        }

        public (bool Success, string Message) DonateBook(string title, string author)
        {
            if (_mockBooks.Any(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase)))
                return (false, "❌ [MOCK] Book already exists!");

            _mockBooks.Add(new Book(title, author, true));
            return (true, "✅ [MOCK] Book donated successfully!");
        }

        public IEnumerable<BookBase> GetAllBooks() => _mockBooks;
        public IEnumerable<BookBase> GetAvailableBooks() => _mockBooks.Where(b => b.Available);
        public IEnumerable<BookBase> GetUnavailableBooks() => _mockBooks.Where(b => !b.Available);
    }
}