using BookManagement.Domain;
using BookManagement.Infrastructure.EntityFramework;

namespace BookManagement.GraphQL.Mutations;

public class Mutation
{
    public async Task<AddAuthorPayload> AddAuthorAsync(BooksDbContext context, AddAuthorInput input)
    {
        var author = new Author()
        {
            BirthDay = input.BirthDay,
            FirstName = input.FirstName,
            LastName = input.LastName
        };

        context.Authors.Add(author);
        await context.SaveChangesAsync();
        return new AddAuthorPayload(author);
    }
}
