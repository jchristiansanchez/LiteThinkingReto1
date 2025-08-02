using CleanArchitecture.Application.Dto;

namespace CleanArchitecture.Application
{
    public interface IUserApplication
    {
        Task<bool> Save(UserDto user);
        Task<IEnumerable<UserDto>> GetAll();
    }
}
