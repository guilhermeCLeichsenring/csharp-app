using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharp_App.Models
{
    [Table("T_SHELF")]
    public class ShelfModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [Column("shelf_hall")]
        public int ShelfHall { get; set; }

    }
}
