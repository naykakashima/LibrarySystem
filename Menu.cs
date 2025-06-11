
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

     

        public async Task ShowAsync()
        {
            while (true)
            {
                Console.WriteLine("+----------WELCOME TO THE LIBRARY----------+");
                Console.WriteLine("1. Borrow a book");
                Console.WriteLine("2. Return a book");
                Console.WriteLine("3. Donate a book");
                Console.WriteLine("4. Donate an audio book");
                Console.WriteLine("5. Display Available books");
                Console.WriteLine("6. Display All Books");
                Console.WriteLine("7. Exit");
                Console.WriteLine("Type in the number of what you want to do: ");
                Console.WriteLine("+------------------------------------------+");

                int res;

                while (!int.TryParse(Console.ReadLine(), out res) || res < 1 || res > 7)
                {
                    Console.WriteLine("Invalid input! Enter 1-6:");
                }

                (bool Success, string Message) result;

                switch (res)
                {
                    case 1:
                        var borrowTitle = PromptUserInput("Enter Book Title: ");
                        result = await _bookService.BorrowBookAsync(borrowTitle);
                        Console.WriteLine(result.Message);
                        break;
                    case 2:
                        var returnTitle = PromptUserInput("Enter Book Title: ");
                        result = await _bookService.ReturnBookAsync(returnTitle);
                        Console.WriteLine(result.Message);
                        break;
                    case 3:
                        var donateTitle = PromptUserInput("Enter Book Title: ");
                        var donateAuthor = PromptUserInput("Enter Book Author: ");
                        result = await  _bookService.DonateBookAsync(donateTitle, donateAuthor);
                        Console.WriteLine(result.Message);
                        break;
                    case 4:
                        var donateAudioBookTitle = PromptUserInput("Enter Audio Book Title: ");
                        var donateAudioBookAuthor = PromptUserInput("Enter Audio Book Author: ");
                        int donateAudioBookRuntime = PromptUserInputInt("Enter Audio Book Runtime: ");
                        result = await _bookService.DonateAudioBookAsync(donateAudioBookTitle, donateAudioBookAuthor, donateAudioBookRuntime);
                        Console.WriteLine(result.Message);
                        break;
                    case 5:
                        await DisplayAvailableBooksAsync();
                        break;
                    case 6:
                        await DisplayBooksAsync();
                        break;
                    case 7:
                        Console.WriteLine("Goodbye!");
                        Thread.Sleep(1000);
                        return;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        private async Task DisplayAvailableBooksAsync()
        {
            var availableBooks = await _bookService.GetAvailableBooksAsync();

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
                    Console.WriteLine($"- {audioBook.Title} (AudioBook) - Duration: {audioBook.runtimeMinutes} mins");
                } else if (book is Book)
                {
                    Console.WriteLine($"- {book.Title} by {book.Author}");
                }
            }
            Console.WriteLine("-----------------------\n");

        }

        private async Task DisplayBooksAsync()
        {
            var Books = await _bookService.GetAllBooksAsync();

            if (!Books.Any())
            {
                Console.WriteLine("No books in the library right now.");
                return;
            }

            Console.WriteLine("\n--- AVAILABLE BOOKS ---");
            foreach (var book in Books)
            {
                if (book is AudioBook audioBook)
                {
                    Console.WriteLine($"- {audioBook.Title} (AudioBook) - Duration: {audioBook.runtimeMinutes} mins");
                }
                else if (book is Book)
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

        private int PromptUserInputInt(string message)
        {
            Console.WriteLine(message);
            int value;
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Please enter a valid number: ");
            }
            
            return value;
        }


    }
}




