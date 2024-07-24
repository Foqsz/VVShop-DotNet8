using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VVShop.ProductApi.VVShop.Core.Models;

namespace VVShop.ProductApi.VVShop.Application.DTOs
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "The name is required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? Name { get; set; }

        [JsonIgnore]
        public ICollection<ProductModel>? Products { get; set; }
    }
}
