using BookManagement.Domain;

namespace BookManagement.GraphQL.Mutations;

public record AddOrderInput(string City, string CountryISOCode, string FirstName, string LastName, string PostalCode, string Street);

public class AddOrderPayload
{
    public AddOrderPayload(Order order)
    {
        Order = order;
    }
    public Order Order { get; }
}
