using BookManagement.GraphQL.DataLoaders;
using BookManagement.GraphQL.Mutations;
using BookManagement.GraphQL.Queries;
using BookManagement.Infrastructure.EntityFramework;

namespace BookManagement.GraphQL;

public static class GraphQLServiceExtensions
{
    public static IServiceCollection ConfigureGraphQL(this IServiceCollection services)
    {
        services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddProjections()
                .AddFiltering()
                .AddSorting()
                .AddDataLoader<AuthorsByIdDataLoader>()
                .AddDataLoader<BooksByIdDataLoader>()
                .AddDataLoader<CategoriesByIdDataLoader>()
                .AddDataLoader<SeriesByIdDataLoader>()
                .AddMutationType<Mutation>()
                .RegisterService<BooksDbContext>();

        return services;
    }
}
