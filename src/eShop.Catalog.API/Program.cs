using eShop.Catalog.API.Data;
using eShop.Catalog.API.Migrations;
using eShop.Catalog.API.Types;

using HotChocolate.Types.Pagination;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContext<CatalogContext>(
        o => o.UseNpgsql(builder.Configuration.GetConnectionString("CatalogDB")));

builder.Services
    .AddMigration<CatalogContext, CatalogContextSeed>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .SetPagingOptions(new PagingOptions
    {
        DefaultPageSize = 2,
        MaxPageSize = 5,
        AllowBackwardPagination = false,
        RequirePagingBoundaries = true,
    })
    .AddProjections();

var app = builder.Build();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);