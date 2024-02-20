using JobSearch.Business.DTOs.EducationDTOs;
using JobSearch.Business.DTOs.EmailDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.Services.Interfaces
{
    public interface IEducationService
    {     
        public IEnumerable<EducationListItemDTO> GetAll();
        public Task CreateAsync(EducationCreateDTO dto);
    }
}
