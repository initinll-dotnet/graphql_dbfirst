using eShop.Catalog.API.Models;
using eShop.Catalog.API.Services;

namespace eShop.Catalog.API.Types;

[ObjectType<Product>]
public static partial class ProductNode
{
    static partial void Configure(IObjectTypeDescriptor<Product> descriptor)
    {
        descriptor
            .Ignore(t => t.BrandId)
            .Ignore(t => t.TypeId)
            .Ignore(t => t.AddStock(default))
            .Ignore(t => t.RemoveStock(default));
    }

    public static async Task<Brand?> GetBrandAsync(
        [Parent] Product product,
        BrandService brandService,
        CancellationToken cancellationToken)
    {
        return await brandService
            .GetBrandByIdAsync(product.BrandId, cancellationToken);
    }

    public static async Task<ProductType?> GetProductTypeAsync(
        [Parent] Product product,
        ProductTypeService productTypeService,
        CancellationToken cancellationToken)
    {
        return await productTypeService
            .GetProductTypesByIdAsync(product.TypeId, cancellationToken);
    }
}
