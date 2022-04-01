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
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        public static explicit operator Section(EditSectionViewModel viewModel)
        {
            return new Section()
            {
                Id = viewModel.Id,
                Name = viewModel.Name
            };
        }

        public static explicit operator EditSectionViewModel(Section model)
        {
            return new EditSectionViewModel()
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}
