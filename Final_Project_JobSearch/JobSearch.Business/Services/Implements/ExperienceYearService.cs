using AutoMapper;
using JobSearch.Business.DTOs.ExperianceYearDTOs;
using JobSearch.Business.Repositories.Interfaces;
using JobSearch.Business.Services.Interfaces;
using JobSearch.Core.Entities;

namespace JobSearch.Business.Services.Implements
{
    public class ExperienceYearService : IExperienceYearService
    {
        IExperienceYearRepository _repo { get; }
        IMapper _mapper { get; }

        public ExperienceYearService(IExperienceYearRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task CreateAsync(ExperienceYearCreateDTO dto)
        {    ///TODO:Exception duzelt
            if (await _repo.IsExistAsync(r => r.ExpYear.ToLower() == dto.ExpYear.ToLower()))
                throw new Exception("Already exist");
            await _repo.CreateAsync(_mapper.Map<ExperienceYear>(dto));
            await _repo.SaveAsync();
        }

        public IEnumerable<ExperienceYearListItemDTO> GetAll()
        {
            var data = _repo.GetAll();
            return _mapper.Map<IEnumerable<ExperienceYearListItemDTO>>(data);
        }
    }
}
