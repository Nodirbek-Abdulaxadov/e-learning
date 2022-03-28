using E_Learning.BL.Interfaces;
using E_Learning.Data;
using E_Learning.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Learning.BL.Repositories
{
    public class ThemeRepository : IThemeInterface
    {
        private readonly ApplicationDbContext _dbContext;

        public ThemeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Theme> AddTheme(Theme theme)
        {
            _dbContext.Themes.Add(theme);
            _dbContext.SaveChanges();
            return Task.FromResult(theme);
        }

        public Task<Theme> GetTheme(Guid id) =>
            Task.FromResult(_dbContext.Themes.FirstOrDefault(x => x.Id == id));

        public Task<List<Theme>> GetThemes(Guid sectionId) =>
            Task.FromResult(_dbContext.Themes.Where(x => x.Id == sectionId).ToList());

        public Task<List<Theme>> GetThemes() =>
            Task.FromResult(_dbContext.Themes.ToList());

        public void RemoveTheme(Guid id)
        {
            var theme = _dbContext.Themes.FirstOrDefault(theme => theme.Id == id);
            _dbContext.Themes.Remove(theme);
            _dbContext.SaveChanges();
        }

        public Task<Theme> UpdateTheme(Theme theme)
        {
            _dbContext.Themes.Update(theme);
            _dbContext.SaveChanges();
            return Task.FromResult(theme);
        }
    }
}
