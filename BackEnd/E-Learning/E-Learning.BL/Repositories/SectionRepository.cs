using E_Learning.BL.Interfaces;
using E_Learning.Data;
using E_Learning.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Learning.BL.Repositories
{
    public class SectionRepository : ISectionInterface
    {
        private readonly ApplicationDbContext _dbContext;

        public SectionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Section> AddSection(Section section)
        {
            _dbContext.Sections.Add(section);
            _dbContext.SaveChanges();
            return Task.FromResult(section);
        }

        public Task<Section> GetSection(Guid id) =>
            Task.FromResult(_dbContext.Sections.FirstOrDefault(section => section.Id == id));

        public Task<List<Section>> GetSections() =>
            Task.FromResult(_dbContext.Sections.ToList());

        public void RemoveSection(Guid id)
        {
            var section = _dbContext.Sections.FirstOrDefault(s => s.Id == id);
            _dbContext.Sections.Remove(section);
            _dbContext.SaveChanges();
        }

        public Task<Section> UpdateSection(Section section)
        {
            _dbContext.Sections.Update(section);
            _dbContext.SaveChanges();
            return Task.FromResult(section);
        }
    }
}
