using CleanArchitecture.Application.Dto;
using CleanArchitecture.Application.Persistence;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application
{
    public class UserApplication : IUserApplication
    {
        public readonly IUserRepository _userRepository;
        public UserApplication(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var response = await _userRepository.GetAll();
            return response.Select(user => new UserDto
            {               
                Nombre = user.Name,
                Email = user.Email
            });
        }

        public async Task<bool> Save(UserDto user)
        {
            var userDomain = new User(user.Nombre, user.Email);

            var respnse = await _userRepository.Save(userDomain);
            return true;
        }
    }
}
