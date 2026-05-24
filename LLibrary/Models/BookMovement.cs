using LLibrary.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LLibrary.Models
{
    /// <summary>Модель записи о перемещении или выдаче книги.</summary>
    [Table("BookMovements")]
    public class BookMovement
    {
        /// <summary>Уникальный идентификатор записи.</summary>
        [Key]
        public int MovementId { get; set; }

        /// <summary>Идентификатор книги.</summary>
        public int BookId { get; set; }

        /// <summary>Навигационное свойство: книга.</summary>
        public virtual Book? Book { get; set; }

        /// <summary>Идентификатор читателя.</summary>
        public int? ReaderId { get; set; }

        /// <summary>Навигационное свойство: читатель.</summary>
        public virtual Reader? Reader { get; set; }

        /// <summary>Идентификатор исходного места хранения.</summary>
        public int? FromLocationId { get; set; }

        /// <summary>Навигационное свойство: исходное место.</summary>
        public virtual StorageLocation? FromLocation { get; set; }

        /// <summary>Идентификатор целевого места хранения.</summary>
        public int? ToLocationId { get; set; }

        /// <summary>Навигационное свойство: целевое место.</summary>
        public virtual StorageLocation? ToLocation { get; set; }

        /// <summary>Дата и время операции.</summary>
        [Required]
        public DateTime ActionDate { get; set; } = DateTime.UtcNow;

        /// <summary>Флаг возврата книги.</summary>
        public bool IsReturned { get; set; } = false;
    }
}