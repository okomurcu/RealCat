using Microsoft.EntityFrameworkCore;
using RealCat.Core.Dto;
using RealCat.Core.Model;
using RealCat.Infrastructure;

namespace RealCat.API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly CatDbContext _context;

        public UserRepository(CatDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User? GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public Task<User?> GetByUsername(string username)
        {
            return _context.Users.FirstOrDefaultAsync(x => x.Username.Equals(username));
        }

        public User Create(UserCreateDto userRequest)
        {
            var user = new User
            {
                Username = userRequest.Username,
                Password = userRequest.Password
            };
            _context.Add(user);
            _context.SaveChanges();

            return user;
        }
    }
}
