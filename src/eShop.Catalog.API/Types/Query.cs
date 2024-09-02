using eShop.Catalog.API.Data;
using eShop.Catalog.API.Models;

using Microsoft.EntityFrameworkCore;

namespace eShop.Catalog.API.Types;

public class Query
{
    [UseProjection]
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
}
