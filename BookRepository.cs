using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public class BookRepository : IBookRepository
    {

        private readonly List<BookBase> _books;

        public BookRepository(List<BookBase> books)
        {
            _books = new List<BookBase>(books); 
        }

        
        public void Add(BookBase book) => _books.Add(book);
        public BookBase FindByTitle(string title)
        {
            return _books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<BookBase> GetAll() => _books;
    }
}
