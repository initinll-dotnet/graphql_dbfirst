using eShop.Catalog.API.Data;
using eShop.Catalog.API.Models;

using Microsoft.EntityFrameworkCore;

namespace eShop.Catalog.API.DataLoaders;

public sealed class ProductTypeDataLoader
{
    [DataLoader]
    internal static async Task<Dictionary<int, ProductType>> GetProductTypeByIdAsync(
        IReadOnlyList<int> keys,
        CatalogContext catalogContext,
        CancellationToken cancellationToken)
    {
        return await catalogContext
                        .ProductTypes
                        .Where(t => keys.Contains(t.Id))
                        .ToDictionaryAsync(t => t.Id, cancellationToken);
    }
}
