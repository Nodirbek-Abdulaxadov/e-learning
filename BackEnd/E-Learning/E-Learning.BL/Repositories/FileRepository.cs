using E_Learning.BL.Interfaces;
using E_Learning.Data;
using E_Learning.Domain;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BL.Repositories
{
    public class FileRepository : IFileInterface
    {
        private readonly ApplicationDbContext _dbContext;
        private HttpClient httpClient;

        public FileRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<FileModel> AddFile(IFormFile file)
        {
            httpClient.BaseAddress = new Uri("https://filecloud.pythonanywhere.com/api/");
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var byteArrayContent = new ByteArrayContent(ms.ToArray());
                var multipartContent = new MultipartFormDataContent();
                multipartContent.Add(byteArrayContent, file.ContentType, file.FileName);
                var postResponse = await httpClient.PostAsync("files", multipartContent);
                var json = await postResponse.Content.ReadAsStringAsync();
                var fileObject = JsonConvert.DeserializeObject<FileModel>(json);

                _dbContext.Files.Add(fileObject);
                _dbContext.SaveChanges();

                return fileObject;
            }
        }

        public Task<FileModel> GetFile(int id)
        {
            var file = _dbContext.Files.FirstOrDefault(f => f.id == id);
            return Task.FromResult(file);
        }

        public Task<List<FileModel>> GetFiles(Guid courseId)
        {
            var listFiles = _dbContext.Files.ToList();
            return Task.FromResult(listFiles);
        }

        public Task<List<FileModel>> GetFiles()
        {
            throw new NotImplementedException();
        }

        public void RemoveFile(int id)
        {
            throw new NotImplementedException();
        }

        public Task<FileModel> UpdateFile(FileModel file)
        {
            throw new NotImplementedException();
        }
    }
}
