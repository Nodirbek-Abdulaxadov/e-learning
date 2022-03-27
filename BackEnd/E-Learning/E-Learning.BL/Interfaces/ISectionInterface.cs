using E_Learning.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Learning.BL.Interfaces
{
    public interface ISectionInterface
    {
        Task<List<Section>> GetSections();
        Task<Section> GetSection(Guid id);
        Task<Section> AddSection(Section section);
        Task<Section> UpdateSection(Section section);
        void RemoveSection(Guid id);
    }
}
