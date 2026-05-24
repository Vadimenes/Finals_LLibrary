using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LLibrary.Models
{
    /// <summary>Модель места хранения книги.</summary>
    [Table("StorageLocations")]
    public class StorageLocation
    {
        /// <summary>Уникальный идентификатор места хранения.</summary>
        [Key]
        public int LocationId { get; set; }

        /// <summary>Название помещения.</summary>
        [Required, MaxLength(50)]
        public string Room { get; set; } = string.Empty;

        /// <summary>Обозначение стеллажа или полки.</summary>
        [Required, MaxLength(50)]
        public string Shelf { get; set; } = string.Empty;
    }
}