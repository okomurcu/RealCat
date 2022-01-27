using Microsoft.EntityFrameworkCore;
using RealCat.Core.Model;

namespace RealCat.Infrastructure
{
    public class CatDbContext : DbContext
    {
        public CatDbContext(DbContextOptions<CatDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
