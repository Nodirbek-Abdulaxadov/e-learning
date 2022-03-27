using E_Learning.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Learning.BL.Interfaces
{
    public interface IFileInterface
    {
        Task<List<FileModel>> GetFiles(Guid courseId);
        Task<List<FileModel>> GetFiles();
        Task<FileModel> GetFile(int id);
        Task<FileModel> AddFile(IFormFile file);
        Task<FileModel> UpdateFile(FileModel file);
        void RemoveFile(int id);
    }
}
