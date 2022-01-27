namespace RealCat.API.Services
{
    public interface ICatService
    {
        Task<byte[]> GetCat();

        Task<byte[]> GetUpsideDownCat();
    }
}
