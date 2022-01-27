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
    }
}
