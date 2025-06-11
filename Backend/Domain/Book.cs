using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public class Book : BookBase
    {
        public Book(string title, string author, bool available) : base(title, author, available) { }
    }

}
