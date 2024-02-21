using JobSearch.Business.DTOs.SocialMediaDTOs;
using JobSearch.Business.DTOs.TypeOfVacancyDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.Services.Interfaces
{
    public interface ITypeOfvacancyService
    {
        public IEnumerable<TypeOfVacancyListItemDTO> GetAll();
        public Task CreateAsync(TypeOfVacancyCreateDTO dto);
    }
}
