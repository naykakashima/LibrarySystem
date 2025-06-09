
using LibrarySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public class Menu
    {
        private readonly IBookService _bookService;

        public Menu(IBookService bookService)
        {
            _bookService = bookService;
        }

     

        public void Show()
        {
            while (true)
            {
                Console.WriteLine("+----------WELCOME TO THE LIBRARY----------+");
                Console.WriteLine("1. Borrow a book");
                Console.WriteLine("2. Return a book");
                Console.WriteLine("3. Donate a book");
                Console.WriteLine("4. Display Available books");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Type in the number of what you want to do: ");
                Console.WriteLine("+------------------------------------------+");

                int res;

                while (!int.TryParse(Console.ReadLine(), out res) || res < 1 || res > 5)
                {
                    Console.WriteLine("Invalid input! Enter 1-5:");
                }

                (bool Success, string Message) result;

                switch (res)
                {
                    case 1:
                        var borrowTitle = PromptUserInput("Enter Book Title: ");
                        result = _bookService.BorrowBook(borrowTitle);
                        Console.WriteLine(result.Message);
                        break;
                    case 2:
                        var returnTitle = PromptUserInput("Enter Book Title: ");
                        result = _bookService.ReturnBook(returnTitle);
                        Console.WriteLine(result.Message);
                        break;
                    case 3:
                        var donateTitle = PromptUserInput("Enter Book Title: ");
                        var donateAuthor = PromptUserInput("Enter Book Author: ");
                        result = _bookService.DonateBook(donateTitle, donateAuthor);
                        Console.WriteLine(result.Message);
                        break;
                    case 4:
                        DisplayAvailableBooks();
                        break;
                    case 5:
                        Console.WriteLine("Goodbye!");
                        Thread.Sleep(1000);
                        return;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        private void DisplayAvailableBooks()
        {
            var availableBooks = _bookService.GetAvailableBooks();

            if (!availableBooks.Any())
            {
                Console.WriteLine("No books available right now.");
                return;
            }

            Console.WriteLine("\n--- AVAILABLE BOOKS ---");
            foreach (var book in availableBooks)
            {
                if (book is AudioBook audioBook)
                {
                    Console.WriteLine($"- {audioBook.Title} (AudioBook) - Duration: {audioBook.RuntimeMinutes} mins");
                } else if (book is Book)
                {
                    Console.WriteLine($"- {book.Title} by {book.Author}");
                }
            }
            Console.WriteLine("-----------------------\n");

        }

        private string PromptUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

    }
}




