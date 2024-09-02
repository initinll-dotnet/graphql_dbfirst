using System.ComponentModel.DataAnnotations;

using static eShop.Catalog.API.Types.Configurations.UseToUpperObjectFieldDescriptorExtensions;

namespace eShop.Catalog.API.Models;

public sealed class Brand
{
    public int Id { get; set; }

    [Required]
    [UseToUpper]
    public string Name { get; set; } = default!;

    public ICollection<Product> Products { get; } = new List<Product>();
}
