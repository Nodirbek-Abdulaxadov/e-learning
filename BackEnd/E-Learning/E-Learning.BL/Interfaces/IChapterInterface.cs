using E_Learning.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Learning.BL.Interfaces
{
    public interface IChapterInterface
    {
        Task<List<Chapter>> GetChapters();
        Task<List<Chapter>> GetChaptersWithSections();
        Task<Chapter> GetChapter(Guid id);
        Task<Chapter> AddChapter(Chapter chapter);
        Task<Chapter> UpdateChapter(Chapter chapter);
        void RemoveChapter(Guid id);
    }
}
