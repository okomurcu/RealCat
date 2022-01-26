using Microsoft.EntityFrameworkCore;

namespace RealCat.Infrastructure
{
    public class CatDbContext : DbContext
    {
        public CatDbContext(DbContextOptions<CatDbContext> options) : base(options)
        {
        }
    }
}
