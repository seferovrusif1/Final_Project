using JobSearch.Business.DTOs.JobSeekerDTOs;
using JobSearch.Business.DTOs.VacancyDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.Services.Interfaces
{
    public interface IJobSeekerService
    {
        public IEnumerable<JobSeekerListItemDTO> GetAll();
        public Task CreateAsync(JobSeekerCreateDTO dto);
        Task Delete(int id);
        Task SoftDelete(int id);
        Task ReverseSoftDelete(int id);
    }
}
