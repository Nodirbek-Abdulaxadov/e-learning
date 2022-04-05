using E_Learning.BL.Interfaces;
using E_Learning.Data;
using E_Learning.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BL.Repositories
{
    public class FileRepo : IFileInterface
    {
        private readonly ApplicationDbContext _dbContext;

        public FileRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteFile(FileModel file)
        {
            _dbContext.Remove(file);
        }

        public FileModel GetFile(Guid id) =>
            _dbContext.Files.FirstOrDefault(f => f.Id == id);

        public List<FileModel> GetFiles(Guid courseId) =>
            _dbContext.Files.Where(file => file.KursId == courseId).ToList();
    }
}
