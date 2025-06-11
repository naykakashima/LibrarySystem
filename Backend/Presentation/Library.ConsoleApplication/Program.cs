using LibrarySystem.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Threading.Tasks;


namespace LibrarySystem
{
    class Library
    {
        static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

            try
            {
                Log.Information("Starting Library System...");

                using IHost host = CreateHostBuilder(args).Build();
                var menu = host.Services.GetRequiredService<Menu>();
                await menu.ShowAsync();
                await host.RunAsync();

                Log.Information("Application exited cleanly.");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application crashed!");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args).ConfigureServices((context, services) =>
        {
            services.AddDbContext<LibraryDbContext>(options => options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<Menu>();
        });
    }
}






