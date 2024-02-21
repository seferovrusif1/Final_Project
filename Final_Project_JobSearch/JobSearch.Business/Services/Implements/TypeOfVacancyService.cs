using AutoMapper;
using JobSearch.Business.DTOs.TypeOfVacancyDTOs;
using JobSearch.Business.Repositories.Interfaces;
using JobSearch.Business.Services.Interfaces;
using JobSearch.Core.Entities;

namespace JobSearch.Business.Services.Implements
{
    public class TypeOfVacancyService : ITypeOfvacancyService

    {
        ITypeOfVacancyRepository _repo { get; }
        IMapper _mapper { get; }

        public TypeOfVacancyService(ITypeOfVacancyRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task CreateAsync(TypeOfVacancyCreateDTO dto)
        {
            if (await _repo.IsExistAsync(r => r.Title.ToLower() == dto.Title.ToLower()))
                throw new Exception("Already exist");
            ///TODO:getbyid ile parent id olub olmadigini tap
            await _repo.CreateAsync(_mapper.Map<TypeOfVacancy>(dto));
            await _repo.SaveAsync();
        }

        public IEnumerable<TypeOfVacancyListItemDTO> GetAll()
        {
            var data = _repo.GetAll();
            return _mapper.Map<IEnumerable<TypeOfVacancyListItemDTO>>(data);

        }
    }
}
