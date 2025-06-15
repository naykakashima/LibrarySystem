using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Database
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<BookBase> Books { get; set; }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookBase>().ToTable("Books");
            modelBuilder.Entity<Book>().ToTable("Books_Physical");
            modelBuilder.Entity<AudioBook>().ToTable("Books_Audio");

            // Configure GUID as PK
            modelBuilder.Entity<BookBase>().HasKey(b => b.Id);
        }
    }

}
