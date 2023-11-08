using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharp_App.Models
{
    [Table("T_PRODUCT")]
    public class ProductModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column("name")]
        public string ProductName { get; set; }

        [Required]
        [StringLength(150)]
        [Column("description")]
        public string ProductDescription { get; set; }

        [Required]
        [StringLength(50)]
        [Column("category")]
        public string ProductCategory { get; set; }

        [Required]
        [Column("price")]
        public double ProductPrice { get; set; }

        [Required]
        [Column("created_date")]
        public DateTime CreatedProduct { get; set; }

        [Column("shelf_id")]
        public int? ShelfId { get; set; }




        public ProductModel()
        {
            
        }

        public ProductModel(int id, string productName, string productDescription, string productCategory, double productPrice, DateTime createdProduct)
        {
            Id = id;
            ProductName = productName;
            ProductDescription = productDescription;
            ProductCategory = productCategory;
            ProductPrice = productPrice;
            CreatedProduct = createdProduct;
        }
    }
}
