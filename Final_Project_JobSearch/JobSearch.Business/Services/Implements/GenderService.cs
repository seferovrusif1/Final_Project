using AutoMapper;
using JobSearch.Business.DTOs.EmailDTOs;
using JobSearch.Business.DTOs.GenderDTOs;
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
    public class GenderService : IGenderService
    {
        IGenderRepository _repo { get; }
        IMapper _mapper {  get; }
        public GenderService(IMapper mapper, IGenderRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task CreateAsync(GenderCreateDTO dto)
        {
            if (await _repo.IsExistAsync(r => r.Title.ToLower() == dto.Title.ToLower()))
                throw new AlreadyExistException<Gender>();
            await _repo.CreateAsync(_mapper.Map<Gender>(dto));
            await _repo.SaveAsync();
        }

        public IEnumerable<GenderListItemDTO> GetAll()
        {
            var data = _repo.GetAll();
            return _mapper.Map<IEnumerable<GenderListItemDTO>>(data);

        }
    }
}
