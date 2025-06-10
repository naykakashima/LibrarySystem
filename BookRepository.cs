using LibrarySystem;
using LibrarySystem.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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


