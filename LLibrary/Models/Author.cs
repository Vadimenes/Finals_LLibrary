using LLibrary.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LLibrary.Models
{
    /// <summary>Модель автора книги в библиотеке.</summary>
    [Table("Authors")]
    public class Author
    {
        /// <summary>Уникальный идентификатор автора.</summary>
        [Key]
        public int AuthorId { get; set; }

        /// <summary>Имя автора.</summary>
        [Required, MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>Фамилия автора.</summary>
        [Required, MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        /// <summary>Дата рождения автора.</summary>
        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        /// <summary>Полное имя автора (Имя + Фамилия). Не сохраняется в БД.</summary>
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        /// <summary>Коллекция книг, написанных данным автором.</summary>
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}