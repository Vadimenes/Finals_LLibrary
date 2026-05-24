using LLibrary.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LLibrary.Models
{
    /// <summary>Модель книги в библиотеке.</summary>
    [Table("Books")]
    public class Book
    {
        /// <summary>Уникальный идентификатор книги.</summary>
        [Key]
        public int BookId { get; set; }

        /// <summary>Название книги.</summary>
        [Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        /// <summary>Международный стандартный книжный номер (ISBN).</summary>
        [MaxLength(20)]
        public string? ISBN { get; set; }

        /// <summary>Идентификатор автора книги.</summary>
        public int AuthorId { get; set; }

        /// <summary>Навигационное свойство: автор книги.</summary>
        public virtual Author? Author { get; set; }

        /// <summary>Коллекция записей о перемещениях/выдачах данной книги.</summary>
        public virtual ICollection<BookMovement> Movements { get; set; } = new List<BookMovement>();
    }
}