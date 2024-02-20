using JobSearch.Business.DTOs.EmailDTOs;

namespace JobSearch.Business.Services.Interfaces
{
    public interface IEmailService
    {
        ///TODO:dto ile deyisdirc   
            public IEnumerable<EmailListItemDTO> GetAll();
            public Task CreateAsync(EmailCreateDTO dto);
    }
}
