using LLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace LLibrary.Data
{
    /// <summary>Контекст базы данных для системы школьной библиотеки.</summary>
    public class LibraryContext : DbContext
    {
        /// <summary>Конструктор контекста.</summary>
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        /// <summary>Таблица авторов.</summary>
        public DbSet<Author> Authors { get; set; }

        /// <summary>Таблица книг.</summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>Таблица читателей.</summary>
        public DbSet<Reader> Readers { get; set; }

        /// <summary>Таблица мест хранения.</summary>
        public DbSet<StorageLocation> StorageLocations { get; set; }

        /// <summary>Таблица журнала выдач.</summary>
        public DbSet<BookMovement> BookMovements { get; set; }

        /// <summary>Настройка модели БД: связи, индексы, начальные данные.</summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookMovement>()
                .HasOne(m => m.Book)
                .WithMany(b => b.Movements)
                .HasForeignKey(m => m.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookMovement>()
                .HasOne(m => m.Reader)
                .WithMany(r => r.Movements)
                .HasForeignKey(m => m.ReaderId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Book>().HasIndex(b => b.ISBN).IsUnique();

            modelBuilder.Entity<Author>().HasData(
                new Author { AuthorId = 1, FirstName = "Лев", LastName = "Толстой", BirthDate = new DateTime(1828, 9, 9) },
                new Author { AuthorId = 2, FirstName = "Фёдор", LastName = "Достоевский", BirthDate = new DateTime(1821, 11, 11) },
                new Author { AuthorId = 3, FirstName = "Анна", LastName = "Ахматова", BirthDate = new DateTime(1889, 7, 11) },
                new Author { AuthorId = 4, FirstName = "Николай", LastName = "Лесков", BirthDate = new DateTime(1831, 2, 16) },
                new Author { AuthorId = 5, FirstName = "Николай", LastName = "Гоголь", BirthDate = new DateTime(1809, 3, 20) },
                new Author { AuthorId = 6, FirstName = "Александр", LastName = "Пушкин", BirthDate = new DateTime(1799, 6, 6) },
                new Author { AuthorId = 7, FirstName = "Антон", LastName = "Чехов", BirthDate = new DateTime(1860, 1, 29) },
                new Author { AuthorId = 8, FirstName = "Иван", LastName = "Тургенев", BirthDate = new DateTime(1818, 10, 28) },
                new Author { AuthorId = 9, FirstName = "Михаил", LastName = "Лермонтов", BirthDate = new DateTime(1814, 10, 15) }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "Война и мир", ISBN = "978-5-17-01", AuthorId = 1 },
                new Book { BookId = 2, Title = "Анна Каренина", ISBN = "978-5-17-02", AuthorId = 1 },
                new Book { BookId = 3, Title = "Преступление и наказание", ISBN = "978-5-17-03", AuthorId = 2 }
            );

            modelBuilder.Entity<Reader>().HasData(
                new Reader { ReaderId = 1, FirstName = "Иван", LastName = "Иванов", ClassNumber = "10-А" },
                new Reader { ReaderId = 2, FirstName = "Петр", LastName = "Петров", ClassNumber = "9-Б" }
            );

            modelBuilder.Entity<StorageLocation>().HasData(
                new StorageLocation { LocationId = 1, Room = "Читальный зал", Shelf = "Стеллаж 1" },
                new StorageLocation { LocationId = 2, Room = "Архив", Shelf = "Стеллаж 10" }
            );
        }
    }
}