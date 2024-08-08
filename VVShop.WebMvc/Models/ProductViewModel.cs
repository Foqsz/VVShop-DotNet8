using System.ComponentModel.DataAnnotations;

namespace VVShop.WebMvc.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        [Range(1, 9999)]
        public long Stock { get; set; }
        [Required]
        public string? ImageUrl { get; set; }
        [Display(Name = "Category Name")]
        public string? CategoryName { get; set; }
        [Range(1, 100)]
        public int Quantity { get; set; } = 1;
        [Display(Name = "Category Id")]
        public int CategoryId { get; set; }
    }
}
