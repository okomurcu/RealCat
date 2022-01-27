using Microsoft.EntityFrameworkCore;
using RealCat.Core.Model;
using RealCat.Infrastructure;

namespace RealCat.API.Services
{
    public class LoginService : ILoginService
    {
        private readonly CatDbContext _context;

        public LoginService(CatDbContext context)
        {
            _context = context;
        }

        public Task<User?> GetUser(string username)
        {
            //var options = new DbContextOptionsBuilder<CatDbContext>()
            //    .UseInMemoryDatabase(databaseName: "CatDb")
            //    .Options;

            //using var context = new CatDbContext(options);
            return _context.Users.FirstOrDefaultAsync(x => x.Username.Equals(username));
        }
    }
}
