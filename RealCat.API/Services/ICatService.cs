namespace RealCat.API.Services
{
    public interface ICatService
    {
        Task<byte[]> Get();

        Task<byte[]> GetUpsideDown();
    }
}
