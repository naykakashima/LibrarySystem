using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public abstract class BookBase
    {

        public Guid Id { get; set; } = Guid.NewGuid();

        public string Title { get; set; }
        public string Author { get; set; }
        public bool Available { get; set; }

        public BookBase(string title, string author, bool available)
        {
            Title = title;
            Author = author;
            Available = available;
        }

        //VIRTUAL METHOD
        public virtual bool CanBeBorrowed() => Available;
    }
}
