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

    public async Task<AddOrderPayload> AddOrderAsync(BooksDbContext context, AddOrderInput input)
    {
        var order = new Order()
        {
            Address = new OrderAddress()
            {
                City = input.City,
                CountryISOCode = input.CountryISOCode,
                PostalCode = input.PostalCode,
                Street = input.Street,
                Person = new Person()
                {
                    FirstName = input.FirstName,
                    LastName = input.LastName
                }
            }
        };

        context.Orders.Add(order);
        await context.SaveChangesAsync();
        return new AddOrderPayload(order);
    }
}
