using Microsoft.AspNetCore.Http;

namespace Shop.BLL.FileManager
{
    public interface IFileManager
    {
        FileStream ImageStream(string image);
        Task<string> SaveImage(IFormFile image);

        bool RemoveImage(string image);
    }
}
