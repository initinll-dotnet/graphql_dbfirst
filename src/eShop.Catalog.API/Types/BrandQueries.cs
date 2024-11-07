using eShop.Catalog.API.Models;
using eShop.Catalog.API.Services;

using HotChocolate.Pagination;

using HotChocolate.Types.Pagination;

namespace eShop.Catalog.API.Types;

[QueryType]
public static class BrandQueries
{
    [UsePaging]
    public static async Task<Connection<Brand>> GetBrandsAsync(
        PagingArguments pagingArguments,
        BrandService brandService,
        CancellationToken cancellationToken)
    {
        return await brandService
            .GetBrandsAsync(pagingArguments, cancellationToken)
            .ToConnectionAsync();
    }

    public static async Task<Brand?> GetBrandByIdAsync(
        int id,
        BrandService brandService,
        CancellationToken cancellationToken)
    {
        return await brandService
            .GetBrandByIdAsync(id, cancellationToken);
    }

    //[UsePaging(DefaultPageSize = 1, MaxPageSize = 10)]
    //[UseProjection]
    //[UseFiltering]
    //public static IQueryable<Brand> GetBrands(CatalogContext dbContext)
    //{
    //    return dbContext.Brands;
    //}

    //[UseFirstOrDefault]
    //[UseProjection]
    //public static IQueryable<Brand> GetBrandById(int id, CatalogContext dbContext)
    //{
    //    return dbContext.Brands.Where(b => b.Id == id);
    //}
}
