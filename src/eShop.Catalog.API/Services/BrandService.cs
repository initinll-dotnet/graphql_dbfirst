using eShop.Catalog.API.Data;
using eShop.Catalog.API.DataLoaders;
using eShop.Catalog.API.Models;

using HotChocolate.Pagination;

namespace eShop.Catalog.API.Services;

public sealed class BrandService(
    CatalogContext context,
    IBrandByIdDataLoader brandByIdDataLoader)
{
    public async Task<Page<Brand>> GetBrandsAsync(
        PagingArguments pagingArguments,
        CancellationToken cancellationToken = default)
    {
        return await context
            .Brands
            .OrderBy(t => t.Name)
            .ThenBy(t => t.Id)
            .ToPageAsync(pagingArguments, cancellationToken);
    }

    public async Task<Brand?> GetBrandByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        return await brandByIdDataLoader
            .LoadAsync(id, cancellationToken);
    }
}
