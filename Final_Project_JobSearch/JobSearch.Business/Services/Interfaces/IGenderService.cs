using JobSearch.Business.DTOs.EmailDTOs;
using JobSearch.Business.DTOs.GenderDTOs;
using JobSearch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.Services.Interfaces
{
    public interface IGenderService
    {
        public IEnumerable<GenderListItemDTO> GetAll();
        public Task CreateAsync(GenderCreateDTO dto);
    }
}
