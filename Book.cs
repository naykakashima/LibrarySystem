using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public class Book
    {
        public string Title;
        public string Author;
        public Boolean Available;

        public Book(string title, string author, bool available)
        {
            Title = title;
            Author = author;
            Available = available;
        }


    }
}
