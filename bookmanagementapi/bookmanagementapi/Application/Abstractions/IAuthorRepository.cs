using BookManagement.Domain;

namespace BookManagement.Application.Abstractions
{
    public interface IAuthorRepository
    {
        Author? Get(long id);
    }
}
