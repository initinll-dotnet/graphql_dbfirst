using eShop.Catalog.API.Data;
using eShop.Catalog.API.DataLoaders;
using eShop.Catalog.API.Models;

using HotChocolate.Pagination;

namespace eShop.Catalog.API.Services;

public sealed class ProductTypeService(
    CatalogContext context,
    IProductTypeByIdDataLoader productTypeByIdDataLoader)
{
    public async Task<Page<ProductType>> GetProductTypesAsync(
        PagingArguments pagingArguments,
        CancellationToken cancellationToken = default)
    {
        return await context
            .ProductTypes
            .OrderBy(t => t.Name)
            .ThenBy(t => t.Id)
            .ToPageAsync(pagingArguments, cancellationToken);
    }

    public async Task<ProductType?> GetProductTypesByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        return await productTypeByIdDataLoader
            .LoadAsync(id, cancellationToken);
    }
}
