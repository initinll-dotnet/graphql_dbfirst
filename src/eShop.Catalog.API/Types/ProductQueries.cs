using eShop.Catalog.API.Models;
using eShop.Catalog.API.Services;

using HotChocolate.Pagination;
using HotChocolate.Types.Pagination;

namespace eShop.Catalog.API.Types;

[QueryType]
public static class ProductQueries
{
    [UsePaging]
    public static async Task<Connection<Product>> GetProductsAsync(
        PagingArguments pagingArguments,
        ProductService productService,
        CancellationToken cancellationToken)
    {
        return await productService
            .GetProductsAsync(pagingArguments, cancellationToken)
            .ToConnectionAsync();
    }

    public static async Task<Product?> GetProductByIdAsync(
        int id,
        ProductService productService,
        CancellationToken cancellationToken)
    {
        return await productService
            .GetProductByIdAsync(id, cancellationToken);
    }

    // overriding global paging settings
    //[UsePaging(DefaultPageSize = 1, MaxPageSize = 10)]
    //[UseProjection]
    //[UseFiltering]
    ////[UseFiltering<ProductFilterInputType>]
    //[UseSorting]
    //public static IQueryable<Product> GetProducts(CatalogContext dbContext)
    //{
    //    return dbContext.Products;
    //}

    //[UseFirstOrDefault]
    //[UseProjection]
    //public static IQueryable<Product> GetProductById(int id, CatalogContext dbContext)
    //{
    //    return dbContext.Products.Where(p => p.Id == id);
    //}
}
