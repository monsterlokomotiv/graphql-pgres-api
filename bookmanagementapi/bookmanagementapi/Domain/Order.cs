namespace BookManagement.Domain;

public class Order
{
    public long Id { get; set; }
    public OrderAddress Address { get; set; } = default!;
}

public class OrderAddress
{
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string CountryISOCode { get; set; } = string.Empty;
    public Person Person { get; set; }
}

public class Person
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}