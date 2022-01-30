namespace RealCat.API.Services
{
    public interface ICatService
    {
        Task<byte[]> Get();

        Task<byte[]> GetUpsideDown();

        Task<byte[]> GetWithCustomRotation(string rotation);

        Task<byte[]> GetWithImageFilter(string imageFilter);

        Task<byte[]> GetWithWidthAndHeight(int width, int height);
    }
}
