using JobSearch.Business.DTOs.CompanyDTOs;

namespace JobSearch.Business.Services.Interfaces
{
    public interface ICompanyService
    {
        public IEnumerable<CompanyListItemDTO> GetAll();
        public Task CreateAsync(CompanyCreateDTO dto);
        Task Delete(int id);
        Task SoftDelete(int id);
        Task ReverseSoftDelete(int id);
    }
}
