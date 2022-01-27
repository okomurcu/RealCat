using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RealCat.Core.Model;

namespace RealCat.Infrastructure
{
    public static class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();

            var context = serviceScope.ServiceProvider.GetService<CatDbContext>();
            context?.Database.EnsureCreated();

            if (context != null && !context.Users.Any())
            {
                context.Users.Add(new User { Username = "admin", Password = "admin" });
                context.SaveChanges();
            }
        }
    }
}
