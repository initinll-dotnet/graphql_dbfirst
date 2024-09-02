using eShop.Catalog.API.Models;

using HotChocolate.Data.Filters;

namespace eShop.Catalog.API.Filters;

public class ProductFilterInputType : FilterInputType<Product>
{
    protected override void Configure(IFilterInputTypeDescriptor<Product> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(f => f.Name).Type<SearchStringOperationFilterInputType>();
        descriptor.Field(f => f.Type);
        descriptor.Field(f => f.Price);
        descriptor.Field(f => f.Brand);
        descriptor.Field(f => f.AvailableStock);
    }
}
