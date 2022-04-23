using E_Learning.BL.Interfaces;
using E_Learning.Data;
using E_Learning.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Learning.BL.Repositories
{
    public class ChapterRepository : IChapterInterface
    {
        private readonly ApplicationDbContext _dbContext;

        public ChapterRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Chapter> AddChapter(Chapter chapter)
        {
            _dbContext.Chapters.Add(chapter);
            _dbContext.SaveChanges();
            return Task.FromResult(chapter);
        }

        public Task<Chapter> GetChapter(Guid id) =>
            Task.FromResult(_dbContext.Chapters
                .Include(s => s.Sections)
                .FirstOrDefault(Chapter => Chapter.Id == id));

        public Task<List<Chapter>> GetChapters() =>
            Task.FromResult(_dbContext.Chapters.ToList());

        public Task<List<Chapter>> GetChaptersWithSections()
        {
            var listOfChapters = _dbContext.Chapters.Include(chapter => chapter.Sections).ToList();

            return Task.FromResult(listOfChapters);
        }

        public void RemoveChapter(Guid id)
        {
            var Chapter = _dbContext.Chapters.FirstOrDefault(s => s.Id == id);
            _dbContext.Chapters.Remove(Chapter);
            _dbContext.SaveChanges();
        }

        public Task<Chapter> UpdateChapter(Chapter chapter)
        {
            _dbContext.Chapters.Update(chapter);
            _dbContext.SaveChanges();
            return Task.FromResult(chapter);
        }
    }
}
