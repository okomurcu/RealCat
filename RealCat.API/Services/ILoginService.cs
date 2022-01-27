using RealCat.Core.Model;

namespace RealCat.API.Services
{
    public interface ILoginService
    {
        Task<User?> GetUser(string userName);
    }
}
