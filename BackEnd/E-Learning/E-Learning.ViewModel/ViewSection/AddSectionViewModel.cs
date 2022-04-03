using E_Learning.Domain;
using System.Collections.Generic;

namespace E_Learning.ViewModel.ViewSection
{
    public class AddSectionViewModel
    {
        public Section Section { get; set; }
        public List<Chapter> Chapters { get; set; }
    }
}
