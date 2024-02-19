using AutoMapper;
using JobSearch.Business.DTOs.CompanyDTOs;
using JobSearch.Business.Repositories.Interfaces;
using JobSearch.Business.Services.Interfaces;
using JobSearch.Core.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace JobSearch.Business.Services.Implements
{
    public class CompanyService:ICompanyService
    {
        ICompanyRepository _repo { get; }
        IPhoneRepository _phoneRepo { get; }
        IHttpContextAccessor _contextAccessor { get; }
        IMapper _mapper { get; }
        readonly string userId;

        public CompanyService(ICompanyRepository repo, IMapper mapper, IHttpContextAccessor contextAccessor, IPhoneRepository phoneRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            if (_contextAccessor.HttpContext.User.Claims.Any())
            {
                userId = _contextAccessor.HttpContext?.User?.Claims?.First(x => x.Type == ClaimTypes.NameIdentifier)?.Value ?? throw new NullReferenceException();
            }
            _phoneRepo = phoneRepo;
        }

        ///TODO:DTO lar ,mapper, exceptionlari duzelt
        public async Task CreateAsync(CompanyCreateDTO dto)
        {
            Company data = new Company
            {
                About = dto.About,
                Name = dto.Name,
                AuthorizedPerson = dto.AuthorizedPerson,
                Website = dto.Website,
                IsConfirmed = false
            };
            data.EmailId = 1;
            data.UserId= userId;
            if (_phoneRepo.GetIdFromNumber(dto.Phone) == 0)
            {
                Phone phone = new Phone { Number = dto.Phone };
                await _phoneRepo.CreateAsync(phone);
                await _phoneRepo.SaveAsync();
            }
            data.PhoneId = _phoneRepo.GetIdFromNumber(dto.Phone);
            await _repo.CreateAsync(data);

            await _repo.SaveAsync();
        }

        public IEnumerable<CompanyListItemDTO> GetAll()
        {
            var data=_repo.GetAll();
            return  _mapper.Map<IEnumerable<CompanyListItemDTO>>(data);
        }

     
        //public async Task RemoveAsync(int id)
        //{
        //    var data = await _checkId(id);
        //    _repo.Remove(data);
        //    await _repo.SaveAsync();
        //}

      
        //async Task<Company> _checkId(int id, bool isTrack = false)
        //{
        //    if (id <= 0) throw new ArgumentException();
        //    var data = await _repo.GetByIdAsync(id, isTrack);
        //    if (data == null) throw new Exception();
        //    return data;
        //}

     
    }
}
