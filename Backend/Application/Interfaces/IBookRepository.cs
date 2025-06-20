using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem;

namespace Library.Application.Interfaces

{
    public interface IBookRepository
    {
        Task AddAsync(BookBase book);
        Task<BookBase?> FindByTitleAsync(string title);
        Task<IEnumerable<BookBase>> GetAllAsync();
        IQueryable<BookBase> GetAll();
        Task<BookBase?> GetByIdAsync(Guid id);
        Task<bool> UpdateAsync(Guid id, string title, string author, bool available);
        Task<bool> DeleteAsync(Guid id);
        Task SaveChangesAsync();

    }
}
