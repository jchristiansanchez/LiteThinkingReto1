using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Persistence
{
    public interface IUserRepository
    {
        Task<int> Save(User user);
        Task<IEnumerable<User>> GetAll();
    }
}
