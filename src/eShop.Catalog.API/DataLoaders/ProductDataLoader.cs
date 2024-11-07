using eShop.Catalog.API.Data;
using eShop.Catalog.API.Models;

using Microsoft.EntityFrameworkCore;

namespace eShop.Catalog.API.DataLoaders;

internal static class ProductDataLoader
{
    [DataLoader]
    internal static async Task<Dictionary<int, Product>> GetProductByIdAsync(
        IReadOnlyList<int> keys,
        CatalogContext catalogContext,
        CancellationToken cancellationToken)
    {
        return await catalogContext
                        .Products
                        .Where(t => keys.Contains(t.Id))
                        .ToDictionaryAsync(t => t.Id, cancellationToken);
    }
}
