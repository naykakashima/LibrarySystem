using LibrarySystem.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;



namespace LibrarySystem
{
    class Library
    {
        static async Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            var menu = host.Services.GetRequiredService<Menu>();
            await menu.ShowAsync();

            await host.RunAsync();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureServices((context, services) =>
                {
                    services.AddDbContext<LibraryDbContext>(options =>
                        options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection")));

                    services.AddScoped<IBookRepository, BookRepository>();
                    services.AddScoped<IBookService, BookService>();
                    services.AddScoped<Menu>();
                });
    }
}






