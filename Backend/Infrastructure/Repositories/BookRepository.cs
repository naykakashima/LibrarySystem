#nullable enable
using LibrarySystem.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return await _context.Set<BookBase>() .FirstOrDefaultAsync(b => b.Title.ToLower() == title.ToLower());
        }

        public async Task<BookBase?> GetByIdAsync(Guid id)
        {
            return await _context.Set<BookBase>().FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<BookBase>> GetAllAsync()
        {
            return await _context.Set<BookBase>().ToListAsync();
        }

        public IQueryable<BookBase> GetAll()
        {
            return _context.Set<BookBase>().AsNoTracking();
        }

        public async Task<bool> UpdateAsync(Guid id, string title, string author, bool available)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return false;

            book.Title = title;
            book.Author = author;
            book.Available = available;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
            if (book == null) 
                return false;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}


