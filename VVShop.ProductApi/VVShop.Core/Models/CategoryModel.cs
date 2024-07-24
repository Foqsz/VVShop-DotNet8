using System.ComponentModel.DataAnnotations;

namespace VVShop.ProductApi.VVShop.Core.Models;

public class CategoryModel
{
    [Key]
    public int CategoryId { get; set; }
    public string? Name { get; set; }

    public ICollection<ProductModel>? Products { get; set; }
}
