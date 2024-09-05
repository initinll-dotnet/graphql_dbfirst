using eShop.Catalog.API.Models;
using eShop.Catalog.API.Services;

using HotChocolate.Pagination;

using HotChocolate.Types.Pagination;

namespace eShop.Catalog.API.Types;

[QueryType]
public static class ProductTypeQueries
{
    [UsePaging]
    public static async Task<Connection<ProductType>> GetProductTypesAsync(
        PagingArguments pagingArguments,
        ProductTypeService productTypeService,
        CancellationToken cancellationToken)
    {
        return await productTypeService
            .GetProductTypesAsync(pagingArguments, cancellationToken)
            .ToConnectionAsync();
    }

    public static async Task<ProductType?> GetProductByIdAsync(
        int id,
        ProductTypeService productTypeService,
        CancellationToken cancellationToken)
    {
        return await productTypeService
            .GetProductTypesByIdAsync(id, cancellationToken);
    }

    //[UsePaging]
    //[UseProjection]
    //[UseFiltering]
    //public static IQueryable<ProductType> GetProductTypes(CatalogContext dbContext)
    //{
    //    return dbContext.ProductTypes;
    //}

    //[UseFirstOrDefault]
    //[UseProjection]
    //public static IQueryable<ProductType> GetProductTypeById(int id, CatalogContext dbContext)
    //{
    //    return dbContext.ProductTypes.Where(p => p.Id == id);
    //}
}
