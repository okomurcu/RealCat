using RealCat.Core.Dto;
using RealCat.Core.Model;

namespace RealCat.API.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();

        User? GetById(int id);

        Task<User?> GetByUsername(string userName);

        User Create(UserCreateDto user);

    }
}
