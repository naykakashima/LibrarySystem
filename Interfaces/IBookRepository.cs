using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public interface IBookRepository
    {
        void Add(BookBase book);
        BookBase? FindByTitle(string title);
        IEnumerable<BookBase> GetAll();

        
    }
}
