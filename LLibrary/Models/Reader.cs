using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LLibrary.Models
{
    /// <summary>Модель читателя библиотеки.</summary>
    [Table("Readers")]
    public class Reader
    {
        /// <summary>Уникальный идентификатор читателя.</summary>
        [Key]
        public int ReaderId { get; set; }

        /// <summary>Имя читателя.</summary>
        [Required, MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>Фамилия читателя.</summary>
        [Required, MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        /// <summary>Класс или статус читателя.</summary>
        [MaxLength(20)]
        public string ClassNumber { get; set; } = string.Empty; // Класс или статус

        /// <summary>Полное имя читателя. Не сохраняется в БД.</summary>
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        /// <summary>Коллекция записей о выдачах/возвратах книг данному читателю.</summary>
        public virtual ICollection<BookMovement> Movements { get; set; } = new List<BookMovement>();
    }
}