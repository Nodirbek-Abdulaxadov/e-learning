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
using System.Threading.Tasks;

namespace E_Learning.BL.Repositories
{
    public class FileRepository : IFileInterface
    {
        private readonly ApplicationDbContext _dbContext;
        private HttpClient httpClient = new HttpClient();

        public FileRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<FileModel> AddFile(IFormFile file)
        {
            if (file is not null)
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
                    var fileObject = JsonConvert.DeserializeObject<List<FileSerializeModel>>(json);

                    FileModel fileModel = new FileModel()
                    {
                        Id = fileObject[0].id,
                        FileName = fileObject[0].file_name,
                        FileLink = fileObject[0].file,
                        FileSize = fileObject[0].file_size,
                        FileType = fileObject[0].file_type,
                        CourseId = Guid.NewGuid()
                    };

                    _dbContext.Files.Add(fileModel);
                    _dbContext.SaveChanges();

                    return fileModel;
                }
            }
            return null;
        }

        public Task<FileModel> GetFile(int id) =>
            Task.FromResult(_dbContext.Files.FirstOrDefault(file => file.Id == id));

        public Task<List<FileModel>> GetFiles(Guid courseId) =>
            Task.FromResult(_dbContext.Files.Where(file => file.CourseId == courseId).ToList());

        public Task<List<FileModel>> GetFiles() =>
            Task.FromResult(_dbContext.Files.ToList());

        public void RemoveFile(int id)
        {
            var file = _dbContext.Files.FirstOrDefault(file => file.Id == id);
            _dbContext.Files.Remove(file);
            _dbContext.SaveChanges();
        }

        public Task<FileModel> UpdateFile(FileModel file)
        {
            _dbContext.Update(file);
            _dbContext.SaveChanges();
            return Task.FromResult(file);
        }
    }
}
