using eShop.Catalog.API.Data;
using eShop.Catalog.API.Models;

using Microsoft.EntityFrameworkCore;

namespace eShop.Catalog.API.Types;

public class Query
{
    public IQueryable<Product> GetProducts(CatalogContext dbContext)
    {
        return dbContext.Products;
    }

    public async Task<Product?> GetProductById(int id, CatalogContext dbContext)
    {
        return await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
    }
}
