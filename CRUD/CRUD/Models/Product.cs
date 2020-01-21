using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [Display(Name="money")]
        public double Price { get; set; }
    }
}
