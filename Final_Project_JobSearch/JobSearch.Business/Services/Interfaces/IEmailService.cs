using JobSearch.Business.DTOs.EmailDTOs;
using JobSearch.Business.DTOs.PhoneDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.Services.Interfaces
{
    public interface IEmailService
    {
        ///TODO:dto ile deyisdirc   
        public IEnumerable<EmailListItemDTO> GetAll();
        public Task CreateAsync(EmailCreateDTO dto);
    }
}
