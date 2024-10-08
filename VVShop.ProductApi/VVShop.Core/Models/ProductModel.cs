﻿using System.Text.Json.Serialization;

namespace VVShop.ProductApi.VVShop.Core.Models;

public class ProductModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public long Stock { get; set; }
    public string? ImageUrl { get; set; }

    [JsonIgnore]
    public CategoryModel? Category { get; set; }
    public int CategoryId { get; set; }
}
