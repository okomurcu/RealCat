using System.Drawing;
using Microsoft.Extensions.Options;
using RealCat.API.Helpers;

namespace RealCat.API.Services
{
    public class CatService : ICatService
    {
        private readonly string _providerUrl;

        public CatService(IOptions<AppSettings> appSettings)
        {
            _providerUrl = appSettings.Value.ServiceProvider + "cat";
        }

        public async Task<byte[]> Get()
        {
            var image = await GetAsync(_providerUrl);

            return ConvertToByteArray(image);
        }

        public async Task<byte[]> GetUpsideDown()
        {
            var image = await GetAsync(_providerUrl);

            image.RotateFlip(RotateFlipType.Rotate180FlipNone);

            return ConvertToByteArray(image);
        }

        public async Task<byte[]> GetWithCustomRotation(string rotation)
        {
            var image = await GetAsync(_providerUrl);
            
            if (rotation == "90")
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);

            if (rotation == "180")
                image.RotateFlip(RotateFlipType.Rotate180FlipNone);

            if (rotation == "270")
                image.RotateFlip(RotateFlipType.Rotate270FlipNone);

            return ConvertToByteArray(image);
        }

        public async Task<byte[]> GetWithImageFilter(string imageFilter)
        {
            var image = await GetAsync(_providerUrl + "?filter=" + imageFilter);

            return ConvertToByteArray(image);
        }

        public async Task<byte[]> GetWithWidthAndHeight(int width, int height)
        {
            var image = await GetAsync(_providerUrl + $"?width={width}&height={height}");

            return ConvertToByteArray(image);
        }

        #region Private Methods
        private static async Task<Image> GetAsync(string url)
        {
            byte[] bytes;
            using (var client = new HttpClient())
            {
                using var response = await client.GetAsync(url);
                bytes = await response.Content.ReadAsByteArrayAsync();
            }

            MemoryStream memoryStream = new(bytes);
            return Image.FromStream(memoryStream);
        }

        private static byte[] ConvertToByteArray(Image image)
        {
            MemoryStream memoryStream = new();
            image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            return memoryStream.ToArray();
        }

        #endregion
    }
}
