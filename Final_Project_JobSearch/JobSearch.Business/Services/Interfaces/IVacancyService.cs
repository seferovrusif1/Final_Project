using JobSearch.Business.DTOs.VacancyDTOs;

namespace JobSearch.Business.Services.Interfaces
{
    public interface IVacancyService
    {
        public IEnumerable<VacancyListItemDTO> GetAll();
        public Task CreateAsync(VacancyCreateDTO dto);
        Task Delete(int id);
        Task SoftDelete(int id);
        Task ReverseSoftDelete(int id);
    }
}
