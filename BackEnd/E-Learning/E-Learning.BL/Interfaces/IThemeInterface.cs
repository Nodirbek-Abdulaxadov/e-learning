using E_Learning.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Learning.BL.Interfaces
{
    public interface IThemeInterface
    {
        Task<List<Theme>> GetThemes(Guid sectionId);
        Task<List<Theme>> GetThemes();
        Task<Theme> GetTheme(Guid id);
        Task<Theme> AddTheme(Theme theme);
        Task<Theme> UpdateTheme(Theme theme);
        void RemoveTheme(Guid id);
    }
}
