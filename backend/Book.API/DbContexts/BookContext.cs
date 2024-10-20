using Book.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Book.API.DbContexts
{
    public class BookContext(DbContextOptions<BookContext> options) : DbContext(options)
    {
        public DbSet<Entities.Book> Books { get; set; }
        public DbSet<Page> Pages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Books
            var book1Id = Guid.NewGuid();
            var book2Id = Guid.NewGuid();

            modelBuilder.Entity<Entities.Book>().HasData(
                new Entities.Book
                {
                    Id = book1Id,
                    Title = "Book One",
                    Author = "Author A",
                    IsInStock = true
                },
                new Entities.Book
                {
                    Id = book2Id,
                    Title = "Book Two",
                    Author = "Author B",
                    IsInStock = false
                }
            );

            // Seed Pages
            modelBuilder.Entity<Page>().HasData(
                new Page
                {
                    Id = Guid.NewGuid(),
                    PageNumber = 1,
                    Content = "Content of page 1 in Book One",
                    BookId = book1Id
                },
                new Page
                {
                    Id = Guid.NewGuid(),
                    PageNumber = 2,
                    Content = "Content of page 2 in Book One",
                    BookId = book1Id
                },
                new Page
                {
                    Id = Guid.NewGuid(),
                    PageNumber = 1,
                    Content = "Content of page 1 in Book Two",
                    BookId = book2Id
                },
                new Page
                {
                    Id = Guid.NewGuid(),
                    PageNumber = 2,
                    Content = "Content of page 2 in Book Two",
                    BookId = book2Id
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
