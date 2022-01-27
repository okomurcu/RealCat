using RealCat.Core.Dto;
using RealCat.Core.Model;

namespace RealCat.API.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();

        User? GetById(int id);

        User Create(UserCreateDto user);

    }
}
