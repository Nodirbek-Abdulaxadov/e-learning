using E_Learning.Domain;
using Microsoft.AspNetCore.Http;

namespace E_Learning.Admin.Services
{
    public interface IFileUploadInterface
    {
        FileModel UploadFile(IFormFile file);
        void DeleteFile(string fileName);
    }
}
