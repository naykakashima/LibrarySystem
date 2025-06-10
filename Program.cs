using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;


namespace LibrarySystem
{
    class Library
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddSingleton<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, MockBookService>();
            services.AddScoped<Menu>();

            var serviceProvider = services.BuildServiceProvider();


            using (var scope = serviceProvider.CreateScope())
            {
                var menu = scope.ServiceProvider.GetRequiredService<Menu>();
                menu.Show();
            }
        }


    }
}






