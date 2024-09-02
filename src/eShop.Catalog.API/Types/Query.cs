using eShop.Catalog.API.Data;
using eShop.Catalog.API.Models;

namespace eShop.Catalog.API.Types;

public class Query
{
    [UsePaging(DefaultPageSize = 1, MaxPageSize = 10)]
    [UseProjection]
    [UseFiltering]
    public IQueryable<Brand> GetBrands(CatalogContext dbContext)
    {
        return dbContext.Brands;
    }

    [UseFirstOrDefault]
    [UseProjection]
    public IQueryable<Brand> GetBrandById(int id, CatalogContext dbContext)
    {
        return dbContext.Brands.Where(b => b.Id == id);
    }

    // overriding global paging settings
    [UsePaging(DefaultPageSize = 1, MaxPageSize = 10)]
    [UseProjection]
    [UseFiltering]
    //[UseFiltering<ProductFilterInputType>]
    [UseSorting]
    public IQueryable<Product> GetProducts(CatalogContext dbContext)
    {
        return dbContext.Products;
    }

    [UseFirstOrDefault]
    [UseProjection]
    public IQueryable<Product> GetProductById(int id, CatalogContext dbContext)
    {
        return dbContext.Products.Where(p => p.Id == id);
    }

    //public async Task<Product?> GetProductById(int id, CatalogContext dbContext)
    //{
    //    return await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
    //}

    [UsePaging]
    [UseProjection]
    [UseFiltering]
    public IQueryable<ProductType> GetProductTypes(CatalogContext dbContext)
    {
        return dbContext.ProductTypes;
    }

    [UseFirstOrDefault]
    [UseProjection]
    public IQueryable<ProductType> GetProductTypeById(int id, CatalogContext dbContext)
    {
        return dbContext.ProductTypes.Where(p => p.Id == id);
    }
}
