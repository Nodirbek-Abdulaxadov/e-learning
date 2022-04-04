using E_Learning.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.ViewModel.ViewSection
{
    public class EditSectionViewModel
    {
        public Section Section { get; set; }
        public List<Chapter> Chapters { get; set; }
    }
}
