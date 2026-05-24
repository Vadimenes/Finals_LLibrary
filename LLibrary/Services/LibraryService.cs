using LLibrary.Data;
using LLibrary.Models;
using LLibrary.Services;
using Microsoft.EntityFrameworkCore;

namespace LLibrary.Services
{
    /// <summary>Реализация сервиса библиотеки.</summary>
    public class LibraryService : ILibraryService
    {
        private readonly IConfiguration _config;
        private readonly LibraryContext _context; // Добавили контекст

        /// <summary>Конструктор сервиса.</summary>
        public LibraryService(IConfiguration configuration, LibraryContext context)
        {
            _config = configuration;
            _context = context;
        }

        /// <summary>Форматирует список книг для отображения.</summary>
        public async Task<IEnumerable<BookDto>> GetFormattedBooksAsync(IEnumerable<Book> books)
        {
            var maxItems = _config.GetValue<int>("AppSettings:MaxItems", 10);
            var formatted = books
                .OrderBy(b => b.Title)
                .Take(maxItems)
                .Select(b => new BookDto
                {
                    Id = b.BookId,
                    Title = b.Title,
                    ISBN = b.ISBN,
                    AuthorName = b.Author?.FullName ?? "Неизвестный автор",
                    DisplayInfo = $"{b.BookId}|{b.Title} [{b.Author?.LastName}]"
                });
            return await Task.FromResult(formatted);
        }

        /// <summary>Возвращает строку с информацией о сервисе.</summary>
        public string GetServiceInfo()
        {
            return $"LibraryService v{_config["AppSettings:Version"]} | App: {_config["AppSettings:AppName"]}";
        }

        /// <summary>Получает список всех книг с авторами из базы данных.</summary>
        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _context.Books.Include(b => b.Author).ToListAsync();
        }
    }
}