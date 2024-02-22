using AutoMapper;
using JobSearch.Business.DTOs.SMCompanyDTOs;
using JobSearch.Business.Repositories.Interfaces;
using JobSearch.Business.Services.Interfaces;
using JobSearch.Core.Entities;

namespace JobSearch.Business.Services.Implements
{
    public class SMCompanyService : ISMCompanyService
    {
        ISMCompanyRepository _repo { get; }
        IMapper _mapper { get; }

        public SMCompanyService(ISMCompanyRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task CreateAsync(SMCompanyCreateDTO dto)
        {
            await _repo.CreateAsync(_mapper.Map<SocialMediaCompany>(dto));
            await _repo.SaveAsync();

        }

        public IEnumerable<SMCompanyListItemDTO> GetAll()
        {
            var data = _repo.GetAll();
            return _mapper.Map<IEnumerable<SMCompanyListItemDTO>>(data);
        }
        public async Task AddSM(SMCompanyCreateDTO dto)
        {
            await _repo.AddSM(_mapper.Map<SocialMediaCompany>(dto));

            await _repo.SaveAsync();
        }
    }

}

