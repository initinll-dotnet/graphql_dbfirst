using eShop.Catalog.API.Data;
using eShop.Catalog.API.DataLoaders;
using eShop.Catalog.API.Models;

using HotChocolate.Pagination;

namespace eShop.Catalog.API.Services;

public sealed class ProductService(
    CatalogContext context,
    IProductByIdDataLoader productByIdDataLoader)
{
    public async Task<Page<Product>> GetProductsAsync(
        PagingArguments pagingArguments,
        CancellationToken cancellationToken = default)
    {
        return await context
            .Products
            .OrderBy(t => t.Name)
            .ThenBy(t => t.Id)
            .ToPageAsync(pagingArguments, cancellationToken);
    }

    public async Task<Product?> GetProductByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        return await productByIdDataLoader
            .LoadAsync(id, cancellationToken);
    }
}
