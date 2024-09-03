using eShop.Catalog.API.Data;
using eShop.Catalog.API.Models;

namespace eShop.Catalog.API.Types;

[QueryType]
public static class ProductQueries
{
    // overriding global paging settings
    [UsePaging(DefaultPageSize = 1, MaxPageSize = 10)]
    [UseProjection]
    [UseFiltering]
    //[UseFiltering<ProductFilterInputType>]
    [UseSorting]
    public static IQueryable<Product> GetProducts(CatalogContext dbContext)
    {
        return dbContext.Products;
    }

    [UseFirstOrDefault]
    [UseProjection]
    public static IQueryable<Product> GetProductById(int id, CatalogContext dbContext)
    {
        return dbContext.Products.Where(p => p.Id == id);
    }

    //public async Task<Product?> GetProductById(int id, CatalogContext dbContext)
    //{
    //    return await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
    //}
}
