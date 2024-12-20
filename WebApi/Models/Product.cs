using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class Product
    {
        [Key]
        [Column("id")]
        public int Id {  get; set; }

        [Column("name")]
        [MaxLength(255)]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Column("price")]
        [Required]
        public int Price { get; set; }
    }
}
