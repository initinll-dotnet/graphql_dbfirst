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
            .SetPagingOptions(new PagingOptions
            {
                DefaultPageSize = 2,
                MaxPageSize = 5,
                AllowBackwardPagination = true,
                RequirePagingBoundaries = true,
            })
            .AddFiltering(f =>
            {
                f.AddDefaults()
                    .BindRuntimeType<string, CustomStringOperationFilterInputType>();
            })
            .AddSorting()
            .AddProjections()
            .AddPagingArguments();

        return builder;
    }
}
