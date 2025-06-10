using LibrarySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public class BookRepository : IBookRepository
    {

        private readonly List<BookBase> _repo;

        public BookRepository()
        {
            _repo = new List<BookBase>
            {
                new Book("The Hobbit", "J.R.R. Tolkien", true),
                new Book("Dune", "Frank Herbert", false),
                new Book("The Martian", "Andy Weir", true),
                new Book("Educated", "Tara Westover", true),
                new Book("Project Hail Mary", "Andy Weir", false),
                new Book("Atomic Habits", "James Clear", true),
                new AudioBook("Dune", "Frank Herbert", 450)
            };
        }

        
        public void Add(BookBase book) => _repo.Add(book);
        public BookBase FindByTitle(string title)
        {
            return _repo.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<BookBase> GetAll() => _repo;
    }
}


