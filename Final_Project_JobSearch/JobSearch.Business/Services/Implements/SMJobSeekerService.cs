using AutoMapper;
using JobSearch.Business.DTOs.SMJobSeekerDTOs;
using JobSearch.Business.Repositories.Interfaces;
using JobSearch.Business.Services.Interfaces;
using JobSearch.Core.Entities;

namespace JobSearch.Business.Services.Implements
{
    public class SMJobSeekerService : ISMJobSeekerService
    {
        ISMJobSeekerRepository _repo { get; }
        IMapper _mapper { get; }

        public SMJobSeekerService(ISMJobSeekerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task CreateAsync(SMJobSeekerCreateDTO dto)
        {
            //if (await _repo.IsExistAsync(r => r.Title.ToLower() == dto.Title.ToLower()) || await _repo.IsExistAsync(r => r.MainLink.ToLower() == dto.MainLink.ToLower()))
            //    throw new Exception("Already exist");
            await _repo.CreateAsync(_mapper.Map< SocialMediaJobSeeker>(dto));
            await _repo.SaveAsync();

        }

        public IEnumerable<SMJobSeekerListItemDTO> GetAll()
        {
            var data = _repo.GetAll();
            return _mapper.Map<IEnumerable<SMJobSeekerListItemDTO>>(data);
        }
    public async Task AddSM(SMJobSeekerCreateDTO dto)
    {
        await _repo.AddSM(_mapper.Map<SocialMediaJobSeeker>(dto));

        await _repo.SaveAsync();
    }
}


    }