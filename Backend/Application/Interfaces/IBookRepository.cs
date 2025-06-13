using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public interface IBookRepository
    {
        Task AddAsync(BookBase book);
        Task<BookBase?> FindByTitleAsync(string title);
        Task<IEnumerable<BookBase>> GetAllAsync();
        Task<BookBase?> GetByIdAsync(Guid id);
        Task<bool> UpdateAsync(Guid id, string title, string author, bool available);
        Task<bool> DeleteAsync(Guid id);

    }
}
