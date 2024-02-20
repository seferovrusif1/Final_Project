using JobSearch.Business.DTOs.CompanyDTOs;

namespace JobSearch.Business.Services.Interfaces
{
    public interface ICompanyService
    {
        ///TODO:dto ile deyisdir
        public IEnumerable<CompanyListItemDTO> GetAll();
        public Task CreateAsync(CompanyCreateDTO dto);
    }
}
