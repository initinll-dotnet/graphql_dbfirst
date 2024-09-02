using eShop.Catalog.API.Models;

using HotChocolate.Data.Sorting;

namespace eShop.Catalog.API.Types.Sortings;

public class ProductSortInputType : SortInputType<Product>
{
    protected override void Configure(ISortInputTypeDescriptor<Product> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(f => f.Name);
        descriptor.Field(f => f.Price);
        descriptor.Field(f => f.Brand).Type<BrandSortInputType>();
        descriptor.Field(f => f.Type).Type<ProductTypeSortInputType>();
    }
}
