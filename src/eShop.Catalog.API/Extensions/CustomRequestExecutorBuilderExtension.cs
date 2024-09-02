using eShop.Catalog.API.Types;
using eShop.Catalog.API.Types.Filters;
using HotChocolate.Execution.Configuration;
using HotChocolate.Types.Pagination;

namespace eShop.Catalog.API.Extensions;

public static class CustomRequestExecutorBuilderExtension
{
    public static IRequestExecutorBuilder AddGraphQLConventions(
        this IRequestExecutorBuilder builder)
    {
        builder
            .AddQueryType<Query>()
            .AddType<ProductFilterInputType>()
            .SetPagingOptions(new PagingOptions
            {
                DefaultPageSize = 2,
                MaxPageSize = 5,
                AllowBackwardPagination = false,
                RequirePagingBoundaries = true,
            })
            .AddFiltering(f =>
            {
                f.AddDefaults()
                    .BindRuntimeType<string, CustomStringOperationFilterInputType>();
            })
            .AddProjections();

        return builder;
    }
}
