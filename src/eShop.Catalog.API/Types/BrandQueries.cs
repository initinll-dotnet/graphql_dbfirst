using eShop.Catalog.API.Data;
using eShop.Catalog.API.Models;

namespace eShop.Catalog.API.Types;

[QueryType]
public static class BrandQueries
{
    [UsePaging(DefaultPageSize = 1, MaxPageSize = 10)]
    [UseProjection]
    [UseFiltering]
    public static IQueryable<Brand> GetBrands(CatalogContext dbContext)
    {
        return dbContext.Brands;
    }

    [UseFirstOrDefault]
    [UseProjection]
    public static IQueryable<Brand> GetBrandById(int id, CatalogContext dbContext)
    {
        return dbContext.Brands.Where(b => b.Id == id);
    }
}
