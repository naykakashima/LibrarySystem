using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LibrarySystem;

namespace LibrarySystem.Database
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<AudioBook> AudioBooks { get; set; }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasBaseType<BookBase>();
            modelBuilder.Entity<AudioBook>().HasBaseType<BookBase>();

            base.OnModelCreating(modelBuilder);
        }
    }

}
