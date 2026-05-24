using LLibrary.Models;

namespace LLibrary.Services
{
    /// <summary>Интерфейс сервиса для работы с данными библиотеки.</summary>
    public interface ILibraryService
    {
        /// <summary>Форматирует список книг для отображения.</summary>
        Task<IEnumerable<BookDto>> GetFormattedBooksAsync(IEnumerable<Book> books);

        /// <summary>Возвращает строку с информацией о сервисе.</summary>
        string GetServiceInfo();

        /// <summary>Получает полный список книг из базы данных с подгрузкой авторов.</summary>
        Task<List<Book>> GetAllBooksAsync();
    }

    /// <summary>DTO для передачи данных о книге.</summary>
    public class BookDto
    {
        /// <summary>ID книги.</summary>
        public int Id { get; set; }

        /// <summary>Название книги.</summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>ISBN книги.</summary>
        public string? ISBN { get; set; }

        /// <summary>ФИО автора.</summary>
        public string AuthorName { get; set; } = string.Empty;

        /// <summary>Отображаемая информация.</summary>
        public string DisplayInfo { get; set; } = string.Empty;
    }
}