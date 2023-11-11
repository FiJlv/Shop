using Microsoft.AspNetCore.Http;

namespace Shop.BLL.Intefaces
{
    public interface IFileService
    {
        FileStream ImageStream(string image);
        Task<string> SaveImage(IFormFile image);

        bool RemoveImage(string image);
    }
}
