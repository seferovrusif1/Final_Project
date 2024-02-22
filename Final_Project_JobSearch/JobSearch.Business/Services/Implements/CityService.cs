using AutoMapper;
using JobSearch.Business.DTOs.CityDTOs;
using JobSearch.Business.DTOs.EducationDTOs;
using JobSearch.Business.Exceptions.CommonExceptions;
using JobSearch.Business.Repositories.Interfaces;
using JobSearch.Business.Services.Interfaces;
using JobSearch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.Services.Implements
{
    public class CityService : ICityService
    {
        ICityRepository _repo { get; }
        IMapper _mapper { get; }

        public CityService(ICityRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task CreateAsync(CityCreateDTO dto)
        {   
            if (await _repo.IsExistAsync(r => r.Name.ToLower() == dto.Name.ToLower()))
                throw new AlreadyExistException<City>();
            await _repo.CreateAsync(_mapper.Map<City>(dto));
            await _repo.SaveAsync();
        }

        public IEnumerable<CityListItemDTO> GetAll()
        {
            var data = _repo.GetAll();
            return _mapper.Map<IEnumerable<CityListItemDTO>>(data);
        }
    }
}