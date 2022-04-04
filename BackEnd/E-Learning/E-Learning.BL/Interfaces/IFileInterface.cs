using E_Learning.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BL.Interfaces
{
    public interface IFileInterface
    {
        List<FileModel> GetFiles(Guid courseId);
    }
}
