using JobSearch.Business.DTOs.PhoneDTOs;
using JobSearch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.Services.Interfaces
{
    public interface IPhoneService
    {
        ///TODO:dto ile deyisdirc   
        public IEnumerable<PhoneListItemDTO> GetAll();
        public Task CreateAsync(PhoneCreateDTO dto);
    }
}
