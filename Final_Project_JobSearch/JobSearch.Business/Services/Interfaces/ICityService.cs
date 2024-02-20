using JobSearch.Business.DTOs.CityDTOs;
using JobSearch.Business.DTOs.EmailDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.Services.Interfaces
{
    public interface ICityService
    {
        public IEnumerable<CityListItemDTO> GetAll();
        public Task CreateAsync(CityCreateDTO dto);
    }
}
