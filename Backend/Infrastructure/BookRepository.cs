using LibrarySystem.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(BookBase book)
        {
            _context.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task<BookBase?> FindByTitleAsync(string title)
        {
            return await _context.Set<BookBase>()
                .FirstOrDefaultAsync(b => b.Title.ToLower() == title.ToLower());
        }

        public async Task<IEnumerable<BookBase>> GetAllAsync()
        {
            return await _context.Set<BookBase>().ToListAsync();
        }
    }

}


