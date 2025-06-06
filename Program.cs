using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Threading;


namespace LibrarySystem
{
    class Library
    {
        static void Main(string[] args)
        {
            var books = new List<Book>
            {
                new Book("The Hobbit", "J.R.R. Tolkien", true),
                new Book("Dune", "Frank Herbert", false),
                new Book("The Martian", "Andy Weir", true),
                new Book("Educated", "Tara Westover", true),
                new Book("Project Hail Mary", "Andy Weir", false)
            };

            IBookService bookService = new BookService(books);
            var menu = new Menu(bookService);

            menu.Show();

        }


    }
}






