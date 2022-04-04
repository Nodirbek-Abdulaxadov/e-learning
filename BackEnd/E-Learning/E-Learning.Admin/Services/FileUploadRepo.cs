using E_Learning.Data;
using E_Learning.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace E_Learning.Admin.Services
{
    public class FileUploadRepo : IFileUploadInterface
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ApplicationDbContext _dbContext;

        public FileUploadRepo(IWebHostEnvironment environment,
                              ApplicationDbContext dbContext)
        {
            _environment = environment;
            _dbContext = dbContext;
        }
        public void DeleteFile(string fileName)
        {
            throw new System.NotImplementedException();
        }

        public FileModel UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string uplodFolder = Path.Combine(_environment.WebRootPath, "uploads");
                string filePath = Path.Combine(uplodFolder, file.FileName);
                FileStream fileStream = new FileStream(filePath, FileMode.Create);
                file.CopyTo(fileStream);
                fileStream.Close();
            }

            FileModel fileModel = new FileModel()
            {
                Id = Guid.NewGuid(),
                FileLink = "https://e-learning.software-engineer.uz/uploads/" + file.FileName,
                FileName = file.FileName,
                FileType = file.ContentType,
                FileSize = (file.Length/1024).ToString(),
                KursId = Guid.NewGuid()
            };

            _dbContext.Files.Add(fileModel);
            _dbContext.SaveChanges();

            return fileModel;
        }
    }
}
