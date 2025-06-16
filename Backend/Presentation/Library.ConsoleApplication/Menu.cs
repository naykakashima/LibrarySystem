using LibrarySystem;
using Serilog;
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
                    Console.WriteLine("Invalid input! Enter 1-7:");
                }

                (bool Success, string Message) result;

                try
                {
                    switch (res)
                    {
                        case 1:
                            var borrowTitle = PromptUserInput("Enter Book Title: ");
                            result = await _bookService.BorrowBookAsync(borrowTitle);
                            Console.WriteLine(result.Message);
                            Log.Information("Borrow attempt: '{Title}' | Success: {Success}", borrowTitle, result.Success);
                            break;

                        case 2:
                            var returnTitle = PromptUserInput("Enter Book Title: ");
                            result = await _bookService.ReturnBookAsync(returnTitle);
                            Console.WriteLine(result.Message);
                            Log.Information("Return attempt: '{Title}' | Success: {Success}", returnTitle, result.Success);
                            break;

                        case 3:
                            var donateTitle = PromptUserInput("Enter Book Title: ");
                            var donateAuthor = PromptUserInput("Enter Book Author: ");
                            result = await _bookService.DonateBookAsync(donateTitle, donateAuthor);
                            Console.WriteLine(result.Message);
                            Log.Information("Donated book: {Title} by {Author}", donateTitle, donateAuthor);
                            break;

                        case 4:
                            var audioTitle = PromptUserInput("Enter Audio Book Title: ");
                            var audioAuthor = PromptUserInput("Enter Audio Book Author: ");
                            var runtime = PromptUserInputInt("Enter Audio Book Runtime: ");
                            result = await _bookService.DonateAudioBookAsync(audioTitle, audioAuthor, runtime);
                            Console.WriteLine(result.Message);
                            Log.Information("Donated audiobook: {Title} by {Author} | Runtime: {Runtime} mins", audioTitle, audioAuthor, runtime);
                            break;

                        case 5:
                            await DisplayAvailableBooksAsync();
                            break;

                        case 6:
                            await DisplayBooksAsync();
                            break;

                        case 7:
                            Console.WriteLine("Goodbye!");
                            Log.Information("Application exited by user.");
                            Thread.Sleep(1000);
                            return;
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "An error occurred while processing menu option {Option}", res);
                    Console.WriteLine("An unexpected error occurred. Check the log file for details.");
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
                Log.Information("No available books to display.");
                return;
            }

            Console.WriteLine("\n--- AVAILABLE BOOKS ---");
            foreach (var book in availableBooks)
            {
                if (book is AudioBook audioBook)
                    Console.WriteLine($"- {audioBook.Title} (AudioBook) - Duration: {audioBook.runtimeMinutes} mins");
                else if (book is Book)
                    Console.WriteLine($"- {book.Title} by {book.Author}");
            }
            Console.WriteLine("-----------------------\n");

            Log.Information("Displayed {Count} available books.", availableBooks.Count());
        }

        private async Task DisplayBooksAsync()
        {
            var books = await _bookService.GetAllBooksAsync();

            if (!books.Any())
            {
                Console.WriteLine("No books in the library right now.");
                Log.Information("No books in the library to display.");
                return;
            }

            Console.WriteLine("\n--- ALL BOOKS ---");
            foreach (var book in books)
            {
                if (book.Type == "AudioBook")
                    Console.WriteLine($"- {book.Title} (AudioBook) - Duration: {book.RuntimeMinutes} mins");
                else
                    Console.WriteLine($"- {book.Title} by {book.Author}");
            }
            Console.WriteLine("-----------------------\n");

            Log.Information("Displayed all books. Total count: {Count}", books.Count());
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