using CleanArchitecture.Application.Persistence;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly EfCoreDbContext _context;
        public UserRepository(EfCoreDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetAll()
        {
            var response = await _context.Users.ToListAsync();
            return response;
        }
        public async Task<int> Save(User user)
        {
            await _context.Users.AddAsync(user);
            var response = await _context.SaveChangesAsync();
            return response;
        }
    }
}
