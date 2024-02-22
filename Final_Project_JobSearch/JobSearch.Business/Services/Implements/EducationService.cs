using AutoMapper;
using JobSearch.Business.DTOs.EducationDTOs;
using JobSearch.Business.DTOs.EmailDTOs;
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
    public class EducationService : IEducationService
    {
        IEducationRepository _repo { get; }
        IMapper _mapper { get; }

        public EducationService(IEducationRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task CreateAsync(EducationCreateDTO dto)
        {    
            if (await _repo.IsExistAsync(r => r.Degree.ToLower() == dto.Degree.ToLower()))
                throw new AlreadyExistException<Education>();
            await _repo.CreateAsync(_mapper.Map<Education>(dto));
            await _repo.SaveAsync();
        }

        public IEnumerable<EducationListItemDTO> GetAll()
        {
            var data = _repo.GetAll();
            return _mapper.Map<IEnumerable<EducationListItemDTO>>(data);
        }
    }
}
