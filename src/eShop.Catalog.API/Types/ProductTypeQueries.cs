using eShop.Catalog.API.Data;
using eShop.Catalog.API.Models;

namespace eShop.Catalog.API.Types;

[QueryType]
public static class ProductTypeQueries
{
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    public static IQueryable<ProductType> GetProductTypes(CatalogContext dbContext)
    {
        return dbContext.ProductTypes;
    }

    [UseFirstOrDefault]
    [UseProjection]
    public static IQueryable<ProductType> GetProductTypeById(int id, CatalogContext dbContext)
    {
        return dbContext.ProductTypes.Where(p => p.Id == id);
    }
}
